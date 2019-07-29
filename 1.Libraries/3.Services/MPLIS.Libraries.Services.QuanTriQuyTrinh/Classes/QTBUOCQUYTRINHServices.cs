using System;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using System.Xml;
using System.Xml.Linq;
using System.Data.Common;
using System.Data.Entity;

namespace MPLIS.Libraries.Services.QuanTriQuyTrinh
{
    public static class QTBUOCQUYTRINHServices
    {
        public static List<QT_BUOCQUYTRINH> ConvertXMLToObject(string eXML, string quyTrinhID, out bool err, out string errMes)
        {
            List<QT_BUOCQUYTRINH> dSBuocQuyTrinh = new List<QT_BUOCQUYTRINH>();
            errMes = "";
            string dXML = HttpUtility.UrlDecode(eXML);
            if (CheckValidDiagram(dXML, out errMes))
            {
                XmlReader xmlRead = XmlReader.Create(new StringReader(dXML));
                XElement root = XElement.Load(xmlRead);
                IEnumerable<XElement> collecDoc = root.Descendants();
                XElement process = root.Elements().Where(it => it.Name.LocalName == "process").FirstOrDefault();
                XElement startEvent = process.Elements().Where(e => e.Name.LocalName == "startEvent").First();
                XElement startOutcoming = startEvent.Elements().Where(e => e.Name.LocalName == "outgoing").First();
                XElement incomingStask1 = process.Elements().Where(e => e.Name.LocalName == "task")
                    .Elements().Where(f => f.Name.LocalName == "incoming" && f.Value == startOutcoming.Value).First();
                IEnumerable<XElement> endEvents = collecDoc.Where(e => e.Name.LocalName == "endEvent");
                IEnumerable<XElement> tasks = collecDoc.Where
                    (
                        it => it.Name.LocalName == "task" ||
                        it.Name.LocalName.Equals("exclusiveGateway")
                    ).ToList();
                foreach (var tempTask in tasks)
                {
                    QT_BUOCQUYTRINH tempBuocQuyTrinh = new QT_BUOCQUYTRINH();
                    tempBuocQuyTrinh.BUOCQUYTRINHID = Guid.NewGuid().ToString();
                    tempBuocQuyTrinh.BPMNID = tempTask.Attribute("id").Value;
                    tempBuocQuyTrinh.QUYTRINHID = quyTrinhID;
                    tempBuocQuyTrinh.DIEUKIEN = 0;
                    tempBuocQuyTrinh.TENBUOC = tempTask.Attribute("name") != null ? tempTask.Attribute("name").Value : "";
                    XElement shape = collecDoc.Where(it => it.Name.LocalName == "BPMNShape" && it.Attribute("bpmnElement").Value == tempTask.Attribute("id").Value).FirstOrDefault();
                    XElement bound = shape.Elements().Where(it => it.Name.LocalName == "Bounds").FirstOrDefault();
                    double number = 0;
                    double.TryParse(bound.Attribute("x").Value, out number);
                    tempBuocQuyTrinh.RECTX = (decimal)number;
                    double.TryParse(bound.Attribute("y").Value, out number);
                    tempBuocQuyTrinh.RECTY = (decimal)number;
                    double.TryParse(bound.Attribute("width").Value, out number);
                    tempBuocQuyTrinh.RECTWIDTH = (decimal)number;
                    double.TryParse(bound.Attribute("height").Value, out number);
                    tempBuocQuyTrinh.RECTHEIGHT = (decimal)number;
                    tempBuocQuyTrinh.LOAIBUOCQT = "N";
                    if (tempTask.Elements().Where(it => it.Name.LocalName == "incoming" && it.Value == startOutcoming.Value).Count() > 0)
                    {
                        tempBuocQuyTrinh.LOAIBUOCQT = "S";
                    }
                    if (tempTask.Elements().Where(it => it.Name.LocalName == "incoming" && it.Value == startOutcoming.Value).Count() > 0)
                    {
                        tempBuocQuyTrinh.LOAIBUOCQT = "S";
                    }
                    bool flagCheck = false;
                    var retOutGoings = tempTask.Elements().Where(it => it.Name.LocalName == "outgoing").ToList();
                    foreach (var tempOutGoing in retOutGoings)
                    {
                        foreach (var tempEndEvent in endEvents)
                        {
                            var retTempEnd = tempEndEvent.Elements().Where(it => it.Name.LocalName == "incoming" && it.Value == tempOutGoing.Value).FirstOrDefault();
                            if (retTempEnd != null)
                            {
                                flagCheck = true;
                                break;
                            }
                        }
                        if (flagCheck)
                            break;
                    }
                    if (flagCheck)
                    {
                        tempBuocQuyTrinh.LOAIBUOCQT = "E";
                    }
                    tempBuocQuyTrinh.BUOCQUYTRINHSAUIDS = GetBuocQuyTrinhSauID(tempTask, collecDoc);
                    tempBuocQuyTrinh.BUOCQUYTRINHTRUOCIDS = GetBuocQuyTrinhTruocID(tempTask, collecDoc);
                    dSBuocQuyTrinh.Add(tempBuocQuyTrinh);
                }
                err = false;
            }
            else
            {
                err = true;
            }
            return dSBuocQuyTrinh;
        }
        private static bool CheckValidDiagram(string xml, out string strErr)
        {
            strErr = "";
            XmlReader xmlRead = XmlReader.Create(new StringReader(xml));

            XElement root = XElement.Load(xmlRead);
            //this diagram has only 1 start
            var xStart = root.Descendants().Where(x => x.Name.LocalName == "startEvent").Count();
            if (xStart != 1)
            {
                strErr = "Sơ đồ quy trình phải có một (và chỉ một) Bắt đầu";
                return false;
            }
            xStart = root.Descendants().Where(x => x.Name.LocalName == "startEvent"
            && x.Elements().Where(y => y.Name.LocalName == "outgoing").Count() != 1).Count();
            if (xStart > 0)
            {
                strErr = "Điểm bắt đầu phải có một (và chỉ một) đường ra.";
                return false;
            }
            //must has 1 endstask
            var xEnd = root.Descendants().Where(x => x.Name.LocalName == "endEvent").Count();
            if (xEnd == 0)
            {
                strErr = "Sơ đồ quy trình phải có ít nhất một kết thúc";
                return false;
            }
            //1 task has only 1 outgoing
            var xTask = from t in root.Descendants()
                        where t.Name.LocalName == "task"
                        && (t.Elements().Where(x => x.Name.LocalName == "outgoing").Count() < 1)
                        select t;
            if (xTask.Count() > 0)
            {
                strErr = string.Format("Tác vụ: {0} phải có ít nhất một đường ra."
                    , (xTask.FirstOrDefault().Attribute("name") != null
                    ? xTask.FirstOrDefault().Attribute("name").Value
                    : xTask.FirstOrDefault().Attribute("id").Value));
                return false;
            }
            xTask = from t in root.Descendants()
                    where t.Name.LocalName == "task"

                    select t;
            if (xTask.Count() == 0)
            {
                strErr = string.Format("Phải có ít nhất một tác vụ trong sơ đồ.");
                return false;
            }
            xTask = from t in root.Descendants()
                    where t.Name.LocalName == "task"
                    && (t.Elements().Where(x => x.Name.LocalName == "incoming").Count() == 0)
                    select t;
            if (xTask.Count() > 0)
            {
                strErr = string.Format("Tác vụ: {0} phải có ít nhất một đường vào."
                    , (xTask.FirstOrDefault().Attribute("name") != null
                    ? xTask.FirstOrDefault().Attribute("name").Value
                    : xTask.FirstOrDefault().Attribute("id").Value));
                return false;
            }
            //1 parallel must has 1 outgoing
            //var xParael; = from t in root.Descendants()
            //              where t.Name.LocalName == "parallelGateway"
            //              && (t.Elements().Where(x => x.Name.LocalName == "outgoing").Count() > 1)
            //              select t;
            //if (xParael.Count() > 0)
            //{
            //    strErr = string.Format("Parallel: {0} chỉ được phép có một đường ra."
            //        , (xParael.FirstOrDefault().Attribute("name") != null
            //        ? xParael.FirstOrDefault().Attribute("name").Value
            //        : xParael.FirstOrDefault().Attribute("id").Value));
            //    return false;
            //}
            var xParael = from t in root.Descendants()
                          where t.Name.LocalName == "parallelGateway"
                          && (t.Elements().Where(x => x.Name.LocalName == "outgoing").Count() == 0)
                          select t;
            if (xParael.Count() > 0)
            {
                strErr = string.Format("Parallel: {0} phải có ít nhất một đường ra."
                    , (xParael.FirstOrDefault().Attribute("name") != null
                    ? xParael.FirstOrDefault().Attribute("name").Value
                    : xParael.FirstOrDefault().Attribute("id").Value));
                return false;
            }
            xParael = from t in root.Descendants()
                      where t.Name.LocalName == "parallelGateway"
                      && (t.Elements().Where(x => x.Name.LocalName == "incoming").Count() < 1)
                      select t;
            if (xParael.Count() > 0)
            {
                strErr = string.Format("Parallel: {0} phải có ít nhất một đường vào."
                    , (xParael.FirstOrDefault().Attribute("name") != null
                    ? xParael.FirstOrDefault().Attribute("name").Value
                    : xParael.FirstOrDefault().Attribute("id").Value));
                return false;
            }

            //1 exclusiveGateway must has 1 incoming
            var xExclusive = from t in root.Descendants()
                             where t.Name.LocalName == "exclusiveGateway"
                             && (t.Elements().Where(x => x.Name.LocalName == "incoming").Count() < 1)
                             select t;
            if (xExclusive.Count() > 0)
            {
                strErr = string.Format("exclusiveGateway: {0} phải có ít nhất một đường vào."
                    , (xExclusive.FirstOrDefault().Attribute("name") != null
                    ? xExclusive.FirstOrDefault().Attribute("name").Value
                    : xExclusive.FirstOrDefault().Attribute("id").Value));
                return false;
            }
            xExclusive = from t in root.Descendants()
                         where t.Name.LocalName == "exclusiveGateway"
                         && (t.Elements().Where(x => x.Name.LocalName == "outgoing").Count() < 2)
                         select t;
            if (xExclusive.Count() > 0)
            {
                strErr = string.Format("exclusiveGateway: {0} phải có ít nhất hai đường ra."
                    , (xExclusive.FirstOrDefault().Attribute("name") != null
                    ? xExclusive.FirstOrDefault().Attribute("name").Value
                    : xExclusive.FirstOrDefault().Attribute("id").Value));
                return false;
            }
            return true;
        }
        private static string GetBuocQuyTrinhSauID(XElement curTask, IEnumerable<XElement> collecDoc)
        {
            string strIDTask = "";
            var retOutGoings = curTask.Elements().Where(it => it.Name.LocalName == "outgoing").ToList();
            foreach (var tempOutGoing in retOutGoings)
            {
                var retInTask = collecDoc.Where
                                (
                                    it => (it.Parent.Name.LocalName == "task" ||
                                    it.Parent.Name.LocalName == "exclusiveGateway") &&
                                    (it.Name.LocalName == "incoming") &&
                                    (it.Value == tempOutGoing.Value)
                                 )
                                 .Select(it => it.Parent)
                                 .FirstOrDefault();
                if (retInTask != null)
                {
                    strIDTask += (string.IsNullOrEmpty(strIDTask) ? retInTask.Attribute("id").Value : (";" + retInTask.Attribute("id").Value));
                }
                //var retInComplexGateway = collecDoc.Where
                //                (
                //                    it => (it.Parent.Name.LocalName == "complexGateway") &&
                //                    (it.Name.LocalName == "incoming") &&
                //                    (it.Value == tempOutGoing.Value)
                //                )
                //                .Select(it => it.Parent)
                //                .FirstOrDefault();
                //if(retInComplexGateway != null)
                //{
                //    var retInComplexGatewayOutGoings = retInComplexGateway.Elements().Where(it => it.Name.LocalName == "outgoing").ToList();
                //    foreach (var tempRICGOG in retInComplexGatewayOutGoings)
                //    {
                //        var retAfterCG = collecDoc.Where
                //                        (
                //                            it => (it.Name.LocalName == "incoming") &&
                //                            (it.Value == tempRICGOG.Value) &&
                //                            (it.Parent.Name.LocalName == "task" ||
                //                            it.Parent.Name.LocalName == "exclusiveGateway" ||
                //                            it.Parent.Name.LocalName == "parallelGateway")
                //                        )
                //                        .Select(it => it.Parent)
                //                        .FirstOrDefault();
                //        if (retAfterCG != null)
                //        {
                //            strIDTask += (string.IsNullOrEmpty(strIDTask) ? retAfterCG.Attribute("id").Value : (";" + retAfterCG.Attribute("id").Value));
                //        }
                //    }
                //}
            }
            return strIDTask;
        }
        private static string GetBuocQuyTrinhTruocID(XElement curTask, IEnumerable<XElement> collecDoc)
        {
            string strIDTask = "";
            var retInGoings = curTask.Elements().Where(it => it.Name.LocalName == "incoming").ToList();
            foreach (var tempInGoing in retInGoings)
            {
                var retIOutTask = collecDoc.Where
                                (
                                    it => (it.Parent.Name.LocalName == "task" ||
                                    it.Parent.Name.LocalName == "exclusiveGateway") &&
                                    (it.Name.LocalName == "outgoing") &&
                                    (it.Value == tempInGoing.Value)
                                 )
                                 .Select(it => it.Parent)
                                 .FirstOrDefault();
                if (retIOutTask != null)
                {
                    strIDTask += (string.IsNullOrEmpty(strIDTask) ? retIOutTask.Attribute("id").Value : (";" + retIOutTask.Attribute("id").Value));
                }
                //var retOutComplexGateway = collecDoc.Where
                //                (
                //                    it => (it.Parent.Name.LocalName == "complexGateway") &&
                //                    (it.Name.LocalName == "outgoing") &&
                //                    (it.Value == tempInGoing.Value)
                //                )
                //                .Select(it => it.Parent)
                //                .FirstOrDefault();
                //if(retOutComplexGateway != null)
                //{
                //    var retOutComplexGatewayInComings = retOutComplexGateway.Elements().Where(it => it.Name.LocalName == "incoming").ToList();
                //    foreach (var tempOCGIC in retOutComplexGatewayInComings)
                //    {
                //        var retBeforeCG = collecDoc.Where
                //                        (
                //                            it => (it.Name.LocalName == "outgoing") &&
                //                            (it.Value == tempOCGIC.Value) &&
                //                            (it.Parent.Name.LocalName == "task" ||
                //                            it.Parent.Name.LocalName == "exclusiveGateway" ||
                //                            it.Parent.Name.LocalName == "parallelGateway")
                //                        )
                //                        .Select(it => it.Parent)
                //                        .FirstOrDefault();
                //        if (retBeforeCG != null)
                //        {
                //            strIDTask += (string.IsNullOrEmpty(strIDTask) ? retBeforeCG.Attribute("id").Value : (";" + retBeforeCG.Attribute("id").Value));
                //        }
                //    }
                //}
            }
            return strIDTask;
        }
        public static Hashtable GetHashTableXuLyCauHinh(List<QT_BUOCQUYTRINH> dSBuocQuyTrinh)
        {
            Hashtable hashTableXuLyCauHinh = new Hashtable();
            foreach (var tempA in dSBuocQuyTrinh)
            {
                if (!hashTableXuLyCauHinh.Contains(tempA.BUOCQUYTRINHID))
                {
                    Hashtable NguoiXaPhuong = new Hashtable();
                    if (tempA.DSBuocQTCauHinh != null)
                    {
                        foreach (var tempB in tempA.DSBuocQTCauHinh)
                        {
                            if ((tempA.BUOCQUYTRINHID == tempB.BUOCQUYTRINHID) && (!NguoiXaPhuong.Contains(tempB.NGUOIDUNGID)))
                            {
                                List<string> dSXaPhuong = new List<string>();
                                foreach (var tempC in tempA.DSBuocQTCauHinh)
                                {
                                    if (tempC.NGUOIDUNGID == tempB.NGUOIDUNGID)
                                    {
                                        dSXaPhuong.Add(tempC.KVHCID);
                                    }
                                }
                                NguoiXaPhuong.Add(tempB.NGUOIDUNGID, dSXaPhuong);
                            }
                        }
                    }
                    hashTableXuLyCauHinh.Add(tempA.BUOCQUYTRINHID, NguoiXaPhuong);
                }
            }
            return hashTableXuLyCauHinh;
        }
        public static bool SaveBuocQuyTrinh(QT_QUYTRINH quyTrinh, List<QT_BUOCQUYTRINH> curDSBuocQuyTrinh)
        {
            //Delete QT_BUOCQT_CAUHINH && QT_CONGVIECTHEOBUOC by BUOCQUYTRINHID
            if (quyTrinh.DSBuocQuyTrinh.Count > 0)
            {
                List<string> queryDeleteBuocQT = new List<string>();
                List<string> queryDeleteCongViec = new List<string>();
                foreach (var tempBuocQuyTrinh in quyTrinh.DSBuocQuyTrinh)
                {
                    queryDeleteBuocQT.Add("DELETE QT_BUOCQT_CAUHINH WHERE BUOCQUYTRINHID IN ('" + tempBuocQuyTrinh.BUOCQUYTRINHID + "');");
                    queryDeleteCongViec.Add("DELETE QT_CONGVIECTHEOBUOC WHERE BUOCQUYTRINHID IN ('" + tempBuocQuyTrinh.BUOCQUYTRINHID + "');");
                }
                string sqlBatchDeleteBuocQT = "";
                string sqlBatchDeleteCongViec = "";
                foreach (var tempQuery in queryDeleteBuocQT)
                {
                    sqlBatchDeleteBuocQT += tempQuery;
                }
                foreach (var tempQuery in queryDeleteCongViec)
                {
                    sqlBatchDeleteCongViec += tempQuery;
                }
                using (MplisEntities db = new MplisEntities())
                {
                    try
                    {
                        if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                            db.Database.Connection.Open();
                        DbCommand cmd = db.Database.Connection.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        sqlBatchDeleteBuocQT = "BEGIN " + sqlBatchDeleteBuocQT + " END; ";
                        cmd.CommandText = sqlBatchDeleteBuocQT;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        var err = ex;
                    }
                    try
                    {
                        if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                            db.Database.Connection.Open();
                        DbCommand cmd = db.Database.Connection.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        sqlBatchDeleteCongViec = "BEGIN " + sqlBatchDeleteCongViec + " END; ";
                        cmd.CommandText = sqlBatchDeleteCongViec;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        var err = ex;
                    }
                }
            }
            //Delete QT_BUOCQUYTRINH by QUYTRINHID
            using (MplisEntities db = new MplisEntities())
            {
                try
                {
                    if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                        || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                        db.Database.Connection.Open();
                    DbCommand cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    //sqlBatchDelete = "BEGIN " + sqlBatchDelete + " END; ";
                    cmd.CommandText = "BEGIN DELETE QT_BUOCQUYTRINH WHERE QUYTRINHID IN ('" + quyTrinh.QUYTRINHID + "'); END;";
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    var err = ex;
                }
            }
            //Insert QT_BUOCQUYTRINH
            if(curDSBuocQuyTrinh.Count > 0)
            {
                try
                {
                    using (MplisEntities db = new MplisEntities())
                    {
                        foreach (var tempBuocQuyTrinh in curDSBuocQuyTrinh)
                        {
                            tempBuocQuyTrinh.BUOCQUYTRINHID = Guid.NewGuid().ToString();
                            db.Entry(tempBuocQuyTrinh).State = EntityState.Added;
                        }
                        db.SaveChanges();
                    }
                    quyTrinh.DSBuocQuyTrinh = curDSBuocQuyTrinh;
                    quyTrinh.CauHinhXuLy = QTBUOCQUYTRINHServices.GetHashTableXuLyCauHinh(curDSBuocQuyTrinh);
                } catch(Exception ex)
                {
                    var err = ex;
                }
                
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using System.Data.Entity;
using AutoMapper;
using System.Data.Common;

namespace MPLIS.Libraries.Services.QuanTriQuyTrinh
{
    public static class QTQUYTRINHServices
    {
        public static bool SaveQuyTrinh(List<QT_QUYTRINH> dSQuyTrinh, QT_QUYTRINH curQuyTrinh, out string mes)
        {
            try
            {
                using (MplisEntities db = new MplisEntities())
                {
                    if(curQuyTrinh.TRANGTHAI == 2)
                    {
                        db.Entry(curQuyTrinh).State = EntityState.Modified;
                    } else if(curQuyTrinh.TRANGTHAI == 1)
                    {
                        db.Entry(curQuyTrinh).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                mes = ex.Message;
                return false;
            }
            mes = "Lưu thông tin quy trình vào CSDL thành công!";
            if(curQuyTrinh.TRANGTHAI == 1)
            {
                curQuyTrinh.TRANGTHAI = 2;
                dSQuyTrinh.Add(curQuyTrinh);
            }
            return true;
        }
        public static List<QT_QUYTRINH> TimKiemQuyTrinhByTenQuyTrinh(string tenQuyTrinh, string KVHCID)
        {
            List<QT_QUYTRINH> dSQuyTrinh = new List<QT_QUYTRINH>();
            using (MplisEntities db = new MplisEntities())
            {
                var retQuyTrinhs = db.QT_QUYTRINH.Where(it => it.DONVIHANHCHINHID == KVHCID && it.TENQUYTRINH.ToUpper().Contains(tenQuyTrinh.ToUpper()))
                    .Select(quyTrinh => new
                    {
                        quyTrinh,
                        buocQuyTrinhs = db.QT_BUOCQUYTRINH.Where(it => it.QUYTRINHID == quyTrinh.QUYTRINHID)
                        .Select(buocQuyTrinh => new
                        {
                            buocQuyTrinh,
                            buocQTCauHinhs = db.QT_BUOCQT_CAUHINH.Where(it => it.BUOCQUYTRINHID == buocQuyTrinh.BUOCQUYTRINHID).ToList(),
                            congViecTheoBuocs = db.QT_CONGVIECTHEOBUOC.Where(it => it.BUOCQUYTRINHID == buocQuyTrinh.BUOCQUYTRINHID).ToList()
                        }).ToList(),
                        nhomQuyTrinh = db.QT_NHOMQUYTRINH.Where(it => it.NHOMQUYTRINHID == quyTrinh.NHOMQUYTRINHID).FirstOrDefault()
                    }).ToList();
                if (retQuyTrinhs != null)
                {
                    foreach (var tempQuyTrinh in retQuyTrinhs)
                    {
                        tempQuyTrinh.quyTrinh.TRANGTHAI = 2;
                        tempQuyTrinh.quyTrinh.TENNHOMQUYTRINH = tempQuyTrinh.nhomQuyTrinh.TENNHOMQUYTRINH;
                        tempQuyTrinh.quyTrinh.NhomQuyTrinh = tempQuyTrinh.nhomQuyTrinh;
                        tempQuyTrinh.quyTrinh.DSBuocQuyTrinh = new List<QT_BUOCQUYTRINH>();
                        foreach (var tempBuocQuyTrinh in tempQuyTrinh.buocQuyTrinhs)
                        {
                            tempBuocQuyTrinh.buocQuyTrinh.DSBuocQTCauHinh = new List<QT_BUOCQT_CAUHINH>();
                            tempBuocQuyTrinh.buocQuyTrinh.DSCongViecTheoBuoc = new List<QT_CONGVIECTHEOBUOC>();
                            foreach (var tempQTCauHinh in tempBuocQuyTrinh.buocQTCauHinhs)
                            {
                                tempBuocQuyTrinh.buocQuyTrinh.DSBuocQTCauHinh.Add(tempQTCauHinh);
                            }
                            foreach (var tempCongViecTheoBuoc in tempBuocQuyTrinh.congViecTheoBuocs)
                            {
                                tempBuocQuyTrinh.buocQuyTrinh.DSCongViecTheoBuoc.Add(tempCongViecTheoBuoc);
                            }
                            tempQuyTrinh.quyTrinh.DSBuocQuyTrinh.Add(tempBuocQuyTrinh.buocQuyTrinh);
                        }
                        tempQuyTrinh.quyTrinh.CauHinhXuLy = QTBUOCQUYTRINHServices.GetHashTableXuLyCauHinh(tempQuyTrinh.quyTrinh.DSBuocQuyTrinh);
                        dSQuyTrinh.Add(tempQuyTrinh.quyTrinh);
                    }
                }
            }
            return dSQuyTrinh;
        }
        //Sao chép thành công return true, ngược lại return false
        public static bool CoppyQuyTrinh(List<QT_QUYTRINH> dSQuyTrinh, string quyTrinhID, out QT_QUYTRINH quyTrinhClone, out string mes)
        {
            //Tìm kiếm quy trình theo quyTrinhID trong Session: dSQuyTrinh
            QT_QUYTRINH quyTrinh = null;
            foreach (var tempQuyTrinh in dSQuyTrinh)
            {
                if (quyTrinhID == tempQuyTrinh.QUYTRINHID)
                {
                    quyTrinh = Mapper.Map<QT_QUYTRINH, QT_QUYTRINH>(tempQuyTrinh);
                    break;
                }
            }
            if(quyTrinh != null)
            {
                //Tìm thấy quy trình
                //Thực hiện sao chép quy trình và các dữ liệu liên quan tới quy trình trong các Table: 
                //QT_TTHC_QUYTRINH, QT_BUOCQUYTRINH, QT_BUOCQT_CAUHINH, QT_CONGVIECTHEOBUOC, QT_QUYTRINH
                using (MplisEntities db = new MplisEntities())
                {
                    try
                    {
                        //Clone QT_NHOMQUYTRINH
                        quyTrinh.NhomQuyTrinh.NHOMQUYTRINHID = Guid.NewGuid().ToString();
                        db.Entry(quyTrinh.NhomQuyTrinh).State = EntityState.Added;
                        //Clone QT_QUYTRINH
                        quyTrinh.QUYTRINHID = Guid.NewGuid().ToString();
                        quyTrinh.TENQUYTRINH += " (Sao chép)";
                        quyTrinh.NHOMQUYTRINHID = quyTrinh.NhomQuyTrinh.NHOMQUYTRINHID;
                        db.Entry(quyTrinh).State = EntityState.Added;
                        //Clone QT_BUOCQUYTRINH
                        foreach (var tempBuocQuyTrinh in quyTrinh.DSBuocQuyTrinh)
                        {
                            tempBuocQuyTrinh.BUOCQUYTRINHID = Guid.NewGuid().ToString();
                            tempBuocQuyTrinh.QUYTRINHID = quyTrinh.QUYTRINHID;
                            db.Entry(tempBuocQuyTrinh).State = EntityState.Added;
                            //Clone QT_BUOCQT_CAUHINH
                            foreach (var tempBuocCauHinh in tempBuocQuyTrinh.DSBuocQTCauHinh)
                            {
                                tempBuocCauHinh.BUOCQTCAUHINHID = Guid.NewGuid().ToString();
                                tempBuocCauHinh.BUOCQUYTRINHID = tempBuocQuyTrinh.BUOCQUYTRINHID;
                                db.Entry(tempBuocCauHinh).State = EntityState.Added;
                            }
                            //Clone QT_CONGVIECTHEOBUOC
                            foreach (var tempBuocCongViec in tempBuocQuyTrinh.DSCongViecTheoBuoc)
                            {
                                tempBuocCongViec.CONGVIECTHEOBUOCID = Guid.NewGuid().ToString();
                                tempBuocCongViec.BUOCQUYTRINHID = tempBuocQuyTrinh.BUOCQUYTRINHID;
                                db.Entry(tempBuocCongViec).State = EntityState.Added;
                            }
                        }
                        db.SaveChanges();
                    } catch (Exception ex)
                    {
                        mes = "Lỗi: " + ex.Message;
                        quyTrinhClone = quyTrinh;
                        return false;
                    }
                }
                //Sau khi sao chép dữ liệu trong DataBase thành công, thêm mới quy trình vào trong Session: dSQuyTrinh
                dSQuyTrinh.Add(quyTrinh);
                mes = "Sao chép quy trình và dữ liệu liên quan đến quy trình thành công!";
                quyTrinhClone = quyTrinh;
                return true;
            }
            mes = "Lỗi: Không tìm thấy quy trình?";
            quyTrinhClone = quyTrinh;
            return false;
        }
        //Xóa thành công return true, ngược lại return false
        public static bool DeleteQuyTrinh(List<QT_QUYTRINH> dSQuyTrinh, string quyTrinhID, out string mes)
        {
            //Tìm kiếm quy trình theo quyTrinhID trong Session: dSQuyTrinh
            QT_QUYTRINH quyTrinh = null;
            foreach(var tempQuyTrinh in dSQuyTrinh)
            {
                if(tempQuyTrinh.QUYTRINHID == quyTrinhID)
                {
                    quyTrinh = tempQuyTrinh;
                    break;
                }
            }
            if(quyTrinh != null)
            {
                //Tìm thấy quy trình
                //Thực hiện xóa quy trình và các dữ liệu liên quan tới quy trình trong các Table: 
                //QT_TTHC_QUYTRINH, QT_BUOCQUYTRINH, QT_BUOCQT_CAUHINH, QT_CONGVIECTHEOBUOC, QT_QUYTRINH
                using (MplisEntities db = new MplisEntities())
                {
                    //QT_TTHC_QUYTRINH
                    string queryDeleteTTHCQT = "DELETE QT_TTHC_QUYTRINH WHERE QUYTRINHID IN ('" + quyTrinh.QUYTRINHID + "');";
                    //QT_BUOCQUYTRINH
                    string queryDeleteQTBuocQuyTrinh = "DELETE QT_BUOCQUYTRINH WHERE QUYTRINHID IN ('" + quyTrinh.QUYTRINHID + "');";
                    //QT_BUOCQT_CAUHINH
                    //QT_CONGVIECTHEOBUOC
                    List<string> queryDeleteBuocQTCauHinh = new List<string>();
                    List<string> queryDeleteBuocQTCongViec = new List<string>();
                    foreach (var tempBuocQT in quyTrinh.DSBuocQuyTrinh)
                    {
                        queryDeleteBuocQTCauHinh.Add("DELETE QT_BUOCQT_CAUHINH WHERE BUOCQUYTRINHID IN ('" + tempBuocQT.BUOCQUYTRINHID + "');");
                        queryDeleteBuocQTCongViec.Add("DELETE QT_CONGVIECTHEOBUOC WHERE BUOCQUYTRINHID IN ('" + tempBuocQT.BUOCQUYTRINHID + "');");
                    }
                    //QT_QUYTRINH
                    string queryDeleteQuyTrinh = "DELETE QT_QUYTRINH WHERE QUYTRINHID IN ('" + quyTrinh.QUYTRINHID + "');";
                    string sqlBatchDeleteBuocQT = "";
                    sqlBatchDeleteBuocQT += queryDeleteTTHCQT;
                    if (queryDeleteBuocQTCauHinh.Count > 0)
                    {
                        foreach (var temp in queryDeleteBuocQTCauHinh)
                        {
                            sqlBatchDeleteBuocQT += temp;
                        }
                    }
                    if (queryDeleteBuocQTCongViec.Count > 0)
                    {
                        foreach (var temp in queryDeleteBuocQTCongViec)
                        {
                            sqlBatchDeleteBuocQT += temp;
                        }
                    }
                    sqlBatchDeleteBuocQT += queryDeleteQTBuocQuyTrinh;
                    sqlBatchDeleteBuocQT += queryDeleteQuyTrinh;
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
                        //Xảy ra lỗi khi xóa trong DataBase
                        mes = "Lỗi: " + ex.Message;
                        return false;
                    }
                }
                //Sau khi xóa dữ liệu trong DataBase thành công, xóa luôn quy trình trong Session: dSQuyTrinh
                dSQuyTrinh.Remove(quyTrinh);
                mes = "Xóa quy trình và dữ liệu liên quan đến quy trình thành công!";
                return true;
            }
            //Không tìm thấy quy trình
            mes = "Lỗi: Không tìm thấy quy trình?";
            return false;
        }
        public static int GetSoLanXuLy(string quyTrinhID)
        {
            int soLanXuLy = 0;
            using(MplisEntities db = new MplisEntities())
            {
                soLanXuLy = db.QT_HOSO_LANXULY.Where(it => it.QUYTRINHID == quyTrinhID).Count();
            }
            return soLanXuLy;
        }
    }
}

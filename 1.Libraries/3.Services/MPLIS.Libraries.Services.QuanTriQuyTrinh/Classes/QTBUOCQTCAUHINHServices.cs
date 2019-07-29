using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using Newtonsoft.Json;
using System.Data.Common;
using System.Data.Entity;

namespace MPLIS.Libraries.Services.QuanTriQuyTrinh
{
    public static class QTBUOCQTCAUHINHServices
    {
        public static bool SaveBuocQTCauHinh(string JSONCauHinhXuLy, QT_QUYTRINH curQuyTrinh)
        {
            #region Convert string JSON to HashTalbe: HashTalbe<Key: BUOCQUYTRINHID, Values: HashTable<Key: NGUOIDUNGID, Values: List<string> XAID>>
            Hashtable hashTableA = JsonConvert.DeserializeObject<Hashtable>(JSONCauHinhXuLy);
            Hashtable hashTableB = new Hashtable();
            foreach (DictionaryEntry tempEntryA in hashTableA)
            {
                Hashtable hashTableC = JsonConvert.DeserializeObject<Hashtable>(tempEntryA.Value.ToString());
                Hashtable hashTableD = new Hashtable();
                foreach (DictionaryEntry tempEntryC in hashTableC)
                {
                    List<string> dSXa = JsonConvert.DeserializeObject<List<string>>(tempEntryC.Value.ToString());
                    if (dSXa.Count > 0)
                    {
                        hashTableD.Add(tempEntryC.Key, dSXa);
                    }
                }
                if (hashTableD.Count > 0)
                {
                    hashTableB.Add(tempEntryA.Key, hashTableD);
                }
            }
            #endregion
            #region Tạo câu lệnh SQL thao tác với DataBase
            #region Delete
            //Delete QT_CONGVIECTHEOBUOC by BUOCQUYTRINHID
            //Delete QT_BUOCQT_CAUHINH by BUOCQUYTRINHID
            List<string> queryDeleteBuocQTCauHinh = new List<string>();
            List<string> queryDeleteCongViec = new List<string>();
            foreach (DictionaryEntry tempEntryA in hashTableA)
            {
                //Key hashTableA: BUOCQUYTRINHID;
                queryDeleteBuocQTCauHinh.Add("DELETE QT_BUOCQT_CAUHINH WHERE BUOCQUYTRINHID IN ('" + tempEntryA.Key + "');");
                queryDeleteCongViec.Add("DELETE QT_CONGVIECTHEOBUOC WHERE BUOCQUYTRINHID IN ('" + tempEntryA.Key + "');");
            }
            #endregion
            #region Insert QT_BUOCQT_CAUHINH
            List<string> queryInsertBuocQTCauHinh = new List<string>();
            foreach (DictionaryEntry tempEntryB in hashTableB)
            {
                Hashtable tempHTValue = (Hashtable)tempEntryB.Value;
                foreach (DictionaryEntry tempEntryHTValue in tempHTValue)
                {
                    List<string> dSXa = (List<string>)tempEntryHTValue.Value;
                    foreach (var tempXaID in dSXa)
                    {
                        queryInsertBuocQTCauHinh.Add("INSERT INTO QT_BUOCQT_CAUHINH(BUOCQTCAUHINHID, BUOCQUYTRINHID, NGUOIDUNGID, KVHCID) VALUES ('" + Guid.NewGuid().ToString() + "', '" + tempEntryB.Key + "', '" + tempEntryHTValue.Key + "', '" + tempXaID + "');");
                    }
                }
            }
            #endregion
            #region Insert QT_CONGVIECTHEOBUOC
            List<string> queryInsertCongViec = new List<string>();
            foreach (var tempBuocQuyTrinh in curQuyTrinh.DSBuocQuyTrinh)
            {
                if(tempBuocQuyTrinh.DSCongViecTheoBuoc != null)
                {
                    foreach (var tempCongViec in tempBuocQuyTrinh.DSCongViecTheoBuoc)
                    {
                        queryInsertCongViec.Add("INSERT INTO QT_CONGVIECTHEOBUOC(CONGVIECTHEOBUOCID, STT, TENCONGVIEC, BUOCQUYTRINHID) VALUES ('" + tempCongViec.CONGVIECTHEOBUOCID + "', '" + tempCongViec.STT + "', '" + tempCongViec.TENCONGVIEC + "', '" + tempBuocQuyTrinh.BUOCQUYTRINHID + "');");
                    }
                }
            }
            #endregion
            #endregion
            #region Save DataBase
            using (MplisEntities db = new MplisEntities())
            {
                #region Update QT_BUOCQUYTRINH
                foreach (var tempBuocQT in curQuyTrinh.DSBuocQuyTrinh)
                {
                    db.Entry(tempBuocQT).State = EntityState.Modified;
                }
                db.SaveChanges();
                #endregion
                #region Delete QT_BUOCQT_CAUHINH by BUOCQUYTRINHID
                if (queryDeleteBuocQTCauHinh.Count > 0)
                {
                    string sqlBatchDelBuocQTCH = "";
                    foreach (var tempQuery in queryDeleteBuocQTCauHinh)
                    {
                        sqlBatchDelBuocQTCH += tempQuery;
                    }
                    try
                    {
                        if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                            db.Database.Connection.Open();
                        DbCommand cmd = db.Database.Connection.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        sqlBatchDelBuocQTCH = "BEGIN " + sqlBatchDelBuocQTCH + " END; ";
                        cmd.CommandText = sqlBatchDelBuocQTCH;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        var err = ex;
                    }
                }
                #endregion
                #region Delete QT_CONGVIECTHEOBUOC by BUOCQUYTRINHID
                if (queryDeleteCongViec.Count > 0)
                {
                    string sqlBatchDelCongViec = "";
                    foreach (var tempQuery in queryDeleteCongViec)
                    {
                        sqlBatchDelCongViec += tempQuery;
                    }
                    try
                    {
                        if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                            db.Database.Connection.Open();
                        DbCommand cmd = db.Database.Connection.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        sqlBatchDelCongViec = "BEGIN " + sqlBatchDelCongViec + " END; ";
                        cmd.CommandText = sqlBatchDelCongViec;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        var err = ex;
                    }
                }
                #endregion
                #region Insert QT_BUOCQT_CAUHINH
                if (queryInsertBuocQTCauHinh.Count > 0)
                {
                    string sqlBatchInsert = "";
                    foreach (var tempQuery in queryInsertBuocQTCauHinh)
                    {
                        sqlBatchInsert += tempQuery;
                    }
                    try
                    {
                        if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                            db.Database.Connection.Open();
                        DbCommand cmd = db.Database.Connection.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        sqlBatchInsert = "BEGIN " + sqlBatchInsert + " END; ";
                        cmd.CommandText = sqlBatchInsert;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        var err = ex;
                    }
                }
                #endregion
                #region Insert QT_CONGVIECTHEOBUOC
                if (queryInsertCongViec.Count > 0)
                {
                    string sqlBatchInsertCongViec = "";
                    foreach (var tempQuery in queryInsertCongViec)
                    {
                        sqlBatchInsertCongViec += tempQuery;
                    }
                    try
                    {
                        if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                            db.Database.Connection.Open();
                        DbCommand cmd = db.Database.Connection.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        sqlBatchInsertCongViec = "BEGIN " + sqlBatchInsertCongViec + " END; ";
                        cmd.CommandText = sqlBatchInsertCongViec;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        var err = ex;
                    }
                }
                #endregion
            }
            #endregion
            curQuyTrinh.CauHinhXuLy = hashTableB;
            return true;
        }
    }
}

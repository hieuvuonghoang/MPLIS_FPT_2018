using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using System.Data.Entity;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using AutoMapper;
using System.Data.Common;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCBIENDONGServices
    {
        #region "Lấy toàn bộ dữ liệu biến động"
        public static DC_BIENDONG getBienDongByBienDongID(string BienDongID)
        {
            DC_BIENDONG ret;

            ret = getBienDong(BienDongID, true);
            ret = initInnerData(ref ret);

            return ret;
        }

        public static DC_BIENDONG getBienDongByHoSoID(string HoSoTiepNhanID)
        {
            DC_BIENDONG ret;
            ret = getBienDong(HoSoTiepNhanID, false);
            ret = initInnerData(ref ret);

            return ret;
        }

        private static DC_BIENDONG initInnerData(ref DC_BIENDONG ret)
        {
            if (ret == null) return null;

            //khởi tạo thông tin cho giấy chứng nhận
            foreach (var gcn in ret.DSGcn)
            {
                gcn.GiayChungNhan = DCGIAYCHUNGNHANServices.getGiayChungNhan(gcn.GIAYCHUNGNHANID);
            }

            ret.DSGcn = ret.DSGcn.OrderBy(i => i.SoPhatHanh).ToList();

            //khởi tạo thông tin cho chủ
            foreach (var ch in ret.DSChu)
            {
                ch.Chu = DCNGUOIServices.getChu(ch.NGUOIID);
            }
            ret.DSChu = ret.DSChu.OrderByDescending(i => i.VAITROCHU).ToList();

            //khởi tạo thông tin cho thua
            foreach (var th in ret.DSThua)
            {
                th.Thua = DCTHUADATServices.getThuaDat(th.THUADATID);
            }

            //khởi tạo thông tin riêng cho biến động
            ret.TheChapObj = DCBDTHECHAPServices.getTheChapByBienDongID(ret.BIENDONGID);

            ret.isInitData = true;

            return ret;
        }

        //isBienDongID == true get theo BIENDONGID, nguoc lai get theo HOSOTIEPNHANID
        private static DC_BIENDONG getBienDong(string ID, bool isBienDongID)
        {
            DC_BIENDONG ret = null;
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                if (isBienDongID)
                {
                    var retVal = (from bd in db.DC_BIENDONG.Where(i => i.BIENDONGID.Equals(ID))
                                  select new
                                  {
                                      bd,
                                      GCNs = db.DC_BD_GCN.Where(i => i.BIENDONGID.Equals(bd.BIENDONGID)),
                                      CHUs = db.DC_BD_CHU.Where(i => i.BIENDONGID.Equals(bd.BIENDONGID)),
                                      THUAs = db.DC_BD_THUA.Where(i => i.BIENDONGID.Equals(bd.BIENDONGID)),
                                      QD = db.DC_QUYETDINH.Where(i => i.QUYETDINHID.Equals(bd.QUYETDINHID)).FirstOrDefault()
                                  }).FirstOrDefault();
                    if (retVal != null)
                    {
                        ret = retVal.bd;
                        ret.DSGcn = retVal.GCNs.ToList();
                        ret.DSChu = retVal.CHUs.ToList();
                        ret.DSThua = retVal.THUAs.ToList();
                        ret.CurDC_QUYETDINH = retVal.QD;
                    }
                }
                else
                {
                    var retVal = (from bd in db.DC_BIENDONG.Where(i => i.HOSOTIEPNHANID.Equals(ID))
                                  select new
                                  {
                                      bd,
                                      GCNs = db.DC_BD_GCN.Where(i => i.BIENDONGID.Equals(bd.BIENDONGID)),
                                      CHUs = db.DC_BD_CHU.Where(i => i.BIENDONGID.Equals(bd.BIENDONGID)),
                                      THUAs = db.DC_BD_THUA.Where(i => i.BIENDONGID.Equals(bd.BIENDONGID)),
                                      QD = db.DC_QUYETDINH.Where(i => i.QUYETDINHID.Equals(bd.QUYETDINHID)).FirstOrDefault()
                                  }).FirstOrDefault();

                    if (retVal != null)
                    {
                        ret = retVal.bd;
                        ret.DSGcn = retVal.GCNs.ToList();
                        ret.DSChu = retVal.CHUs.ToList();
                        ret.DSThua = retVal.THUAs.ToList();
                        ret.CurDC_QUYETDINH = retVal.QD;
                    }
                }
            }

            return ret;
        }
        #endregion

        public static void updateTTBienDong(QT_HOSOTIEPNHAN hs)//truongnt
        {
            if (hs.BienDong != null)
            {
                if (hs.BienDong.DSChu != null)
                    updateDSChu(hs);
                if (hs.BienDong.DSGcn != null)
                {
                    updateDSGCN(hs);
                    updateDSThuaTuDSGCNVaoRa(hs);
                }
                if (hs.BienDong.DSThua != null)
                    updateDSThua(hs);
            }
        }
        public static bool saveAll(DC_BIENDONG bd)
        {
            throw new NotImplementedException();
        }

        public static void updateDSChu(QT_HOSOTIEPNHAN hs)
        {
            DC_BIENDONG objBD = hs.BienDong;
            if (objBD == null) return;
            if (objBD.DSChu != null && objBD.DSChu.Count > 0)
            {
                foreach (var it in objBD.DSChu)
                {
                    switch (it.Chu.LOAIDOITUONGID)
                    {
                        case "1":
                            it.Chu_TenLoaiChu = "Cá nhân";
                            if (it.Chu.CaNhan != null)
                            {
                                it.Chu_HoTen = it.Chu.CaNhan.HOTEN;
                                it.Chu_DiaChi = it.Chu.CaNhan.DIACHI;
                                if (it.Chu.CaNhan.DSGiayToTuyThan != null && it.Chu.CaNhan.DSGiayToTuyThan.Count > 0 && it.Chu.CaNhan.DSGiayToTuyThan[0] != null)
                                    it.Chu_CMT = it.Chu.CaNhan.DSGiayToTuyThan[0].SOGIAYTO;
                            }
                            break;
                        case "2":
                            it.Chu_TenLoaiChu = "Hộ gia đình";
                            if (it.Chu.HoGiaDinh.DSThanhVien != null)
                            {
                                it.Chu_DiaChi = it.Chu.HoGiaDinh.DIACHI;
                                foreach (var hgd in it.Chu.HoGiaDinh.DSThanhVien)
                                {
                                    it.Chu_HoTen += hgd.ThanhVien.HOTEN + ", ";
                                }
                                it.Chu_CMT = "";
                            }
                            break;
                        case "3":
                            it.Chu_TenLoaiChu = "Vợ chồng";
                            if (it.Chu.VoChong != null)
                            {
                                it.Chu_HoTen += it.Chu.VoChong.VoCN.HOTEN + ", " + it.Chu.VoChong.ChongCN.HOTEN;
                                it.Chu_DiaChi = it.Chu.VoChong.DIACHI;
                                if (it.Chu.VoChong.VoCN.DSGiayToTuyThan != null && it.Chu.VoChong.VoCN.DSGiayToTuyThan.Count > 0 && it.Chu.VoChong.VoCN.DSGiayToTuyThan[0] != null)
                                    it.Chu_CMT += it.Chu.VoChong.VoCN.DSGiayToTuyThan[0].SOGIAYTO + ", ";
                                if (it.Chu.VoChong.ChongCN.DSGiayToTuyThan != null && it.Chu.VoChong.ChongCN.DSGiayToTuyThan.Count > 0 && it.Chu.VoChong.ChongCN.DSGiayToTuyThan[0] != null)
                                    it.Chu_CMT += it.Chu.VoChong.ChongCN.DSGiayToTuyThan[0].SOGIAYTO;
                            }
                            break;
                        case "4":
                            it.Chu_TenLoaiChu = "Tổ Chức";
                            if (it.Chu.ToChuc != null)
                            {
                                it.Chu_DiaChi = it.Chu.ToChuc.DIACHI;
                                it.Chu_HoTen = it.Chu.ToChuc.TENTOCHUC;
                            }
                            break;
                        case "5":
                            it.Chu_TenLoaiChu = "Cộng đồng";
                            if (it.Chu.CongDong != null)
                            {
                                it.Chu_DiaChi = it.Chu.CongDong.DIACHI;
                                it.Chu_HoTen = it.Chu.CongDong.TENCONGDONG;
                            }
                            break;
                        case "6":
                            it.Chu_TenLoaiChu = "Nhóm người";
                            if (it.Chu.NhomNguoi != null)
                            {
                                it.Chu_DiaChi = "";//không có địa chỉ
                                if (it.Chu.NhomNguoi.DSThanhVien != null)
                                {
                                    foreach (var nn in it.Chu.NhomNguoi.DSThanhVien)
                                    {
                                        if (nn.ThanhVien != null)
                                            it.Chu_HoTen += nn.ThanhVien.HOTEN + ", ";
                                    }
                                }
                                it.Chu_CMT = "";//không biết lấy từ đâu
                            }
                            break;
                        default:
                            break;
                    }

                    //vai trò chủ trong thế chấp
                    switch (it.VAITROCHU)
                    {
                        case "T":
                            it.VaiTro = "Người thế chấp";
                            break;
                        case "N":
                            it.VaiTro = "Người nhận thế chấp";
                            break;
                        case "B":
                            it.VaiTro = "Người bảo lãnh";
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public static void updateDSGCN(QT_HOSOTIEPNHAN hs)
        {
            DC_BIENDONG objBD = hs.BienDong;
            if (objBD == null)
                return;
            if (objBD.DSGcn != null && objBD.DSGcn.Count > 0)
            {
                foreach (var it in objBD.DSGcn)
                {
                    it.SoPhatHanh = it.GiayChungNhan.SOPHATHANH;
                    it.MaVach = it.GiayChungNhan.MAVACH;
                    it.TrangThai = it.GiayChungNhan.TRANGTHAIXULY;
                    DCGIAYCHUNGNHANServices.updateTTGiayChungNhan(it.GiayChungNhan);
                }
            }
        }

        public static void updateDSThua(QT_HOSOTIEPNHAN hs)
        {
            DC_BIENDONG objBD = hs.BienDong;
            if (objBD == null) return;
            if (objBD.DSThua != null && objBD.DSThua.Count > 0)
            {
                foreach (var it in objBD.DSThua)
                {
                    it.DiaChi = it.Thua.DIACHITHUADAT;
                    it.XaPhuong = hs.TenKVHC;
                    it.SHToBanDo = it.Thua.SOHIEUTOBANDO;
                    it.STTThua = it.Thua.SOTHUTUTHUA;
                    it.DienTich = it.Thua.DIENTICH;
                }
                objBD.DSThua = objBD.DSThua.OrderBy(i => i.LOAITHUABD).ThenBy(i => i.SHToBanDo).ThenBy(i => i.STTThua).ToList();
            }
        }

        public static void updateDSThuaTuDSGCNVaoRa(QT_HOSOTIEPNHAN hs)
        {
            List<DC_BD_THUA> thuara = hs.BienDong.DSThua.Where(t => t.LOAITHUABD.Equals("R")).ToList();
            List<DC_BD_THUA> thuavao = hs.BienDong.DSThua.Where(t => t.LOAITHUABD.Equals("V")).ToList();
            DC_BD_THUA item;
            bool coThuaVao, coThuaRa;
            Hashtable dsThuaVaoRa = new Hashtable();

            using (MplisEntities db = new MplisEntities())
            {
                foreach (var gcn in hs.BienDong.DSGcn)
                {
                    //Thêm thửa chưa có trong danh sách vào ra
                    if (gcn.LAGCNVAO!=null && gcn.LAGCNVAO.Equals("Y"))
                    {
                        foreach (var thua in gcn.GiayChungNhan.DSQuyenSDDat)
                        {
                            //check thêm thửa đầu vào
                            coThuaVao = false;
                            foreach (var t in thuavao)
                                if (thua.THUADATID.Equals(t.THUADATID))
                                {
                                    coThuaVao = true;
                                    break;
                                }

                            //chưa có thửa trong GCN vào trong danh sách thửa vào của biến động, thêm mới vào danh sách quan hệ biến động - thửa
                            if (!coThuaVao)
                            {
                                item = new DC_BD_THUA();
                                item.BDTHUAID = Guid.NewGuid().ToString();
                                item.BIENDONGID = hs.BienDong.BIENDONGID;
                                item.THUADATID = thua.Thua.THUADATID;
                                item.DiaChi = thua.Thua.DIACHITHUADAT;
                                item.DienTich = thua.Thua.DIENTICHPHAPLY;
                                item.LOAITHUABD = "V";
                                item.SHToBanDo = thua.Thua.SOHIEUTOBANDO;
                                item.STTThua = thua.Thua.SOTHUTUTHUA;
                                item.Thua = thua.Thua;
                                item.XaPhuong = hs.TenKVHC;
                                thuavao.Add(item);
                                hs.BienDong.DSThua.Add(item);
                                db.Entry(item).State = EntityState.Added;
                            }
                            if (!dsThuaVaoRa.Contains(thua.THUADATID)) dsThuaVaoRa.Add(thua.THUADATID, thua.Thua);
                        }
                    }
                    else
                    {
                        foreach (var thua in gcn.GiayChungNhan.DSQuyenSDDat)
                        {
                            //check thêm thửa đầu ra
                            coThuaRa = false;
                            foreach (var t in thuara)
                                if (thua.THUADATID.Equals(t.THUADATID))
                                {
                                    coThuaRa = true;
                                    break;
                                }

                            //chưa có thửa trong GCN vào trong danh sách thửa ra của biến động, thêm mới vào danh sách quan hệ biến động - thửa
                            if (!coThuaRa)
                            {
                                item = new DC_BD_THUA();
                                item.BDTHUAID = Guid.NewGuid().ToString();
                                item.BIENDONGID = hs.BienDong.BIENDONGID;
                                item.THUADATID = thua.Thua.THUADATID;
                                item.DiaChi = thua.Thua.DIACHITHUADAT;
                                item.DienTich = thua.Thua.DIENTICHPHAPLY;
                                item.LOAITHUABD = "R";
                                item.SHToBanDo = thua.Thua.SOHIEUTOBANDO;
                                item.STTThua = thua.Thua.SOTHUTUTHUA;
                                item.Thua = thua.Thua;
                                item.XaPhuong = hs.TenKVHC;
                                thuara.Add(item);
                                hs.BienDong.DSThua.Add(item);
                                db.Entry(item).State = EntityState.Added;
                            }
                            if (!dsThuaVaoRa.Contains(thua.THUADATID)) dsThuaVaoRa.Add(thua.THUADATID, thua.Thua);
                        }
                    }
                }
                db.SaveChanges();

                //Xóa thửa không có trong danh sách thửa vào ra
                var arr = hs.BienDong.DSThua.ToList();
                foreach (var th in arr)
                {
                    if (th.THUADATID == null)
                    {
                        hs.BienDong.DSThua.Remove(th);
                        db.Entry(th).State = EntityState.Deleted;
                    }
                    else if (!th.LOAITHUABD.Equals("X") && !dsThuaVaoRa.Contains(th.THUADATID))
                    {
                        //Xóa quan hệ biến động - thửa
                        hs.BienDong.DSThua.Remove(th);
                        db.Entry(th).State = EntityState.Deleted;

                        //Xóa quan hệ thửa - thửa
                        if (th.Thua != null && th.Thua.QHThua != null)
                            foreach (var qh in th.Thua.QHThua)
                            {
                                db.Entry(qh).State = EntityState.Deleted;
                            }
                    }
                }
                db.SaveChanges();
            }
        }

        public static void updateTTChungBD(DC_BIENDONG bd)
        {
            throw new NotImplementedException();
        }

        public static void updateTTRiengBD(DC_BIENDONG bd)
        {
            throw new NotImplementedException();
        }

        #region "Xử lý và lưu thông tin biến động cùng các đối tượng liên quan"
        #region "Biến động"
        public static DC_BIENDONG AddNewBienDong(string HoSoTiepnhanID, string LoaiBienDongID)
        {
            DC_BIENDONG ret = new DC_BIENDONG();
            ret.BIENDONGID = Guid.NewGuid().ToString();
            ret.COTHUAXULY = "N";
            ret.HOSOTIEPNHANID = HoSoTiepnhanID;
            ret.LOAIBIENDONGID = LoaiBienDongID;
            using (MplisEntities db = new MplisEntities())
            {
                db.DC_BIENDONG.Add(ret);
                db.SaveChanges();
            }

            return ret;
        }

        public static void SaveDB_TTBIENDONG(TTChungBienDongVM formData, DC_BIENDONG bd)
        {
            //updateTTBienDong(formData, bd);
            if(bd.CurDC_QUYETDINH != null && bd.CurDC_QUYETDINH.isAdd)
            {
                formData.QUYETDINHID = bd.CurDC_QUYETDINH.QUYETDINHID;
            }
            Mapper.Map<TTChungBienDongVM, DC_BIENDONG>(formData, bd);
            using (MplisEntities db = new MplisEntities())
            {
                db.Entry(bd).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public static void SaveBienDong(DC_BIENDONG bienDong)
        {
            using(MplisEntities db = new MplisEntities())
            {
                db.Entry(bienDong).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        private static void updateTTBienDong(TTChungBienDongVM formData, DC_BIENDONG bd)
        {
            if (bd != null)
            {
                if (formData.LOAIBIENDONGID != null && formData.LOAIBIENDONGID != bd.LOAIBIENDONGID)
                {
                    using (MplisEntities db = new MplisEntities())
                    {
                        var cklbd = (from it in db.DC_LOAIBIENDONG.Where(c => c.LOAIBIENDONGID == formData.LOAIBIENDONGID)
                                     select it).FirstOrDefault();
                        if (cklbd != null)
                        {
                            formData.MABIENDONG = cklbd.MALOAIBIENDONG;
                            if (cklbd.MALOAIBIENDONG == "TC") formData.isCOTTRIENG = true;
                            else formData.isCOTTRIENG = false;
                        }
                    }
                }
                formData.QUYETDINHID = bd.QUYETDINHID;
                Mapper.Map<TTChungBienDongVM, DC_BIENDONG>(formData, bd);
            }
        }
        #endregion

        #region "Quyết đinh trong biến động"

        public static void SaveDB_QuyetDinh(QuyetDinhVM formData, BoHoSoModel bhs)
        {
            //Cập nhật lại Session
            Mapper.Map<QuyetDinhVM, DC_QUYETDINH>(formData, bhs.HoSoTN.BienDong.CurDC_QUYETDINH);
            //Lưu vào CSDL
            using (MplisEntities db = new MplisEntities())
            {
                if (bhs.HoSoTN.BienDong.CurDC_QUYETDINH.isAdd)
                {
                    //Thêm mới Quyết Định
                    bhs.HoSoTN.BienDong.CurDC_QUYETDINH.QUYETDINHID = Guid.NewGuid().ToString();
                    db.Entry(bhs.HoSoTN.BienDong.CurDC_QUYETDINH).State = EntityState.Added;
                }
                else
                {
                    //Cập nhật Quyết Định
                    db.Entry(bhs.HoSoTN.BienDong.CurDC_QUYETDINH).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
            
        }
        #endregion

        #region "Giấy chứng nhận trong biến động"
        public static void saveBDGCN(List<DC_BD_GCN> dsGCN, string BienDongID)
        {
            if (dsGCN != null && dsGCN.Count > 0)
            {
                using (MplisEntities db = new MplisEntities())
                {
                    if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                        db.Database.Connection.Open();
                    var trans = db.Database.Connection.BeginTransaction();
                    DbCommand cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from DC_BD_GCN where BIENDONGID = '" + BienDongID + "'";
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    DC_BD_GCN add;
                    foreach (var obj in dsGCN)
                    {
                        add = Mapper.Map<DC_BD_GCN, DC_BD_GCN>(obj);
                        db.Entry(add).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
        }

        public static void saveDSGCNCha(Hashtable DSGCNCha, List<DC_BD_GCN> dsGCN)
        {
            List<string> DSCha;
            DC_BD_GCN_GCN _add;
            if (DSGCNCha != null && DSGCNCha.Count > 0 && dsGCN != null && dsGCN.Count > 0)
            {
                using (MplisEntities db = new MplisEntities())
                {
                    foreach (var it in dsGCN)
                    {
                        if (it.LAGCNVAO.Equals("N") && DSGCNCha.Contains(it.GIAYCHUNGNHANID))
                        {
                            if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                                db.Database.Connection.Open();
                            var trans = db.Database.Connection.BeginTransaction();
                            DbCommand cmd = db.Database.Connection.CreateCommand();
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.CommandText = "delete from DC_BD_GCN_GCN where GIAYCHUNGNHANID = '" + it.GIAYCHUNGNHANID + "'";
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                            DSCha = ((JArray)DSGCNCha[it.GIAYCHUNGNHANID]).ToObject<List<string>>();
                            foreach (string id in DSCha)
                            {
                                _add = new DC_BD_GCN_GCN();
                                _add.BDGCNGCNID = Guid.NewGuid().ToString();
                                _add.GIAYCHUNGNHANID = it.GIAYCHUNGNHANID;
                                _add.GCNCHAID = id;
                                db.Entry(_add).State = EntityState.Added;
                                if (it.GiayChungNhan.QHGcn_Gcn == null)
                                    it.GiayChungNhan.QHGcn_Gcn = new List<DC_BD_GCN_GCN>();
                                it.GiayChungNhan.QHGcn_Gcn.Add(_add);
                            }
                            db.SaveChanges();
                        }
                    }
                }
            }
        }

        public static void RemoveGCNBD(BoHoSoModel bhs, string GCNBDID)
        {
            if (GCNBDID != null && !GCNBDID.Trim().Equals(""))
            {
                using (MplisEntities db = new MplisEntities())
                {
                    foreach (var it in bhs.HoSoTN.BienDong.DSGcn)
                    {
                        if (it.BDGCNID.Equals(GCNBDID))
                        {
                            //xóa bỏ quan hệ cha con giữa gcn đầu ra và gcn đầu vào đã xóa khỏi danh sách đầu vào
                            if (it.GiayChungNhan.TRANGTHAIXULY.Equals("Y"))
                            {
                                List<DC_BD_GCN> ls = bhs.HoSoTN.BienDong.DSGcn.Where(t => t.GiayChungNhan.TRANGTHAIXULY.Equals("S")).ToList();
                                foreach (var gcn in ls)
                                {
                                    var qhs = gcn.GiayChungNhan.QHGcn_Gcn.ToList();
                                    foreach (var qh in qhs)
                                    {
                                        if (qh.GCNCHAID.Equals(it.GIAYCHUNGNHANID))
                                        {
                                            gcn.GiayChungNhan.QHGcn_Gcn.Remove(qh);
                                            db.Entry(qh).State = EntityState.Deleted;
                                        }
                                    }
                                }
                                db.SaveChanges();
                            }
                            //Xóa quan hệ BD - GCN, GCN liên quan và các đối tượng liên quan GCN nếu GCN đang ở S
                            bhs.HoSoTN.BienDong.DSGcn.Remove(it);
                            db.Entry(it).State = EntityState.Deleted;
                            db.SaveChanges();
                            if (it.GiayChungNhan.TRANGTHAIXULY.Equals("S"))
                                DCGIAYCHUNGNHANServices.DeleteGiayChungNhan(it.GiayChungNhan);
                            break;
                        }
                    }
                    //Cập nhật lại ls_droplist_ttriengGCN cho bhs
                    bhs.initListTTRiengGCN();
                }
            }
        }

        public static void AddBienDongCreateNewGCN(BoHoSoModel bhs, string laGCNVao)
        {
            DC_GIAYCHUNGNHAN gcn = DCGIAYCHUNGNHANServices.CreateNewGCN();
            using (MplisEntities db = new MplisEntities())
            {
                DC_BD_GCN bdGCN = new DC_BD_GCN();
                bdGCN.BDGCNID = Guid.NewGuid().ToString();
                bdGCN.GiayChungNhan = gcn;
                bdGCN.GIAYCHUNGNHANID = gcn.GIAYCHUNGNHANID;
                bdGCN.BIENDONGID = bhs.HoSoTN.BienDong.BIENDONGID;
                bdGCN.LAGCNVAO = laGCNVao;
                bdGCN.SoPhatHanh = gcn.SOPHATHANH;
                bdGCN.MaVach = gcn.MAVACH;
                bdGCN.TrangThai = gcn.TRANGTHAIXULY;
                bhs.HoSoTN.BienDong.DSGcn.Add(bdGCN);
                db.Entry(bdGCN).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public static void AddBienDongGCNs(string[] DSGCNVAO_CHON, BoHoSoModel bhs)
        {
            bool daco;
            if (bhs == null) return;
            if (DSGCNVAO_CHON != null && DSGCNVAO_CHON.Count() > 0)
            {
                using (MplisEntities db = new MplisEntities())
                {
                    foreach (var dtid in DSGCNVAO_CHON)
                    {
                        //kiểm tra xem GCN muốn thêm đã có trong danh sách chưa
                        daco = false;
                        foreach (var gcn in bhs.HoSoTN.BienDong.DSGcn)
                        {
                            if (gcn.GIAYCHUNGNHANID.Equals(dtid))
                            {
                                daco = true;
                                break;
                            }
                        }

                        //Nếu chưa có thì thêm vào danh sách
                        if (!daco)
                            foreach (var it in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
                            {
                                if (it.GIAYCHUNGNHANID.Equals(dtid))
                                {
                                    //DCBIENDONGServices.AddBienDongGCN(bhs, it.GiayChungNhan, "Y");
                                    DC_BD_GCN bdGCN = new DC_BD_GCN();
                                    bdGCN.BDGCNID = Guid.NewGuid().ToString();
                                    bdGCN.GiayChungNhan = it.GiayChungNhan;
                                    bdGCN.GIAYCHUNGNHANID = it.GiayChungNhan.GIAYCHUNGNHANID;
                                    bdGCN.BIENDONGID = bhs.HoSoTN.BienDong.BIENDONGID;
                                    bdGCN.LAGCNVAO = "Y";
                                    bdGCN.SoPhatHanh = it.GiayChungNhan.SOPHATHANH;
                                    bdGCN.MaVach = it.GiayChungNhan.MAVACH;
                                    bdGCN.TrangThai = it.GiayChungNhan.TRANGTHAIXULY;
                                    bhs.HoSoTN.BienDong.DSGcn.Add(bdGCN);
                                    db.Entry(bdGCN).State = EntityState.Added;
                                    break;
                                }
                            }
                    }
                    db.SaveChanges();
                }
            }
        }
        #endregion

        #region "Thửa trong biến động"
        public static void addThuaXLVaoBienDong(string[] dsThua, BoHoSoModel bhs)
        {
            DC_BD_THUA bdThua;
            if (dsThua == null || dsThua.Count() == 0) return;
            using (MplisEntities db = new MplisEntities())
            {
                foreach (var idThua in dsThua)
                {
                    bdThua = bhs.HoSoTN.BienDong.DSThua.Where(i => i.THUADATID.Equals(idThua)).FirstOrDefault();
                    if (bdThua == null) //chưa có, tiến hành thêm mới
                    {
                        DC_DANGKY_THUA thuaDK = bhs.HoSoTN.DonDangKy.DSDangKyThua.Where(i => i.THUADATID.Equals(idThua)).FirstOrDefault();
                        if (thuaDK != null)
                        {
                            bdThua = new DC_BD_THUA();
                            bdThua.BDTHUAID = Guid.NewGuid().ToString();
                            bdThua.BIENDONGID = bhs.HoSoTN.BienDong.BIENDONGID;
                            bdThua.DiaChi = thuaDK.DiaChi;
                            bdThua.DienTich = thuaDK.DienTich;
                            bdThua.LoaiThua = thuaDK.Thua.LOAITHUADAT;
                            bdThua.LOAITHUABD = "X";
                            bdThua.SHToBanDo = thuaDK.SHToBanDo;
                            bdThua.STTThua = thuaDK.STTThua;
                            bdThua.THUADATID = thuaDK.THUADATID;
                            bdThua.XaPhuong = bhs.HoSoTN.TenKVHC;
                            db.Entry(bdThua).State = EntityState.Added;
                            bdThua.Thua = thuaDK.Thua;
                            bhs.HoSoTN.BienDong.DSThua.Add(bdThua);
                        }
                    }
                }
                bhs.HoSoTN.BienDong.COTHUAXULY = "Y";
                db.Entry(bhs.HoSoTN.BienDong).State = EntityState.Modified;
                db.SaveChanges();
                bhs.HoSoTN.BienDong.DSThua = bhs.HoSoTN.BienDong.DSThua.OrderByDescending(i => i.LOAITHUABD)
                    .ThenByDescending(i => i.SHToBanDo).ThenByDescending(i => i.STTThua).ToList();
            }
        }

        public static void RemoveThuaBD(BoHoSoModel bhs, string BDTHUAID)
        {
            if (BDTHUAID != null && !BDTHUAID.Trim().Equals(""))
            {
                using (MplisEntities db = new MplisEntities())
                {
                    foreach (var it in bhs.HoSoTN.BienDong.DSThua)
                    {
                        if (it.BDTHUAID.Equals(BDTHUAID))
                        {
                            //xóa bỏ quan hệ cha con giữa gcn đầu ra và gcn đầu vào đã xóa khỏi danh sách đầu vào
                            if (!it.Thua.LOAITHUADAT.Equals("S"))
                            {
                                List<DC_BD_THUA> ls = bhs.HoSoTN.BienDong.DSThua.Where(t => !t.Thua.LOAITHUADAT.Equals("Y")).ToList();
                                foreach (var gcn in ls)
                                {
                                    var qhs = gcn.Thua.QHThua.ToList();
                                    foreach (var qh in qhs)
                                    {
                                        if (qh.THUACHAID.Equals(it.THUADATID))
                                        {
                                            gcn.Thua.QHThua.Remove(qh);
                                            db.Entry(qh).State = EntityState.Deleted;
                                        }
                                    }
                                }
                                db.SaveChanges();
                            }
                            //Xóa quan hệ BD - thua, thua liên quan và các đối tượng liên quan
                            bhs.HoSoTN.BienDong.DSThua.Remove(it);
                            it.DC_BIENDONG = null;
                            it.DC_THUADAT = null;
                            db.Entry(it).State = EntityState.Deleted;
                            db.SaveChanges();
                            break;
                        }
                    }
                }
            }
        }

        public static void Savedb_DSTHUA(BoHoSoModel bhs, string COTHUAXULY, Hashtable dsThuaCha)
        {
            DbCommand cmd;
            DbTransaction trans;

            if (dsThuaCha != null && dsThuaCha.Count > 0 && bhs.HoSoTN.BienDong.DSThua != null && bhs.HoSoTN.BienDong.DSThua.Count > 0)
            {
                using (MplisEntities db = new MplisEntities())
                {
                    if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                        db.Database.Connection.Open();
                    bhs.HoSoTN.BienDong.COTHUAXULY = COTHUAXULY;
                    List<DC_BD_THUA> dsThuaXL = bhs.HoSoTN.BienDong.DSThua.Where(i => i.LOAITHUABD.Equals("X")).ToList();
                    List<DC_BD_THUA> dsThuaVao = bhs.HoSoTN.BienDong.DSThua.Where(i => i.LOAITHUABD.Equals("V")).ToList();
                    List<DC_BD_THUA> dsThuaRa = bhs.HoSoTN.BienDong.DSThua.Where(i => i.LOAITHUABD.Equals("R")).ToList();

                    //delete old data
                    string thuaIDs = "";
                    foreach (var thua in dsThuaRa)
                    {
                        thuaIDs = thuaIDs + ",'" + thua.THUADATID + "'";
                        thua.Thua.QHThua.Clear();
                    }
                    foreach (var thua in dsThuaXL)
                    {
                        thuaIDs = thuaIDs + ",'" + thua.THUADATID + "'";
                        thua.Thua.QHThua.Clear();
                    }
                    thuaIDs = thuaIDs.Substring(1, thuaIDs.Length - 1);
                    trans = db.Database.Connection.BeginTransaction();
                    cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from DC_BD_THUA_THUA where THUADATID in (" + thuaIDs + ")";
                    int numrow = cmd.ExecuteNonQuery();
                    trans.Commit();
                    trans.Dispose();

                    //xử lý với thửa xử lý
                    if (bhs.HoSoTN.BienDong.COTHUAXULY != null && bhs.HoSoTN.BienDong.COTHUAXULY.Equals("Y"))
                    {
                        checkAndAddThuaCha(dsThuaXL, dsThuaVao, dsThuaCha, db);
                        checkAndAddThuaCha(dsThuaRa, dsThuaXL, dsThuaCha, db);
                    }
                    else
                    {
                        checkAndAddThuaCha(dsThuaRa, dsThuaVao, dsThuaCha, db);
                    }

                    //update biến động
                    db.Entry(bhs.HoSoTN.BienDong).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private static void checkAndAddThuaCha(List<DC_BD_THUA> dsThuaCon, List<DC_BD_THUA> dsThuaCha, Hashtable dsThuaChaID, MplisEntities db)
        {
            DC_BD_THUA_THUA _add;
            List<string> DSCha;
            DC_BD_THUA cha;
            Hashtable _dsCha = new Hashtable();

            foreach (var thua in dsThuaCon)
            {
                DSCha = ((JArray)dsThuaChaID[thua.THUADATID]).ToObject<List<string>>();
                if (DSCha.Count() > 0)
                {
                    foreach (string id in DSCha)
                    {
                        if (!_dsCha.Contains(thua.THUADATID + id))
                        {
                            _dsCha.Add(thua.THUADATID + id, thua.THUADATID + id);
                            cha = dsThuaCha.Where(i => i.THUADATID.Equals(id)).FirstOrDefault();
                            if (cha != null)
                            {
                                _add = new DC_BD_THUA_THUA();
                                _add.BDTHUATHUAID = Guid.NewGuid().ToString();
                                _add.THUACHAID = id;
                                _add.THUADATID = thua.THUADATID;
                                db.Entry(_add).State = EntityState.Added;
                                thua.Thua.QHThua.Add(_add);
                            }
                        }
                    }
                    db.SaveChanges();
                }
            }
        }
        #endregion

        #region "Thông tin riêng biến động"
        #region "Chủ tham gia thế chấp"
        public static void addChuVaoBienDong(string[] dsChu, string LoaiChu, BoHoSoModel bhs)
        {
            bool DaCo;
            DC_BD_CHU bdChu;
            using (MplisEntities db = new MplisEntities())
            {
                foreach (var idChu in dsChu)
                {
                    DaCo = false;
                    foreach (var it in bhs.HoSoTN.BienDong.DSChu)
                    {
                        if (it.NGUOIID.Equals(idChu))
                        {
                            DaCo = true;
                            break;
                        }
                    }
                    if (!DaCo)
                    {
                        DC_DANGKY_NGUOI chuDK = null;
                        foreach (var ch in bhs.HoSoTN.DonDangKy.DSDangKyChu)
                        {
                            if (ch.NGUOIID.Equals(idChu))
                            {
                                chuDK = ch;
                                break;
                            }
                        }
                        if (chuDK != null)
                        {
                            bdChu = new DC_BD_CHU();
                            bdChu.BDCHUID = Guid.NewGuid().ToString();
                            bdChu.BIENDONGID = bhs.HoSoTN.BienDong.BIENDONGID;
                            bdChu.Chu = chuDK.Chu;
                            bdChu.Chu_CMT = chuDK.Chu_CMT;
                            bdChu.Chu_DiaChi = chuDK.Chu_DiaChi;
                            bdChu.Chu_HoTen = chuDK.Chu_HoTen;
                            bdChu.Chu_TenLoaiChu = chuDK.Chu_TenLoaiChu;
                            bdChu.NGUOIID = chuDK.NGUOIID;
                            bdChu.VAITROCHU = LoaiChu;
                            db.Entry(bdChu).State = EntityState.Added;
                            switch (LoaiChu)
                            {
                                case "T":
                                    bdChu.VaiTro = "Người thế chấp";
                                    break;
                                case "N":
                                    bdChu.VaiTro = "Người nhận thế chấp";
                                    break;
                                case "B":
                                    bdChu.VaiTro = "Người bảo lãnh";
                                    break;
                                default:
                                    break;
                            }
                            bhs.HoSoTN.BienDong.DSChu.Add(bdChu);
                            bhs.HoSoTN.BienDong.DSChu = bhs.HoSoTN.BienDong.DSChu.OrderByDescending(i => i.VAITROCHU).ToList();
                        }
                    }
                }
                db.SaveChanges();
            }
        }

        public static void removeChuTrongBD(string idChu, BoHoSoModel bhs)
        {
            using (MplisEntities db = new MplisEntities())
            {
                for (int i = bhs.HoSoTN.BienDong.DSChu.Count - 1; i >= 0; i--)
                {
                    if (bhs.HoSoTN.BienDong.DSChu[i].NGUOIID.Equals(idChu))
                    {
                        db.Entry(bhs.HoSoTN.BienDong.DSChu[i]).State = EntityState.Deleted;
                        bhs.HoSoTN.BienDong.DSChu.RemoveAt(i);
                        db.SaveChanges();
                        break;
                    }
                }

            }
        }

        //public static void detailsChuTrongBD(string idChu, BoHoSoModel bhs)
        //{
        //    using(MplisEntities db = new MplisEntities())
        //    {
        //        for(int i = bhs.HoSoTN.BienDong.DSChu.Count - 1; i >= 0; i--)
        //        {
        //            db.Entry(bhs.HoSoTN.BienDong.DSChu[i].DC_NGUOI)
        //        }
        //    }
        //}

        public static void SaveDB_DSChu(BoHoSoModel bhs)
        {
            if (bhs.HoSoTN.BienDong.DSChu.Count > 0)
            {
                using (MplisEntities db = new MplisEntities())
                {
                    if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                        db.Database.Connection.Open();
                    var trans = db.Database.Connection.BeginTransaction();
                    DbCommand cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from DC_BD_CHU where BIENDONGID = '" + bhs.HoSoTN.BienDong.BIENDONGID + "'";
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    foreach (var obj in bhs.HoSoTN.BienDong.DSChu)
                    {
                        obj.DC_BIENDONG = null;
                        db.Entry(obj).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
        }
        #endregion
        #region "Thông tin riêng thế chấp"
        public static void SaveDB_TTRIENG(TheChapVM formData, BoHoSoModel bhs)
        {
            using (MplisEntities db = new MplisEntities())
            {
                if (formData.BDTHECHAPID == null || formData.BDTHECHAPID.Equals(""))//themmoi
                {
                    Mapper.Map<TheChapVM, DC_BD_THECHAP>(formData, bhs.HoSoTN.BienDong.TheChapObj);
                    //bhs.HoSoTN.BienDong.TheChapObj = formData;
                    bhs.HoSoTN.BienDong.TheChapObj.BDTHECHAPID = Guid.NewGuid().ToString();
                    bhs.HoSoTN.BienDong.TheChapObj.BIENDONGID = bhs.HoSoTN.BienDong.BIENDONGID;
                    db.Entry(bhs.HoSoTN.BienDong.TheChapObj).State = EntityState.Added;
                }
                else //edit
                {
                    Mapper.Map<TheChapVM, DC_BD_THECHAP>(formData, bhs.HoSoTN.BienDong.TheChapObj);
                    db.Entry(bhs.HoSoTN.BienDong.TheChapObj).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
        }
        #endregion
        #region "Quyền thế chấp"
        public static void SaveDB_TTRIENG_CTQUYEN(QuyenDatQuyenSHTSJson quyenDatQuyenSHTSJson, BoHoSoModel bhs)
        {
            using (MplisEntities db = new MplisEntities())
            {
                int indexGCN = bhs.HoSoTN.BienDong.DSGcn.FindIndex(it => it.GIAYCHUNGNHANID == quyenDatQuyenSHTSJson.GiayChungNhanID);
                if (indexGCN != -1 && quyenDatQuyenSHTSJson.DSQuyen.Count > 0)
                {
                    int indexQSDDAT;
                    int indexQTS;
                    int indexQQLDat;
                    foreach (var temp in quyenDatQuyenSHTSJson.DSQuyen)
                    {
                        indexQSDDAT = -1;
                        indexQTS = -1;
                        indexQQLDat = -1;
                        switch (temp.ISQuyen)
                        {
                            case "QSDDAT":
                                //Cập nhật lại Session["BoHoSo_" + CurrentUser.UserName]
                                indexQSDDAT = bhs.HoSoTN.BienDong.DSGcn[indexGCN].GiayChungNhan.DSQuyenSDDat.FindIndex(it => it.QUYENSUDUNGDATID == temp.IDQuyen);
                                if (indexQSDDAT != -1)
                                    bhs.HoSoTN.BienDong.DSGcn[indexGCN].GiayChungNhan.DSQuyenSDDat[indexQSDDAT].TRANGTHAIPL = temp.TrangThaiPL ? "T" : "";
                                //Cập nhật trạng thái pháp lý vào bảng DC_QUYENSUDUNGDAT
                                var objQSDDat = db.DC_QUYENSUDUNGDAT.Where(it => it.QUYENSUDUNGDATID == temp.IDQuyen).FirstOrDefault();
                                objQSDDat.TRANGTHAIPL = temp.TrangThaiPL ? "T" : "";
                                db.Entry(objQSDDat).State = EntityState.Modified;
                                break;
                            case "QTS":
                                //Cập nhật lại Session["BoHoSo_" + CurrentUser.UserName]
                                indexQTS = bhs.HoSoTN.BienDong.DSGcn[indexGCN].GiayChungNhan.DSQuyenSHTS.FindIndex(it => it.QUYENSOHUUTAISANID == temp.IDQuyen);
                                if (indexQTS != -1)
                                    bhs.HoSoTN.BienDong.DSGcn[indexGCN].GiayChungNhan.DSQuyenSHTS[indexQTS].TRANGTHAIPL = temp.TrangThaiPL ? "T" : "";
                                //Cập nhật trạng thái pháp lý vào bảng DC_QUYENSOHUUTAISAN
                                var objQTS = db.DC_QUYENSOHUUTAISAN.Where(it => it.QUYENSOHUUTAISANID == temp.IDQuyen).FirstOrDefault();
                                objQTS.TRANGTHAIPL = temp.TrangThaiPL ? "T" : "";
                                db.Entry(objQTS).State = EntityState.Modified;
                                break;
                            case "QQLDAT":
                                //Cập nhật lại Session["BoHoSo_" + CurrentUser.UserName]
                                indexQQLDat = bhs.HoSoTN.BienDong.DSGcn[indexGCN].GiayChungNhan.DSQuyenQLDat.FindIndex(it => it.QUYENQUANLYDATID == temp.IDQuyen);
                                if (indexQSDDAT != -1)
                                    bhs.HoSoTN.BienDong.DSGcn[indexGCN].GiayChungNhan.DSQuyenSDDat[indexQSDDAT].TRANGTHAIPL = temp.TrangThaiPL ? "T" : "";
                                //Cập nhật trạng thái pháp lý vào bảng DC_QUYENSUDUNGDAT
                                var objQQLDat = db.DC_QUYENQUANLYDAT.Where(it => it.QUYENQUANLYDATID == temp.IDQuyen).FirstOrDefault();
                                objQQLDat.TRANGTHAIPL = temp.TrangThaiPL ? "T" : "";
                                db.Entry(objQQLDat).State = EntityState.Modified;
                                break;
                            default:
                                break;
                        }
                    }
                }
                db.SaveChanges();
            }
        }
        #endregion
        #endregion

        #endregion
        #region Tìm kiếm quyết định
        public static List<DC_QUYETDINH> getQuyetDinh(string soQuyetDinh)
        {
            List<DC_QUYETDINH> dSQuyetDinh = new List<DC_QUYETDINH>();
            using (MplisEntities db = new MplisEntities())
            {
                var result = db.DC_QUYETDINH.Where(it => it.SOQUYETDINH.Equals(soQuyetDinh)).ToList();
                if(result != null)
                {
                    dSQuyetDinh = result;
                }
            }
            return dSQuyetDinh;
        }
        #endregion

        #region HieuVH2
        public static bool SaveBienDongDSGCN(DC_BIENDONG bienDong, out string mes)
        {
            try
            {
                using (MplisEntities db = new MplisEntities())
                {
                    if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                                || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                        db.Database.Connection.Open();
                    DbCommand cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "DELETE FROM DC_BD_GCN WHERE BIENDONGID IN ('" + bienDong.BIENDONGID + "')";
                    cmd.ExecuteNonQuery();

                    foreach(var temp in bienDong.DSGcn)
                    {
                        if(temp.GiayChungNhan.TRANGTHAI != 0)
                        {
                            DCGIAYCHUNGNHANServices.SaveGiayChungNhan(temp.GiayChungNhan, db, out mes);
                        }
                        db.Entry(Mapper.Map<DC_BD_GCN, DC_BD_GCN>(temp)).State = EntityState.Added;
                    }

                    db.SaveChanges();
                }
            } catch (Exception ex)
            {
                mes = ex.Message;
                return false;
            }
            mes = "Lưu thông tin vào CSDL thành công!";
            return true;
        }
        #endregion
    }
}
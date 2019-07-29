using AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;
using AutoMapper;
namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class VM_XuLyHoSo_BD /*:AppCore.Models.DC_BIENDONG*/
    {
        public DC_BIENDONG CurDC_BienDong { get; set; }
        public List<list_DSLienQuanBD> dsChiTietTheChap { get; set; }
        public List<list_Droplist> ls_droplist_ttriengGCN { get; set; }
        public List<DC_LOAIBIENDONG> DS_LoaiBienDong { get; set; }

        public List<list_DSLienQuanBD> list_DoiTuong_xoa { get; set; }
        public List<list_DSLienQuanBD> list_DSCTTheChap { get; set; }
        public List<list_Droplist> list_Droplist_TTGCNDangKy { get; set; }
        public string _LuuQD = "", _LuuCHU = "", _XoaCHU = "", _LuuGCN = "", _XoaGCN = "", _XoaTHUA = "", _LuuTHUA = "";

        public VM_XuLyHoSo_BD()
        {
            list_DoiTuong_xoa = new List<Models.list_DSLienQuanBD>();
            list_DSCTTheChap = new List<Models.list_DSLienQuanBD>();
            list_Droplist_TTGCNDangKy = new List<Models.list_Droplist>();
        }
    }
    public class list_DSLienQuanBD
    {
        public list_DSLienQuanBD(string DoiTuong, string DoiTuongID, string LOAIVAO_RA, string TinhTrangPL,
            bool EnableCheck, string s1, string s2, string s3,
            string s4, string s5, string s6, string s7, string s8)
        {
            this.DoiTuong = DoiTuong;
            this.DoiTuongID = DoiTuongID;
            this.LOAIVAO_RA = LOAIVAO_RA;
            this.TinhTrangPL = false;
            if(TinhTrangPL != null && TinhTrangPL.Equals("T"))
            {
                this.TinhTrangPL = true;
            }
            this.EnableCheck = EnableCheck;
            this.s1 = s1;
            this.s2 = s2;
            this.s3 = s3;
            this.s4 = s4;
            this.s5 = s5;
            this.s6 = s6;
            this.s7 = s7;
            this.s8 = s8;
        }
        public string DoiTuong { get; set; }
        public string DoiTuongID { get; set; }
        public string LOAIVAO_RA { get; set; }
        public bool TinhTrangPL { get; set; }
        public bool EnableCheck { get; set; }
        public string s1 { get; set; }
        public string s2 { get; set; }
        public string s3 { get; set; }
        public string s4 { get; set; }
        public string s5 { get; set; }
        public string s6 { get; set; }
        public string s7 { get; set; }
        public string s8 { get; set; }
    }
    public class list_Droplist
    {
        public list_Droplist(string ID, string NAME)
        {
            this.ID = ID;
            this.NAME = NAME;
        }
        public string ID { get; set; }
        public string NAME { get; set; }
    }
    public class VM_XuLyHoSo_GCN
    {
        public string _BienDongID { get; set; }
        public string _HoSoTiepNhanID { get; set; }
        public DC_DONDANGKY DonDangKy { get; set; }
        public DC_GIAYCHUNGNHAN CurDC_GIAYCHUNGNHAN { get; set; }
        //public List<DC_MUCDICHSUDUNGDAT> DsDC_MUCDICHSUDUNGDAT { get; set; }
        //public List<DC_TAISANGANLIENVOIDAT> DsDC_TAISANGANLIENVOIDAT { get; set; }
        public List<list_DSLienQuanBD> list_DSQuyenSDDAT { get; set; }
        public List<list_DSLienQuanBD> list_DSQuyenSHTAISAN { get; set; }
        // public DC_QUYENSUDUNGDAT CurDC_QUYENSUDUNGDAT { get; set; }
        // public DC_QUYENSOHUUTAISAN CurDC_QUYENSOHUUTAISAN { get; set; }
    }
    public class VM_XuLyHoSo_DK
    {
       
        public string DONDANGKYID { get; set; }
        public List<DC_DANGKY_NGUOI> CHU_DANGKY = new List<DC_DANGKY_NGUOI>();
        public List<DC_DANGKY_THUA> THUA_DANGKY = new List<DC_DANGKY_THUA>();
        public List<VM_GCN_DK> GCN_DANGKY = new List<VM_GCN_DK>();
        public List<DC_DANGKY_GCN> GCN_DK= new List<DC_DANGKY_GCN>();
        public string ADD_GCN_MAVACH { get; set; }
        public string ADD_GCN_SOPHATHANH { get; set; }
        // public DC_DONDANGKY CurDC_DONDANGKY { get; set; }
        public List<DC_DANGKY_TAISAN> TAISAN_DANGKY = new List<DC_DANGKY_TAISAN>();
        public DangKyTaiSan HienThiDangKyTaiSan = new DangKyTaiSan();
        public Hashtable DSTSThua { get; set; }
        private string _JSONTSThua = "";
        public Hashtable DSCanHoHM { get; set; }
        private string _JSONCanHoHM = "";
        public string JSONTSThua
        {
            get
            {
                if (_JSONTSThua.Equals(""))
                    return JsonConvert.SerializeObject(DSTSThua);
                else return _JSONTSThua;
            }

            set
            {
                _JSONTSThua = value;
            }
        }
        public string JSONCanHoHM
        {
            get
            {
                if (_JSONCanHoHM.Equals(""))
                    return JsonConvert.SerializeObject(DSCanHoHM);
                else return _JSONCanHoHM;
            }

            set
            {
                _JSONCanHoHM = value;
            }
        }
        public VM_XuLyHoSo_DK()
        {
            DSTSThua = new Hashtable();
            DSCanHoHM = new Hashtable();
        }

        public void initData(BoHoSoModel bhs)
        {
            List<string> DSThuaqh;
            List<string> DSCanHoqh;
            TAISAN_DANGKY = bhs.HoSoTN.DonDangKy.DSDangKyTaiSan;
            THUA_DANGKY = bhs.HoSoTN.DonDangKy.DSDangKyThua;
            GCN_DK = bhs.HoSoTN.DonDangKy.DSDangKyGCN;
            foreach (var it in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (!DSTSThua.Contains(it.TAISANID))
                {
                    DSThuaqh = new List<string>();
                    if (it.TaiSanGanLienVoiDat != null)
                    {
                        for (int i = 0; i < it.TaiSanGanLienVoiDat.DSThua.Count; i++)
                        {
                            DSThuaqh.Add(it.TaiSanGanLienVoiDat.DSThua[i].THUADATID);
                        }
                        DSTSThua.Add(it.TAISANID, DSThuaqh);
                    }

                }
            }
            foreach (var it in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (!DSCanHoHM.Contains(it.TAISANID))
                {
                    DSCanHoqh = new List<string>();
                    if (it.TaiSanGanLienVoiDat != null)
                    {
                        if (it.TaiSanGanLienVoiDat.CanHo != null)
                        {
                            for (int i = 0; i < it.TaiSanGanLienVoiDat.DSHangMuc.Count; i++)
                            {
                                DSCanHoqh.Add(it.TaiSanGanLienVoiDat.DSHangMuc[i].HANGMUCSOHUUCHUNGID);
                            }
                            DSCanHoHM.Add(it.TaiSanGanLienVoiDat.CanHo.CANHOID, DSCanHoqh);
                        }
                    }
                }
            }
        }
    }
    public class VM_GCN_DK
    {
        public string gcnid { get; set; }
        public string mavach { get; set; }
        public string sophathanh { get; set; }
        public string trangthai { get; set; }

    }
    public class VM_SAVE
    {
        public bool save { get; set; }
        public BoHoSoModel bhs { get; set; }
    }
    public class VM_CHU_DK
    {
        public VM_CHU_DK()
        {
            lst_ChuCaNhan = new List<Models.DangKyChuCaNhan>();
            lst_HoGiaDinh = new List<Models.DangKyChuHoGiaDinh>();
            lst_VoChong = new List<Models.DangKyChuVoChong>();
            lst_ToChuc = new List<Models.DangKyToChuc>();
            lst_CongDong = new List<Models.DangKyChuCongDong>();
            TRANGTHAI = 0;
        }
        public string nguoiid { get; set; }
        public string loaichu { get; set; }
        public string tenchu { get; set; }
        public string cmt { get; set; }
        public string LOAICHUID { get; set; }
        public string DONDANGKYID { get; set; }
        
        public List<DangKyChuCaNhan> lst_ChuCaNhan { get; set; }
        public List<DangKyChuHoGiaDinh> lst_HoGiaDinh { get; set; }
        public List<DangKyChuVoChong> lst_VoChong { get; set; }
        public List<DangKyToChuc> lst_ToChuc { get; set; }
        public List<DangKyChuCongDong> lst_CongDong { get; set; }
        //trạng thái thêm/sửa/xóa đối tượng : 
        // mặc định là 0 : không thay đổi
        // mặc định là 1 : thêm
        // mặc định là 2 : sửa
        // mặc định là 3 : xóa
        public int TRANGTHAI { get; set; }

    }
}

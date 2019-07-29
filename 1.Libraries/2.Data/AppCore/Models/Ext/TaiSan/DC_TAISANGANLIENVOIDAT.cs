using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_TAISANGANLIENVOIDAT
    {
        /*
        1	Nhà ở riêng lẻ
        2	Khu nhà chung cư, nhà hỗn hợp
        3	Nhà chung cư 
        4	Căn hộ
        5	Hạng mục sở hữu chung ngoài căn hộ
        6	Công trình xây dựng
        7	Công trình ngầm
        8	Hạng mục của công trình xây dựng
        9	Rừng sản xuất là rừng trồng
        10	Cây lâu năm
        */
        public DM_LOAITAISANGANLIENVOIDAT LoaiTaiSanGanLienVoiDat { get; set; }
        public DC_NHARIENGLE NhaRiengLe { get; set; }
        public DC_CANHO CanHo { get; set; }
        public DC_CONGTRINHXAYDUNG CongTrinhXayDung { get; set; }
        public DC_RUNGTRONG RungTrong { get; set; }
        public DC_CAYLAUNAM CayLauNam { get; set; }
        public DC_CONGTRINHNGAM CongTrinhNgam { get; set; }
        public DC_NHACHUNGCU NhaChungCu { get; set; }
        public DC_HANGMUCNGOAICANHO HangMucNgoaiCanHo { get; set; }
        public DC_HANGMUCCONGTRINH HangMucCongTrinh { get; set; }
        public DC_KHUCHUNGCU KhuChungCu { get; set; }
        public DC_NGUOI Chu { get; set; }
        public List<DC_THUATAISAN> DSThua { get; set; }
        public List<DC_CANHO_HANGMUCNCH> DSHangMuc { get; set; }
        public DC_DIACHI diachitaisan { get; set; }
        public string DSTSThua
        {
            get
            {
                string s = "";
                if (DSThua != null)
                    for (int i = 0; i < DSThua.Count; i++)
                    {
                        s = s + DSThua[i].THUADATID + ",";
                    }

                if (s.Length > 0) s = s.Substring(0, s.Length - 1);

                return s;
            }

            set
            {
                if (DSThua == null) DSThua = new List<Models.DC_THUATAISAN>();
                else DSThua.Clear();
                DC_THUATAISAN item;
                string[] arrIDCha;
                if (value.Length > 0)
                {
                    arrIDCha = value.Split(',');
                    for (int i = 0; i < arrIDCha.Length; i++)
                    {
                        item = new Models.DC_THUATAISAN();
                        item.THUATAISANID = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                        item.TAISANGANLIENVOIDATID = TAISANGANLIENVOIDATID;
                        item.THUADATID = arrIDCha[i];
                        DSThua.Add(item);
                    }
                }
            }
        }
        public string DSCHHM
        {
            get
            {
                string s = "";
                if (DSHangMuc != null)
                    for (int i = 0; i < DSHangMuc.Count; i++)
                    {
                        s = s + DSHangMuc[i].HANGMUCSOHUUCHUNGID + ",";
                    }

                if (s.Length > 0) s = s.Substring(0, s.Length - 1);

                return s;
            }

            set
            {
                if (DSHangMuc == null) DSHangMuc = new List<Models.DC_CANHO_HANGMUCNCH>();
                else DSHangMuc.Clear();
                DC_CANHO_HANGMUCNCH item;
                string[] arrIDCha;
                if (value.Length > 0)
                {
                    arrIDCha = value.Split(',');
                    for (int i = 0; i < arrIDCha.Length; i++)
                    {
                        item = new Models.DC_CANHO_HANGMUCNCH();
                        item.CANHOID = CanHo.CANHOID;
                        item.HANGMUCSOHUUCHUNGID = arrIDCha[i];
                        DSHangMuc.Add(item);
                    }
                }
            }
        }
        public void getData()
        {
            using (MplisEntities db = new MplisEntities())
            {
                switch (LOAITAISAN)
                {
                    case "1"://DC_NHARIENGLE
                        var objNRL = db.DC_NHARIENGLE.Where(it => it.NHARIENGLEID.Equals(TAISANID)).FirstOrDefault();
                        if (objNRL != null)
                        {
                            NhaRiengLe = objNRL;
                            DienTich = objNRL.DIENTICHXAYDUNG ?? 0.0M;
                            TENTAISAN = "";
                            if (objNRL.CO_HSXN_NHADUYNHAT == "Y")
                            {
                                NhaRiengLe._CO_HSXN_NHADUYNHAT = true;
                            }
                            else
                            {
                                NhaRiengLe._CO_HSXN_NHADUYNHAT = false;
                            }
                        }
                        break;
                    case "2"://DC_NHACHUNGCU
                        var objKCC = db.DC_KHUCHUNGCU.Where(it => it.KHUCHUNGCUID.Equals(TAISANID)).FirstOrDefault();
                        if (objKCC != null)
                        {
                            KhuChungCu = objKCC;
                            DienTich = objKCC.DIENTICHKHU ?? 0.0M;
                            TENTAISAN = objKCC.TENKHU;
                        }
                        break;
                    case "3":
                        var objCC = db.DC_NHACHUNGCU.Where(it => it.NHACHUNGCUID.Equals(TAISANID)).FirstOrDefault();
                        if (objCC != null)
                        {
                            NhaChungCu = objCC;
                            DienTich = objCC.DIENTICHXAYDUNG ?? 0.0M; ;
                            TENTAISAN = objCC.TENCHUNGCU;
                        }
                        break;
                    case "4"://DC_CANHO
                        var objCH = db.DC_CANHO.Where(it => it.CANHOID.Equals(TAISANID)).FirstOrDefault();
                        if (objCH != null)
                        {
                            CanHo = objCH;
                            DienTich = objCH.DIENTICHSAN ?? 0.0M;
                            TENTAISAN = CanHo.SOHIEUCANHO;
                            if (objCH.CO_HSXN_NHADUYNHAT == "Y")
                            {
                                CanHo._CO_HSXN_NHADUYNHAT = true;
                            }
                            else
                            {
                                CanHo._CO_HSXN_NHADUYNHAT = false;
                            }
                        }
                        break;
                    case "5"://DC_HANGMUCNGOAICANHO
                        var objHMNCH = db.DC_HANGMUCNGOAICANHO.Where(it => it.HANGMUCSOHUUCHUNGID.Equals(TAISANID)).FirstOrDefault();
                        if (objHMNCH != null)
                        {
                            HangMucNgoaiCanHo = objHMNCH;
                            DienTich = objHMNCH.DIENTICH ?? 0.0M;
                            TENTAISAN = HangMucNgoaiCanHo.TENHANGMUC;
                        }
                        break;
                    case "6"://DC_CONGTRINHXAYDUNG
                        var objCTXD = db.DC_CONGTRINHXAYDUNG.Where(it => it.CONGTRINHXAYDUNGID.Equals(TAISANID)).FirstOrDefault();
                        if (objCTXD != null)
                        {
                            CongTrinhXayDung = objCTXD;
                            DienTich = objCTXD.DIENTICHXAYDUNG ?? 0.0M;
                            TENTAISAN = CongTrinhXayDung.TENCONGTRINH;
                        }
                        break;
                    case "7"://DC_CONGTRINHNGAM
                        var objCTN = db.DC_CONGTRINHNGAM.Where(it => it.CONGTRINHNGAMID.Equals(TAISANID)).FirstOrDefault();
                        if (objCTN != null)
                        {
                            CongTrinhNgam = objCTN;
                            DienTich = objCTN.DIENTICHCONGTRINH ?? 0.0M; ;
                            TENTAISAN = CongTrinhNgam.TENCONGTRINH;
                        }
                        break;
                    case "8"://DC_HANGMUCCONGTRINH
                        var objHMCT = db.DC_HANGMUCCONGTRINH.Where(it => it.HANGMUCCONGTRINHID.Equals(TAISANID)).FirstOrDefault();
                        if (objHMCT != null)
                        {
                            HangMucCongTrinh = objHMCT;
                            DienTich = objHMCT.DIENTICHXAYDUNG ?? 0.0M; ;
                            TENTAISAN = HangMucCongTrinh.TENHANGMUC;
                        }
                        break;
                    case "9"://DC_RUNGTRONG
                        var objRT = db.DC_RUNGTRONG.Where(it => it.RUNGTRONGID.Equals(TAISANID)).FirstOrDefault();
                        if (objRT != null)
                        {
                            RungTrong = objRT;
                            DienTich = objRT.DIENTICH ?? 0.0M; ;
                            TENTAISAN = RungTrong.TENRUNG;
                        }
                        break;
                    case "10"://DC_CAYLAUNAM
                        var objCLN = db.DC_CAYLAUNAM.Where(it => it.CAYLAUNAMID.Equals(TAISANID)).FirstOrDefault();
                        if (objCLN != null)
                        {
                            CayLauNam = objCLN;
                            DienTich = objCLN.DIENTICH ?? 0.0M;
                            TENTAISAN = CayLauNam.TENCAYLAUNAM;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public string TenLoaiTaiSan { get; set; }
        public string TenTaiSan { get; set; }
        public decimal DienTich { get; set; }
        public void InitData()
        {
            if (LoaiTaiSanGanLienVoiDat != null)
                TenLoaiTaiSan = LoaiTaiSanGanLienVoiDat.TENLOAITAISANGANLIENVOIDAT;
            switch (LOAITAISAN)
            {
                case "1":
                    if (NhaRiengLe != null)
                    {
                        TenTaiSan = NhaRiengLe.DIACHI;
                        DienTich = NhaRiengLe.DIENTICHXAYDUNG ?? 0M;
                    }
                    break;
                case "2":
                    if (KhuChungCu != null)
                    {
                        TenTaiSan = KhuChungCu.TENKHU;
                        DienTich = KhuChungCu.DIENTICHKHU ?? 0M;
                    }
                    break;
                case "3":
                    if (NhaChungCu != null)
                    {
                        TenTaiSan = NhaChungCu.TENCHUNGCU;
                        DienTich = NhaChungCu.DIENTICHXAYDUNG ?? 0M;
                    }
                    break;
                case "4":
                    if (CanHo != null)
                    {
                        TenTaiSan = CanHo.SOHIEUCANHO;
                        DienTich = CanHo.DIENTICHSAN ?? 0M;
                    }
                    break;
                case "5":
                    if (HangMucNgoaiCanHo != null)
                    {
                        TenTaiSan = HangMucNgoaiCanHo.TENHANGMUC;
                        DienTich = HangMucNgoaiCanHo.DIENTICH ?? 0M;
                    }
                    break;
                case "6":
                    if (CongTrinhXayDung != null)
                    {
                        TenTaiSan = CongTrinhXayDung.TENCONGTRINH;
                        DienTich = CongTrinhXayDung.DIENTICHXAYDUNG ?? 0M;
                    }
                    break;
                case "7":
                    if (CongTrinhNgam != null)
                    {
                        TenTaiSan = CongTrinhNgam.TENCONGTRINH;
                        DienTich = CongTrinhNgam.DIENTICHCONGTRINH ?? 0M;
                    }
                    break;
                case "8":
                    if (HangMucCongTrinh != null)
                    {
                        TenTaiSan = HangMucCongTrinh.TENHANGMUC;
                        DienTich = HangMucCongTrinh.DIENTICHXAYDUNG ?? 0M;
                    }
                    break;
                case "9":
                    if (RungTrong != null)
                    {
                        TenTaiSan = RungTrong.TENRUNG;
                        DienTich = RungTrong.DIENTICH ?? 0M;
                    }
                    break;
                case "10":
                    if (CayLauNam != null)
                    {
                        TenTaiSan = CayLauNam.TENCAYLAUNAM;
                        DienTich = CayLauNam.DIENTICH ?? 0M;
                    }
                    break;
            }
        }
    }
}

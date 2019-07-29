using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class TaiSanLS
    {
        public NhaRiengLeLS NhaRiengLe { get; set; }
        public CanHoLS CanHo { get; set; }
        public CongTrinhXayDungLS CongTrinhXayDung { get; set; }
        public RungTrongLS RungTrong { get; set; }
        public CayLauNamLS CayLauNam { get; set; }
        public CongTrinhNgamLS CongTrinhNgam { get; set; }
        public NhaChungCuLS NhaChungCu { get; set; }
        public HangMucNgoaiCanHoLS HangMucNgoaiCanHo { get; set; }
        public HangMucCongTrinhLS HangMucCongTrinh { get; set; }
        public List<ThuaTaiSanLS> DSThua { get; set; }
        #region "Properties"
        public string TAISANGANLIENVOIDATID { get; set; }
        public string TAISANID { get; set; }
        public string LOAITAISAN { get; set; }
        public string TENTAISAN { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string TRANGTHAI { get; set; }
        public string TAISANGOCID { get; set; }
        public Nullable<decimal> SOLANCAPQUYEN { get; set; }
        #endregion
    }
}

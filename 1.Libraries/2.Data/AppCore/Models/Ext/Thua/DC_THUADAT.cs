using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_THUADAT
    {
        public List<DC_BD_THUA_THUA> QHThua { get; set; }
        public List<DC_MUCDICHSUDUNGDAT> DSMucDichSuDungDat { get; set; }
        public DC_MUCDICHSUDUNGDAT CurMDSDDAT { get; set; }
        public DC_VITRITHUADAT CurViTri { get; set; }
        public GD_GIATHUADAT CurGiaDat { get; set; }
        public DC_TRANHCHAP CurTranhChap { get; set; }
        public DC_HANCHE CurHanChe { get; set; }
        public List<GD_GIATHUADAT> DSGiaDat { get; set; }
        public List<DC_TRANHCHAP> DSTranhChap { get; set; }
        public List<HS_LIENKETTHUADAT> DSHoSoLK { get; set; }
        public List<DC_QUYENSUDUNGDAT> DSQuyenSDD { get; set; }
        public List<DC_HANCHE> DSHanCheThua { get; set; }
        public List<DC_VITRITHUADAT> DSViTri { get; set; }
        public HC_DMKVHC Xa { get; set; }
        public string DSMucDichSuDungDatToString { get; set; }
        public List<HS_HOSO> DSHoSo { get; set; }
        public string TenXaPhuong { get; set; }
        public string MDSD { get; set; }
        // Tài liệu đo đạc
        public DC_TAILIEUDODAC CurTaiLieuDoDac { get; set; }
        public string TENTAILIEUDD { get; set; }
        public bool _DANGTRANHCHAP { get; set; }
        public bool _CONTRANHCHAP { get; set; }
        public bool _DACAPQUYEN { get; set; }
        public bool _LADOITUONGCHIEMDAT { get; set; }
        public int _KIEMTRA { get; set; }
        public int _TRONGDANGKY { get; set; }
        public int _TRONGDB { get; set; }
        public string DUONG { get; set; }
        public string DOANDUONG { get; set; }
        public string KHUVUC { get; set; }
        public string HINHTHUCSUDUNG { get; set; }
        //trả về danh sách id giấy chứng nhận cha
        //Phục vụ xử lý trên client khi check vào các check box của GCN cha trong danh sách đầu vào
        public string DONDANGKYID { get; set; }
        public string DSThuaCha
        {
            get
            {
                string s = "";
                if (QHThua != null)
                    for (int i = 0; i < QHThua.Count; i++)
                    {
                        s = s + QHThua[i].THUACHAID + ",";
                    }

                if (s.Length > 0) s = s.Substring(0, s.Length - 1);

                return s;
            }

            set
            {
                QHThua.Clear();
                DC_BD_THUA_THUA item;
                string[] arrIDCha;
                if (value.Length > 0)
                {
                    arrIDCha = value.Split(',');
                    for (int i = 0; i < arrIDCha.Length; i++)
                    {
                        item = new Models.DC_BD_THUA_THUA();
                        item.BDTHUATHUAID = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                        item.THUADATID = THUADATID;
                        item.THUACHAID = arrIDCha[i];
                        QHThua.Add(item);
                    }
                }
            }
        }

    }

    public enum THUATHEO
    {
        MDSDID, THUADATID, KHAC
    }
}

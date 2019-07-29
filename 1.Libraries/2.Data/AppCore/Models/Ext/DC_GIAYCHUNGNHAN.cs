using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_GIAYCHUNGNHAN
    {
        public DC_NGUOI Chu { get; set; }
        public List<DC_QUYENSUDUNGDAT> DSQuyenSDDat { get; set; }
        public List<DC_QUYENSOHUUTAISAN> DSQuyenSHTS { get; set; }
        public List<DC_QUYENQUANLYDAT> DSQuyenQLDat { get; set; }
        public List<DC_BD_GCN_GCN> QHGcn_Gcn { get; set; }
        public List<DC_BD_TREN_GCN> DSBDTrenGCN { get; set; }
        public List<DC_HANCHE> DSHanChe { get; set; }
        public List<DC_GCN_TILESH> DSTyLeSoHuu { get; set; }
        public int TRANGTHAI { get; set; }
        public bool ThuocDangKy { get; set; }
        public bool EnableEdit { get; set; }
        public bool ChinhSua { get; set; }
        public bool _NONVTC
        {
            get
            {
                return NONVTC == "Y" ? true : false;
            }
            set
            {
                NONVTC = value ? "Y" : "N";
            }
        }
        //0
        //1: QSD Dat
        //2: QQL Dat
        //3: QSH Tai San
        public int IsQuyen { get; set; }
        //trả về danh sách id giấy chứng nhận cha
        //Phục vụ xử lý trên client khi check vào các check box của GCN cha trong danh sách đầu vào
        public string DSGCNCha
        {
            get
            {
                string s = "";
                if (QHGcn_Gcn != null)
                    for (int i = 0; i < QHGcn_Gcn.Count; i++)
                    {
                        s = s + QHGcn_Gcn[i].GCNCHAID + ",";
                    }
                if (s.Length > 0) s = s.Substring(0, s.Length - 1);

                return s;
            }

            set
            {
                if (QHGcn_Gcn == null) QHGcn_Gcn = new List<Models.DC_BD_GCN_GCN>();
                else QHGcn_Gcn.Clear();
                DC_BD_GCN_GCN item;
                string[] arrIDCha;
                if (value != null && value.Length > 0)
                {
                    arrIDCha = value.Split(',');
                    for (int i = 0; i < arrIDCha.Length; i++)
                    {
                        item = new Models.DC_BD_GCN_GCN();
                        item.BDGCNGCNID = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                        item.GIAYCHUNGNHANID = GIAYCHUNGNHANID;
                        item.GCNCHAID = arrIDCha[i];
                        QHGcn_Gcn.Add(item);
                    }
                }
            }
        }
        public bool isInitData = false;
    }
}

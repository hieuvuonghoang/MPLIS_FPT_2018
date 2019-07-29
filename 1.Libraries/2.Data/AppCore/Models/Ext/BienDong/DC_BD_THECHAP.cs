using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_BD_THECHAP
    {
        public List<DC_QUYENSOHUUTAISAN> DSQuyenSoHuuTaiSan { get; set; }
        public List<DC_QUYENSUDUNGDAT> DSQuyenSuDungDat { get; set; }

        public void getData()
        {
            using (MplisEntities db = new MplisEntities())
            {
                //Lấy danh sách quyền sở hữu tài sản
                var objSHTS = (from t1 in db.DC_QUYENSOHUUTAISAN
                               where t1.BDTHECHAPID == BDTHECHAPID
                               select t1).ToList();
                if (objSHTS != null)
                {
                    DSQuyenSoHuuTaiSan = objSHTS;
                }

                //Lấy danh sách quyền sử dụng đất
                var objSDD = (from t1 in db.DC_QUYENSUDUNGDAT
                               where t1.BDTHECHAPID == BDTHECHAPID
                               select t1).ToList();
                if (objSDD != null)
                {
                    DSQuyenSuDungDat = objSDD;
                }
            }
        }
    }
}

using AppCore.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.CustomQueries
{
    public class DonDangKy
    {
        private MplisEntities _dataContext = new MplisEntities();
       public IEnumerable getTaiSan(string id)
        {
            var result = from don in _dataContext.DC_DONDANGKY
                         join quyen in _dataContext.DC_QUYENSOHUUTAISAN on don.DONDANGKYID equals quyen.DONDANGKYID
                         join taisan in _dataContext.DC_TAISANGANLIENVOIDAT on quyen.TAISANGANLIENVOIDATID equals taisan.TAISANGANLIENVOIDATID
                         where (don.DONDANGKYID == id)
                         select new { DC_DONDANGKY = don, DC_QUYENSOHUUTAISAN = quyen, DC_TAISANGANLIENVOIDAT = taisan};
            return result;
        }
        public IEnumerable getQuyenSuDung(string id)
        {
            /*
             * 
SELECT aa.DONDANGKYID,
dd.NGUOIID,
dd.THUADATID,
dd.MUCDICHSUDUNGDATID,
dd.GIAYCHUNGNHANID,
ee.MUCDICHSUDUNGID,
ee.MUCDICHSUDUNGQHID,
ee.DIENTICH,
ee.SUDUNGCHUNG,
ee.THOIHANSUDUNG
FROM DC_DONDANGKY aa 
INNER JOIN DC_QUYENSUDUNGDAT dd ON aa.DONDANGKYID = dd.DONDANGKYID
INNER JOIN DC_MUCDICHSUDUNGDAT ee ON dd.MUCDICHSUDUNGDATID = ee.MUCDICHSUDUNGDATID

             */
            var result = from don in _dataContext.DC_DONDANGKY
                         join quyen in _dataContext.DC_QUYENSUDUNGDAT on don.DONDANGKYID equals quyen.DONDANGKYID
                         join mucdich in _dataContext.DC_MUCDICHSUDUNGDAT on quyen.MUCDICHSUDUNGDATID equals mucdich.MUCDICHSUDUNGDATID
                         where (don.DONDANGKYID == id)
                         select new { DC_DONDANGKY = don, DC_QUYENSUDUNGDAT = quyen, DC_MUCDICHSUDUNGDAT = mucdich };
            return result;
        }
    }
}

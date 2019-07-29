using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.QTHT.Models
{
    public class NhomChucNangViewModel
    {
        public List<HT_UNGDUNG> GetListUngDung()
        {
            using (var context = new MplisEntities())
            {
                var list = context.HT_UNGDUNG.ToList();
                return list;
            }
        }
    }
}

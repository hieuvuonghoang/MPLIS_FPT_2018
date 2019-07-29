using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.QTHT.Models
{
    public class QuanLyMenuViewModel
    {
        public List<HT_UNGDUNG> GetListUngDung()
        {
            using (var context = new MplisEntities())
            {
                var list = context.HT_UNGDUNG.ToList();
                return list;
            }
        }
        public List<HT_NHOMCHUCNANG> GetListNhomChucNang()
        {
            using (var context = new MplisEntities())
            {
                var list = context.HT_NHOMCHUCNANG.ToList();
                return list;
            }
        }
    }
}

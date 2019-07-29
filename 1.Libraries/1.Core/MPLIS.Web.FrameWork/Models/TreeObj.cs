using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Web.FrameWork.Models
{
    public class TreeObj
    {
        public class FlatObject
        {
            public string Id { get; set; }
            public string ParentId { get; set; }
            public string data { get; set; }

            public FlatObject(string name, string id, string parentId)
            {
                data = name;
                Id = id;
                ParentId = parentId;
            }
        }

        public class RecursiveObject
        {
            public string data { get; set; }
            public FlatTreeAttribute attr { get; set; }
            public List<RecursiveObject> children { get; set; }
        }

        public class FlatTreeAttribute
        {
            public string id;
            public bool selected;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPLIS.Web.FrameWork.Models;
namespace MPLIS.Web.FrameWork.Mvc
{
    public static class Utils
    {
        public static string ToData(this IList<KeyValuePair<string, string>> o)
        {
            if (o == null || o.Count == 0)
            {
                return "{keys:[], vals:[]}";
            }
            return new { keys = from z in o select z.Key, vals = from z in o select z.Value }.ToJson();
        }
        public static List<TreeObj.RecursiveObject> FillRecursive(List<TreeObj.FlatObject> flatObjects, string parentId, List<string> listSelected)
        {
            List<TreeObj.RecursiveObject> recursiveObjects = new List<TreeObj.RecursiveObject>();

            foreach (var item in flatObjects.Where(x => x.ParentId.Equals(parentId)))
            {
                recursiveObjects.Add(new TreeObj.RecursiveObject
                {
                    data = item.data,
                    attr = new TreeObj.FlatTreeAttribute { id = item.Id.ToString(), selected = listSelected.Contains(item.Id) },
                    children = FillRecursive(flatObjects, item.Id, listSelected)
                });
            }
            return recursiveObjects;
        }
        
    }

}

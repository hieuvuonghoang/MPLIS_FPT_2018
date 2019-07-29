using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace System.Web.Mvc
{
    public class JsonResultCustom : ActionResult
    {
        public JsonResultCustom()
        {
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
        }
        public JsonResultCustom(object _data)
        {
            Data = _data;
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
        }

        #region Overrides of ActionResult

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new HttpException("DenyGet");
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/json" : ContentType;
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;
            if (Data == null)
                return;
            response.Write(JsonConvert.SerializeObject(Data, new JsonConverter[] {new JavaScriptDateTimeConverter()}));
        }

        #endregion

        public Encoding ContentEncoding { get; set; }

        public string ContentType { get; set; }

        public object Data { get; set; }

        public JsonRequestBehavior JsonRequestBehavior { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MPLIS.FileService.Controllers
{
    public class DownLoadFileController : ApiController
    {
        public async Task<HttpResponseMessage> Get(string url, string token)
        {
            HttpResponseMessage result = null;
            var check = await CheckSSOService.PreProcessingRequest(HttpContext.Current.ApplicationInstance);
            if (check == true)
            {
                if (!File.Exists(url))
                {
                    result = new HttpResponseMessage();
                    result.Content = new StringContent("Không có file");

                    return result;
                }
                else
                {
                    var filename = Path.GetFileName(url);
                    result = new HttpResponseMessage(HttpStatusCode.OK);
                    var stream = new FileStream(url, FileMode.Open);
                    result.Content = new StreamContent(stream);
                    result.Content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/octet-stream");
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    result.Content.Headers.ContentDisposition.FileName = filename;
                    return result;
                }

            }
            else
            {
                result = new HttpResponseMessage();
                result.Content = new StringContent("Thông tin không xác thực");
                return result;
            }
        }

    }
}

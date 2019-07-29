using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MPLIS.FileService.Controllers
{
    public class UpLoadFileController : ApiController
    {
        public async Task<HttpResponseMessage> Post(string token, string loaifile, string xa, string huyen, string tinh, string nam, string bohoso, string donvi)
        {
            try
            {
                var check = await CheckSSOService.PreProcessingRequest(HttpContext.Current.ApplicationInstance);
                if (check == true)
                {
                    var result = new List<File_infor>();
                    List<string> savedfilepath = new List<string>();
                    string fullpath = "";
                    if (!Request.Content.IsMimeMultipartContent())
                    {
                        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                    }
                    string rootpath = "\\\\TeamviewduanMSB\\Share_test";
                    //string rootpaths = HttpContext.Current.Server.MapPath("~/MPLIS_FileServer");
                    //string test = path;
                    //savedfilepath.Add(rootpath);
                    //savedfilepath.Add(rootpaths);
                    if (loaifile == null || loaifile == "")
                        loaifile = "Khac";
                    if (xa == null || xa == "")
                        xa = "Khac";
                    if (huyen == null || huyen == "")
                        huyen = "Khac";
                    if (tinh == null || tinh == "")
                        tinh = "Khac";
                    if (nam == null || nam == "")
                        nam = "Khac";
                    if (bohoso == null || bohoso == "")
                        bohoso = "Khac";
                    if (donvi == null || donvi == "")
                        donvi = "Khac";
                    var xarp = RemoveSign4VietnameseString(xa);
                    xarp = xarp.Replace(" ", String.Empty);
                    var huyenrp = RemoveSign4VietnameseString(huyen);
                    huyenrp = huyenrp.Replace(" ", String.Empty);
                    var tinhrp = RemoveSign4VietnameseString(tinh);
                    tinhrp = tinhrp.Replace(" ", String.Empty);
                    switch (loaifile)
                    {
                        case "DiaChinh":
                            fullpath = String.Format("{0}\\{1}\\{2}_{3}_{4}\\{5}\\{6}\\{7}", rootpath, loaifile, tinhrp, huyenrp, xarp, donvi, nam, bohoso);
                            break;
                        case "TKKK":
                            fullpath = String.Format("{0}\\{1}\\{2}_{3}_{4}\\{5}\\{6}\\{7}", rootpath, loaifile, tinhrp, huyenrp, xarp, donvi, nam, bohoso);
                            break;
                        case "QuyHoach":
                            fullpath = String.Format("{0}\\{1}\\{2}_{3}\\{4}\\{5}\\{6}", rootpath, loaifile, tinhrp, huyenrp, donvi, nam, bohoso);
                            break;
                        case "GiaDat":
                            fullpath = String.Format("{0}\\{1}\\{2}\\{3}\\{4}\\{5}", rootpath, loaifile, tinhrp, donvi, nam, bohoso);
                            break;
                    }
                    if (!System.IO.Directory.Exists(fullpath))
                        System.IO.Directory.CreateDirectory(fullpath);
                    var provider = new MultipartFileStreamProvider(fullpath);
                    var task = await Request.Content.ReadAsMultipartAsync(provider).
                        ContinueWith<HttpResponseMessage>(t =>
                        {
                            if (t.IsCanceled || t.IsFaulted)
                            {
                            //  Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                            savedfilepath.Add("tttt" + t.Exception.Message);
                            }
                            foreach (MultipartFileData item in provider.FileData)
                            {
                                try
                                {
                                    string name = item.Headers.ContentDisposition.FileName.Replace("\"", "");
                                    var namenotext = Path.GetFileNameWithoutExtension(name);
                                    var ext = Path.GetExtension(name);
                                    int count = 0;
                                    while (File.Exists(Path.Combine(fullpath, name)))
                                    {
                                        name = String.Format("{0} ({1}){2}", namenotext, count, ext);
                                        count = count + 1; // sorry, not a fan of the ++ operator.
                                }
                                    File.Move(item.LocalFileName, Path.Combine(fullpath, name));
                                    var fileinfor = new File_infor();
                                    fileinfor.DuongDan = Path.Combine(fullpath, name);
                                    fileinfor.TenFile = name;
                                    result.Add(fileinfor);
                                }
                                catch (Exception ex)
                                {
                                    string message = ex.Message;
                                    savedfilepath.Add("exx" + message);

                                }
                            }
                            savedfilepath.Add(token);
                            savedfilepath.Add(fullpath);
                            return Request.CreateResponse(HttpStatusCode.Created, result);
                        });
                    return task;
                }
                else
                    return Request.CreateResponse(HttpStatusCode.Created, "Lỗi xác thực");
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("GET: Test message")
            };
        }
        #region text
        private static readonly string[] VietnameseSigns = new string[]

     {

        "aAeEoOuUiIdDyY",

        "áàạảãâấầậẩẫăắằặẳẵ",

        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

        "éèẹẻẽêếềệểễ",

        "ÉÈẸẺẼÊẾỀỆỂỄ",

        "óòọỏõôốồộổỗơớờợởỡ",

        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

        "úùụủũưứừựửữ",

        "ÚÙỤỦŨƯỨỪỰỬỮ",

        "íìịỉĩ",

        "ÍÌỊỈĨ",

        "đ",

        "Đ",

        "ýỳỵỷỹ",

        "ÝỲỴỶỸ"

     };



        public static string RemoveSign4VietnameseString(string str)

        {

            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi

            for (int i = 1; i < VietnameseSigns.Length; i++)

            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

            }

            return str;

        }
        public class File_infor
        {
            public string DuongDan { get; set; }
            public string TenFile { get; set; }

        }

        #endregion
    }
}

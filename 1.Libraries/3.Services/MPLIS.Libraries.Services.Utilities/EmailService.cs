using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Services.Utilities
{
    /// <summary>
    /// Email Service
    /// Class gửi mail trong MVC
    /// </summary>
    public class EmailService
    {
        /// <summary>
        /// Hàm thực thi gửi email. 
        /// </summary>
        /// <param name="smtpUserName">Tên đăng nhập email gửi thư</param>
        /// <param name="smtpPassword">Mật khẩu của email gửi thư</param>
        /// <param name="smtpHost">Host email. vd smtp.live.com hoac smtp.google.com</param>
        /// <param name="smtpPort">Port vd: 25 or 465</param>
        /// <param name="toEmail">Email nhận vd: tuanitpro@gmail.com</param>
        /// <param name="subject">Chủ đề</param>
        /// <param name="body">Nội dung thư gửi</param>
        /// <returns>True-Thành công/False-Thất bại</returns>
        public bool Send(string smtpUserName, string smtpPassword, string smtpHost, int smtpPort,
            string toEmail, string subject, string body)
        {
            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Host = smtpHost;
                    smtpClient.Port = smtpPort;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(smtpUserName, smtpPassword);
                    var msg = new MailMessage
                    {
                        IsBodyHtml = true,
                        BodyEncoding = Encoding.UTF8,
                        From = new MailAddress(smtpUserName),
                        Subject = subject,
                        Body = body,
                        Priority = MailPriority.Normal,
                    };

                    msg.To.Add(toEmail);

                    smtpClient.Send(msg);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public string RandomString(int size, bool lowerCase) // tạo một chuỗi ngẫu nhiên,  dùng để tạo mật khẩu ngẫu nhiên
        {
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 87)));
                sb.Append(c);
            }
            if (lowerCase)
                return sb.ToString().ToLower();
            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.ViewsModel;

namespace TeknikServis.BLL.Settings
{
   public static class SiteSettings
    {

        public static string SiteMail = "kamilfidil@gmail.com";
        public static string SiteMailPassword = "123456kf";
        public static string SiteMailSmtpHost = "smtp.gmail.com";
        public static int SiteMailSmtpPort = 587;
        public static bool SiteMailEnableSsl = true;

        public async static Task SendMail(MailModel model)
        {
            using (var smtp = new SmtpClient())
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(model.To));
                message.From = new MailAddress(SiteMail);
                message.Subject = model.Subject;
                message.IsBodyHtml = true;
                message.Body = model.Message;
                message.BodyEncoding = Encoding.UTF8;
                if (!string.IsNullOrEmpty(model.Cc))
                    message.CC.Add(new MailAddress(model.Cc));
                if (!string.IsNullOrEmpty(model.Bcc))
                    message.Bcc.Add(new MailAddress(model.Bcc));

                var credential = new NetworkCredential()
                {
                    UserName = SiteMail,
                    Password = SiteMailPassword
                };
                smtp.Credentials = credential;
                smtp.Host = SiteMailSmtpHost;
                smtp.Port = SiteMailSmtpPort;
                smtp.EnableSsl = SiteMailEnableSsl;
                await smtp.SendMailAsync(message);
            }

        }

        public async static Task SendMail(ContactMailModel model)
        {
            using (var smtp = new SmtpClient())
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(SiteMail));
                message.From = new MailAddress(SiteMail);
                message.Subject = "İletişim Formu Ulusoy Mobilya";
                message.IsBodyHtml = true;
                message.Body =$"<b>MESAJ</b></br>{ model.Mesaj}</br><b>Telefon Numarası :</b> {model.Telefon}</br><b>Mail Adresi :</b> {model.GonderenEmail}";
                message.BodyEncoding = Encoding.UTF8;
                var credential = new NetworkCredential()
                {
                    UserName = SiteMail,
                    Password = SiteMailPassword
                };
                smtp.Credentials = credential;
                smtp.Host = SiteMailSmtpHost;
                smtp.Port = SiteMailSmtpPort;
                smtp.EnableSsl = SiteMailEnableSsl;
                await smtp.SendMailAsync(message);
            }

        }


        public static string UrlFormatConverter(string name)
        {
            string sonuc = name.ToLower();
            sonuc = sonuc.Replace("'", "");
            sonuc = sonuc.Replace(" ", "-");
            sonuc = sonuc.Replace("<", "");
            sonuc = sonuc.Replace(">", "");
            sonuc = sonuc.Replace("&", "");
            sonuc = sonuc.Replace("[", "");
            sonuc = sonuc.Replace("!", "");
            sonuc = sonuc.Replace("]", "");
            sonuc = sonuc.Replace("ı", "i");
            sonuc = sonuc.Replace("ö", "o");
            sonuc = sonuc.Replace("ü", "u");
            sonuc = sonuc.Replace("ş", "s");
            sonuc = sonuc.Replace("ç", "c");
            sonuc = sonuc.Replace("ğ", "g");
            sonuc = sonuc.Replace("İ", "I");
            sonuc = sonuc.Replace("Ö", "O");
            sonuc = sonuc.Replace("Ü", "U");
            sonuc = sonuc.Replace("Ş", "S");
            sonuc = sonuc.Replace("Ç", "C");
            sonuc = sonuc.Replace("Ğ", "G");
            sonuc = sonuc.Replace("|", "");
            sonuc = sonuc.Replace(".", "-");
            sonuc = sonuc.Replace("?", "-");
            sonuc = sonuc.Replace(";", "-");

            return sonuc;
        }
    }
}

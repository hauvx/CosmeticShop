using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace Common
{
    public class MailHelper
    {
        IConfiguration _iconfiguration;
        public MailHelper(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public void SendMail (string subject , string content)
        {
            
            var fromEmailAddress = _iconfiguration.GetSection("appSettings").GetSection("FromEmailAddress").Value.ToString();
            var toEmailAddress = _iconfiguration.GetSection("appSettings").GetSection("ToEmailAddress").Value.ToString();
            var fromEmailDisplayName = _iconfiguration.GetSection("appSettings").GetSection("FromEmailDisplayName").Value.ToString();
            var fromEmailPassWord = _iconfiguration.GetSection("appSettings").GetSection("FromMailPassword").Value.ToString();
            var smtpHost = _iconfiguration.GetSection("appSettings").GetSection("SMTPHost").Value.ToString();
            var smtpPort = _iconfiguration.GetSection("appSettings").GetSection("SMTPPort").Value.ToString();

            bool enableSsl = bool.Parse(_iconfiguration.GetSection("appSettings").GetSection("EnabledSSL").Value.ToString());

            string body = content;

            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress,fromEmailDisplayName),new MailAddress(toEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassWord);
            client.Host = smtpHost;
            client.EnableSsl = enableSsl;
            client.Port = !String.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);



        }
    }
}

using CommunicationServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationServices
{
    public class EmailCommunication<T, E> : ICommunication, IDisposable where T : EmailModel where E : EmailRes
    {
        private readonly EmailConfig _emailConfig;
        private readonly SmtpClient _smtpClient;

        public EmailCommunication(IServiceProvider serviceProvider)
        {
            _emailConfig = serviceProvider.GetCommunicationOptions().emailConfig;
            _smtpClient = new SmtpClient()
            {

                Host = _emailConfig.Host,
                Port = _emailConfig.Port,
                Credentials = new NetworkCredential(_emailConfig.UserName, _emailConfig.Password),
                EnableSsl = true,
                UseDefaultCredentials = false,

            };
        }



        public void Dispose()
        {
            _smtpClient.Dispose();
        }

        public async Task<bool> SendAsync<T>(T Model)
        {
            try
            {
                var emailModel = Model as EmailModel;
                MailAddress to = new MailAddress(emailModel.To);
                MailAddress from = new MailAddress(_emailConfig.From);
                MailMessage email = new MailMessage(from, to);
                email.Subject = emailModel.Subject;
                email.Body = emailModel.Message;

                _smtpClient.SendMailAsync(email).Wait();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}

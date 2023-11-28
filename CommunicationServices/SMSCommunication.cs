using CommunicationServices.Model;
using mpNuget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CommunicationServices
{
    public class SMSCommunication<T, E> : ICommunication, IDisposable where T : SMSModel where E : SMSRes
    {
        private readonly SMSConfig _smsConfig;


        public SMSCommunication(IServiceProvider serviceProvider)
        {
            _smsConfig = serviceProvider.GetCommunicationOptions().smsConfig;

        }
              

        public void Dispose()
        {

        }

        
        public async Task<bool> SendAsync<T1>(T1 Model)
        {
            SMSModel sMSModel = Model as SMSModel;
            string username = _smsConfig.username;
            string password = _smsConfig.password;
            string to = sMSModel.To;
            string text = string.Join(";", sMSModel.Message);
            int bodyId = _smsConfig.PaternId;
            RestClient restClient = new RestClient(username, password);


            var res = Task.Run(() => restClient.SendByBaseNumber(text, to, bodyId)).Result;

            if (res.StrRetStatus == "Ok")
            {
                return true;
            }
            return false;



        }
    }
}

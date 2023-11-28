using CommunicationServices.Enums;
using CommunicationServices.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationServices
{
    public static class CommunicationSetup
    {
        public delegate ICommunication CommunicationServiceResolver(CommunicationServiceEnums identifier);
        public static void AddCommunication(this IServiceCollection services, Action<CommunicationOptions> options)
        {
            services.Configure(options);
            services.AddScoped<EmailCommunication<EmailModel, EmailRes>>(serviceProvider => new EmailCommunication<EmailModel, EmailRes>(serviceProvider));
            services.AddScoped<SMSCommunication<SMSModel, SMSRes>>(serviceProvider => new SMSCommunication<SMSModel, SMSRes>(serviceProvider));

            services.AddTransient<CommunicationServiceResolver>(serviceProvider => token =>
            {
                // hardcoded strings can be extracted as constants
                return token switch
                {
                    CommunicationServiceEnums.Email => serviceProvider.GetService<EmailCommunication<EmailModel, EmailRes>>(),
                    CommunicationServiceEnums.SMS => serviceProvider.GetService<SMSCommunication<SMSModel, SMSRes>>(),
                    _ => throw new InvalidOperationException()
                };
            });

            //services.AddScoped<ICommunication, EmailCommunication>(serviceProvider => new EmailCommunication(serviceProvider));
        }
        public static CommunicationOptions GetCommunicationOptions(this IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<IOptions<CommunicationOptions>>().Value;
        }
    }
}

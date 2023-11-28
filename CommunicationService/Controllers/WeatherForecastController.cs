using CommunicationServices;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Runtime.Intrinsics.X86;
using static CommunicationServices.CommunicationSetup;

namespace CommunicationService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly CommunicationServiceResolver _communication;

        public WeatherForecastController(CommunicationServiceResolver communication)
        {
            _communication = communication;
        }

        [HttpPost]
        public async void Get([FromBody] EmailModel model)
        {
                 
            var ss = await _communication(CommunicationServices.Enums.CommunicationServiceEnums.Email).SendAsync(model);
            var tt = ss;
        }
        [HttpPost]
        public async void SmS([FromBody] SMSModel model)
        {

            var ss = await _communication(CommunicationServices.Enums.CommunicationServiceEnums.SMS).SendAsync(model);
            var tt = ss;
        }
    }
}
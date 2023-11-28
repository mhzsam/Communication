using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationServices
{
    public interface ICommunication
    {
        Task<bool> SendAsync<T>(T Model);

    }
}

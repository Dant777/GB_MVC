using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailBussinesLayer.Models;
using EmailBussinesLayer.Models.Interfaces;

namespace EmailBussinesLayer.Interfaces
{
    public interface IMessageGatewayService:IDisposable
    {
        Task SendMessage(IMessage message);
     
    }

}


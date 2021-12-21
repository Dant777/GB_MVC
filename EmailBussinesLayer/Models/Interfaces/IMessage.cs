using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailBussinesLayer.Models.Interfaces
{
    public interface IMessage
    {
        string Subject { get; set; }

        string Body { get; set; }

        string To { get; set; }

        string Name { get; set; }

        bool IsHtml { get; set; }
    }
}
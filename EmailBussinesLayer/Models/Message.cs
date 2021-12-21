using EmailBussinesLayer.Models.Interfaces;

namespace EmailBussinesLayer.Models
{
    public sealed class Message : IMessage
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public string To { get; set; }

        public string Name { get; set; }

        public bool IsHtml { get; set; }
    }
}

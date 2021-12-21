using EmailBussinesLayer.Interfaces;
using EmailBussinesLayer.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;
using EmailBussinesLayer.Models.Interfaces;

namespace EmailBussinesLayer.EmailClasses
{
    public sealed class MessageGatewayService:IMessageGatewayService
    {

        private readonly MailGatewayOptions _options;
        private readonly SmtpClient _client = new SmtpClient();

        public MessageGatewayService(MailGatewayOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _options = options;

            _client.Connect(options.SMTPServer, options.Port);
            _client.Authenticate(options.Sender, options.Password);
        }

        public async Task SendMessage(IMessage message)
        {
            if (_options is null)
            {
                throw new ArgumentNullException(nameof(_options));
            }

            MimeMessage emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_options.SenderName, _options.Sender));
            emailMessage.To.Add(new MailboxAddress(message.Name, message.To));
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(message.IsHtml ? MimeKit.Text.TextFormat.Html : MimeKit.Text.TextFormat.Text)
            {
                Text = message.Body
            };

            await _client.SendAsync(emailMessage);
        }

        public void Dispose()
        {
            _client.Disconnect(true);
            _client.Dispose();
        }
    }

}


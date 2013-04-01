using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xemio.ProjectCoach.Core.Services.Email;

namespace Xemio.ProjectCoach.Infrastructure.Services
{
    public class EMailSender : IEmailSender, IDisposable
    {
        #region Fields
        private readonly SmtpClient _smtpClient;
        private readonly string _emailAddress;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EMailSender"/> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="ip">The ip.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="ssl">if set to <c>true</c> [SSL].</param>
        public EMailSender(string host, int ip, string email, string password, bool ssl)
        {
            this._emailAddress = email;
            this._smtpClient = this.CreateSmtpClient(host, ip, email, password, ssl);
        }
        #endregion Constructors

        #region IEmailSender Member
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="email">The email.</param>
        public void SendEmail(Email email)
        {
            MailMessage message = this.CreateMailMessage(email);
            this._smtpClient.SendMailAsync(message);
        }
        #endregion IEmailSender Member

        #region Private Methods
        /// <summary>
        /// Creates the SMTP client.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="ssl">if set to <c>true</c> [SSL].</param>
        private SmtpClient CreateSmtpClient(string host, int port, string email, string password, bool ssl)
        {
            SmtpClient client = new SmtpClient(host, port);
            client.Credentials = new NetworkCredential(email, password);
            client.EnableSsl = ssl;

            return client;
        }
        /// <summary>
        /// Creates the mail message.
        /// </summary>
        /// <param name="email">The email.</param>
        private MailMessage CreateMailMessage(Email email)
        {
            MailMessage message = new MailMessage();
            message.Sender = new MailAddress(this._emailAddress);
            this.AddMailsToCollection(message.To, email.Receipients);
            this.AddMailsToCollection(message.CC, email.Copy);
            this.AddMailsToCollection(message.Bcc, email.BlindCopy);

            message.Subject = email.Subject;
            message.Body = email.Body;
            message.IsBodyHtml = true;

            return message;
        }
        /// <summary>
        /// Adds the mails to the address-collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="addresses">The addresses.</param>
        private void AddMailsToCollection(MailAddressCollection collection, IEnumerable<string> addresses)
        {
            foreach (string address in addresses)
            {
                collection.Add(new MailAddress(address));
            }
        }
        #endregion Private Methods

        #region IDisposable Member
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this._smtpClient.Dispose();
        }
        #endregion IDisposable Member
    }
}

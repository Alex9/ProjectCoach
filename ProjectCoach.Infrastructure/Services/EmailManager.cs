using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xemio.ProjectCoach.Core.Services.Email;

namespace Xemio.ProjectCoach.Infrastructure.Services
{
    public class EmailManager : IEmailManager
    {
        #region Fields
        private readonly Timer _timer;
        private readonly ConcurrentQueue<Email> _emails = new ConcurrentQueue<Email>();
        private readonly IEmailSender _emailSender;
        #endregion Fields

        #region Constructors
        public EmailManager(IEmailSender sender, int sendFrequency = 1000)
        {
            this._timer = new Timer(Tick, null, 0, sendFrequency);
            this._emailSender = sender;
        }
        #endregion Constructors

        #region IEmailManager Member
        public void QueueEmail(Email email)
        {
            this._emails.Enqueue(email);
        }
        #endregion IEmailManager Member

        #region Private Methods
        private static void Tick(object state)
        {
            EmailManager emailManager = state as EmailManager;
            if (emailManager == null)
                return;

            while (!emailManager._emails.IsEmpty)
            {
                Email email;
                if (!emailManager._emails.TryDequeue(out email))
                    break;

                emailManager._emailSender.SendEmail(email);
            }
        }
        #endregion Private Methods
    }
}

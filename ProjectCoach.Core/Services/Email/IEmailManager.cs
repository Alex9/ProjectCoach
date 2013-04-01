using System.Collections.Generic;

namespace Xemio.ProjectCoach.Core.Services.Email
{
    public interface IEmailManager
    {
        void QueueEmail(Email email);
    }

    public class Email
    {
        public Email(string subject, string body, IList<string> receipients = null, IList<string> copy = null, IList<string> blindCopy = null)
        {
            this.Subject = subject;
            this.Body = body;
            this.Receipients = receipients ?? new List<string>();
            this.Copy = copy ?? new List<string>();
            this.BlindCopy = blindCopy ?? new List<string>();
        }

        public string Subject { get; set; }
        public string Body { get; set; }
        public IList<string> Receipients { get; set; }
        public IList<string> Copy { get; set; } 
        public IList<string> BlindCopy { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xemio.ProjectCoach.Core.Services.Email
{
    public interface IEmailSender
    {
        void SendEmail(Email email);
    }
}

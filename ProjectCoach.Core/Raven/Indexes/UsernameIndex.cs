using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Indexes;
using Xemio.ProjectCoach.Entities.Users;

namespace Xemio.ProjectCoach.Core.Raven.Indexes
{
    public class UsernameIndex : AbstractIndexCreationTask<User>
    {
        public UsernameIndex()
        {
            Map = users => from user in users
                           select user.Username;
        }
    }
}

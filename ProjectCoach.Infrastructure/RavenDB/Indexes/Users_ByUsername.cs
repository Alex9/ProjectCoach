using System.Linq;
using Raven.Client.Indexes;
using Xemio.ProjectCoach.Entities.Users;

namespace Xemio.ProjectCoach.Infrastructure.RavenDB.Indexes
{
    public class Users_ByUsername : AbstractIndexCreationTask<User>
    {
        public Users_ByUsername()
        {
            Map = users => from user in users
                           select new { user.Username };
        }
    }
}

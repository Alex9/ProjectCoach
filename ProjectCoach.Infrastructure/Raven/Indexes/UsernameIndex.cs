using System.Linq;
using Raven.Client.Indexes;
using Xemio.ProjectCoach.Entities.Users;

namespace Xemio.ProjectCoach.Infrastructure.Raven.Indexes
{
    internal class UsernameIndex : AbstractIndexCreationTask<User>
    {
        public UsernameIndex()
        {
            Map = users => from user in users
                           select new { user.Username };
        }

        public override string IndexName
        {
            get { return "Users/ByUsername"; }
        }
    }
}

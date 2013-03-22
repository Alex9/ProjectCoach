using System.Linq;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;
using Xemio.ProjectCoach.Entities.Users;

namespace Xemio.ProjectCoach.Infrastructure.Raven.Indexes
{
    public class Users_ByUsername : AbstractIndexCreationTask<User>
    {
        public Users_ByUsername()
        {
            Map = users => from user in users
                           select new { user.Username };

            Index(f => f.Username, FieldIndexing.Analyzed);
        }
    }
}

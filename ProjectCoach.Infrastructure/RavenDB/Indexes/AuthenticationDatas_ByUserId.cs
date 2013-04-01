using System.Linq;
using Raven.Client.Indexes;
using Xemio.ProjectCoach.Entities.Users;

namespace Xemio.ProjectCoach.Infrastructure.RavenDB.Indexes
{
    internal class AuthenticationDatas_ByUserId : AbstractIndexCreationTask<AuthenticationData>
    {
        public AuthenticationDatas_ByUserId()
        {
            Map = authenticationDatas => from data in authenticationDatas
                                          select new {data.UserId};
        }
    }
}

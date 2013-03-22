using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Indexes;
using Xemio.ProjectCoach.Entities.Users;

namespace Xemio.ProjectCoach.Infrastructure.Raven.Indexes
{
    internal class AuthenticationData_ByUserId : AbstractIndexCreationTask<AuthenticationData>
    {
        public AuthenticationData_ByUserId()
        {
            Map = authenticationDatas => from data in authenticationDatas
                                          select new {data.UserId};
        }
    }
}

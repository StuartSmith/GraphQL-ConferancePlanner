using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferancePlanner.GraphQL.Data;
using ConferancePlanner.GraphQL.DataLoader;
using ConferancePlanner.GraphQL.Extensions;
using ConferancePlanner.GraphQL.Types;
using ConferencePlanner.GraphQL.Data;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;

namespace ConferancePlanner.GraphQL.Sessions
{
   
    [ExtendObjectType("Query")]
    public class SessionQueries
    {
        [UseApplicationDbContext]
        [UsePaging(typeof(NonNullType<SessionType>))]
        public Task<List<Session>> GetSessions([ScopedService] ApplicationDbContext context) =>
            context.Sessions.ToListAsync();

        public Task<Session> GetSession(
            [ID(nameof(Session))] int id,
            SessionByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);

    }
}

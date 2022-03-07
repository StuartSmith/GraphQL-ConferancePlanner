using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferancePlanner.GraphQL.Data;
using ConferancePlanner.GraphQL.DataLoader;
using ConferancePlanner.GraphQL.Extensions;
using ConferencePlanner.GraphQL.Data;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;


namespace ConferancePlanner.GraphQL.Tracks
{
    [ExtendObjectType("Query")]
    public class TrackQueries
    {
        [UseApplicationDbContext]
        public Task<List<Track>> GetTracks([ScopedService] ApplicationDbContext context) =>
            context.Tracks.ToListAsync();

        public Task<Track> GetTracks(
            [ID(nameof(Track))] int id,
            TrackByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);

    }
}

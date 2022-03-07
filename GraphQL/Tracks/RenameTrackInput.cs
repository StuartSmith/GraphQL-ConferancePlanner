using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferancePlanner.GraphQL.Data;
using HotChocolate.Types.Relay;

namespace ConferancePlanner.GraphQL.Tracks
{
    public record RenameTrackInput([ID(nameof(Track))] int Id, string Name);
}

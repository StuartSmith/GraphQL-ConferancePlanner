using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Data;
using HotChocolate.Types.Relay;

namespace ConferancePlanner.GraphQL.Sessions
{
    public record AddSessionInput(
        string Title,
        string? Abstract,
        [ID(nameof(Speaker))]
        IReadOnlyList<int> SpeakerIds);
}

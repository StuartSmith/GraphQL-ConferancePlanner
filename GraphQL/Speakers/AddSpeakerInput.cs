using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferancePlanner.GraphQL
{
    public record AddSpeakerInput(
        string Name,
        string? Bio,
        string? WebSite);
}

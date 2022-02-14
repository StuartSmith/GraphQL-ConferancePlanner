using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Data;


namespace ConferancePlanner.GraphQL.Data
{
    public class SessionSpeaker
    {
        public int SessionId { get; set; }

        public Session? Session { get; set; }

        public int SpeakerId { get; set; }

        public Speaker? Speaker { get; set; }
    }
}

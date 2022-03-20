using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferancePlanner.GraphQL;
using ConferancePlanner.GraphQL.Sessions;
using ConferancePlanner.GraphQL.Tracks;
using ConferancePlanner.GraphQL.Types;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.Speakers;
using Microsoft.EntityFrameworkCore;


namespace ConferencePlanner.GraphQL
{
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }

        public IConfigurationRoot Configuration { get; }


      

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=localhost;Database=ConfPlanDB;User Id=ConPlanUser;Password=ConPlanPassword!;"));

            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<SpeakerQueries>()
                .AddTypeExtension<TrackQueries>()
                .AddTypeExtension<SessionQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<SessionMutations>()
                .AddTypeExtension<SpeakerMutations>()
                .AddTypeExtension<TrackMutations>()
                .AddType<AttendeeType>()
                .AddType<SessionType>()
                .AddType<SpeakerType>()
                .AddType<TrackType>()
                .EnableRelaySupport();
        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }


    }
}

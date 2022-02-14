using ConferancePlanner.GraphQL;
using ConferancePlanner.GraphQL.DataLoader;
using ConferancePlanner.GraphQL.Sessions;
using ConferancePlanner.GraphQL.Types;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.Speakers;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL
{
    public static class Startup
    {
        public static WebApplication InitializeApp(string[] args)
        {
         
            
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder);

            var app = builder.Build();

            Configure(app);

            return app;
        }

        private static void ConfigureServices( WebApplicationBuilder builder)
        {
            //Configure Services.
            builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=conferences.db"));

            builder.Services.AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<SpeakerQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<SessionMutations>()
                .AddTypeExtension<SpeakerMutations>()
                .AddType<AttendeeType>()
                .AddType<SessionType>()
                .AddType<SpeakerType>()
                .AddType<TrackType>()
                .EnableRelaySupport();


        }

        private static void Configure(WebApplication app)
        {
            //app.MapGet("/", () => "Hello World!");

            app.UseRouting();

            app.MapGraphQL("/");

        }


    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQL.Migrations
{
    public partial class UpdatingSessionsSpeakernull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionAttendee_Attendees_AttendeeId",
                table: "SessionAttendee");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionAttendee_Sessions_SessionId",
                table: "SessionAttendee");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionSpeaker_Sessions_SessionId",
                table: "SessionSpeaker");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionSpeaker_Speakers_SpeakerId",
                table: "SessionSpeaker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionSpeaker",
                table: "SessionSpeaker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionAttendee",
                table: "SessionAttendee");

            migrationBuilder.RenameTable(
                name: "SessionSpeaker",
                newName: "SessionSpeakers");

            migrationBuilder.RenameTable(
                name: "SessionAttendee",
                newName: "SessionAttendees");

            migrationBuilder.RenameIndex(
                name: "IX_SessionSpeaker_SpeakerId",
                table: "SessionSpeakers",
                newName: "IX_SessionSpeakers_SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_SessionAttendee_AttendeeId",
                table: "SessionAttendees",
                newName: "IX_SessionAttendees_AttendeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionSpeakers",
                table: "SessionSpeakers",
                columns: new[] { "SessionId", "SpeakerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionAttendees",
                table: "SessionAttendees",
                columns: new[] { "SessionId", "AttendeeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SessionAttendees_Attendees_AttendeeId",
                table: "SessionAttendees",
                column: "AttendeeId",
                principalTable: "Attendees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionAttendees_Sessions_SessionId",
                table: "SessionAttendees",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSpeakers_Sessions_SessionId",
                table: "SessionSpeakers",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSpeakers_Speakers_SpeakerId",
                table: "SessionSpeakers",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionAttendees_Attendees_AttendeeId",
                table: "SessionAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionAttendees_Sessions_SessionId",
                table: "SessionAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionSpeakers_Sessions_SessionId",
                table: "SessionSpeakers");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionSpeakers_Speakers_SpeakerId",
                table: "SessionSpeakers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionSpeakers",
                table: "SessionSpeakers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionAttendees",
                table: "SessionAttendees");

            migrationBuilder.RenameTable(
                name: "SessionSpeakers",
                newName: "SessionSpeaker");

            migrationBuilder.RenameTable(
                name: "SessionAttendees",
                newName: "SessionAttendee");

            migrationBuilder.RenameIndex(
                name: "IX_SessionSpeakers_SpeakerId",
                table: "SessionSpeaker",
                newName: "IX_SessionSpeaker_SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_SessionAttendees_AttendeeId",
                table: "SessionAttendee",
                newName: "IX_SessionAttendee_AttendeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionSpeaker",
                table: "SessionSpeaker",
                columns: new[] { "SessionId", "SpeakerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionAttendee",
                table: "SessionAttendee",
                columns: new[] { "SessionId", "AttendeeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SessionAttendee_Attendees_AttendeeId",
                table: "SessionAttendee",
                column: "AttendeeId",
                principalTable: "Attendees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionAttendee_Sessions_SessionId",
                table: "SessionAttendee",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSpeaker_Sessions_SessionId",
                table: "SessionSpeaker",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSpeaker_Speakers_SpeakerId",
                table: "SessionSpeaker",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFitnessJourney.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProgramArchive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "WorkoutPrograms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "WorkoutPrograms");
        }
    }
}

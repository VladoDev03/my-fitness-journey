using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFitnessJourney.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutProgramRelationsAddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WorkoutPrograms",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPrograms_UserId",
                table: "WorkoutPrograms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPrograms_AspNetUsers_UserId",
                table: "WorkoutPrograms",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPrograms_AspNetUsers_UserId",
                table: "WorkoutPrograms");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutPrograms_UserId",
                table: "WorkoutPrograms");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WorkoutPrograms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

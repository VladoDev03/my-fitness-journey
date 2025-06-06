using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFitnessJourney.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutProgramRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkoutDayId",
                table: "ProgramDayExercises",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PersonalBests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayExercises_WorkoutDayId",
                table: "ProgramDayExercises",
                column: "WorkoutDayId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalBests_UserId",
                table: "PersonalBests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalBests_AspNetUsers_UserId",
                table: "PersonalBests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramDayExercises_WorkoutDays_WorkoutDayId",
                table: "ProgramDayExercises",
                column: "WorkoutDayId",
                principalTable: "WorkoutDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalBests_AspNetUsers_UserId",
                table: "PersonalBests");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramDayExercises_WorkoutDays_WorkoutDayId",
                table: "ProgramDayExercises");

            migrationBuilder.DropIndex(
                name: "IX_ProgramDayExercises_WorkoutDayId",
                table: "ProgramDayExercises");

            migrationBuilder.DropIndex(
                name: "IX_PersonalBests_UserId",
                table: "PersonalBests");

            migrationBuilder.DropColumn(
                name: "WorkoutDayId",
                table: "ProgramDayExercises");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PersonalBests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

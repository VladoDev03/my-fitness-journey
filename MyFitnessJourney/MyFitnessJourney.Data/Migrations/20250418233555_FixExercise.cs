using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFitnessJourney.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalBests_Exercises_ExerciseId",
                table: "PersonalBests");

            migrationBuilder.DropIndex(
                name: "IX_PersonalBests_ExerciseId",
                table: "PersonalBests");

            migrationBuilder.AlterColumn<string>(
                name: "ExerciseId",
                table: "PersonalBests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExerciseId",
                table: "PersonalBests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalBests_ExerciseId",
                table: "PersonalBests",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalBests_Exercises_ExerciseId",
                table: "PersonalBests",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

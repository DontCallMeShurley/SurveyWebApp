using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_app.Migrations
{
    /// <inheritdoc />
    public partial class Добавитюзеракответам : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "SurveyAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_PersonId",
                table: "SurveyAnswers",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswers_Persons_PersonId",
                table: "SurveyAnswers",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAnswers_Persons_PersonId",
                table: "SurveyAnswers");

            migrationBuilder.DropIndex(
                name: "IX_SurveyAnswers_PersonId",
                table: "SurveyAnswers");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "SurveyAnswers");
        }
    }
}

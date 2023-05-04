using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_app.Migrations
{
    /// <inheritdoc />
    public partial class addreftoquestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "SurveyAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionsId",
                table: "SurveyAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_QuestionsId",
                table: "SurveyAnswers",
                column: "QuestionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswers_Questions_QuestionsId",
                table: "SurveyAnswers",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAnswers_Questions_QuestionsId",
                table: "SurveyAnswers");

            migrationBuilder.DropIndex(
                name: "IX_SurveyAnswers_QuestionsId",
                table: "SurveyAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "SurveyAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionsId",
                table: "SurveyAnswers");
        }
    }
}

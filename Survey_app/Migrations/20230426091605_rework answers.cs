using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_app.Migrations
{
    /// <inheritdoc />
    public partial class reworkanswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAnswers_AnswerTypes_AnswerTypeId",
                table: "SurveyAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAnswers_Users_UsersId",
                table: "SurveyAnswers");

            migrationBuilder.DropTable(
                name: "QuestionsAnswers");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "SurveyAnswers",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "AnswerTypeId",
                table: "SurveyAnswers",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyAnswers_UsersId",
                table: "SurveyAnswers",
                newName: "IX_SurveyAnswers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyAnswers_AnswerTypeId",
                table: "SurveyAnswers",
                newName: "IX_SurveyAnswers_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswers_Persons_PersonId",
                table: "SurveyAnswers",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswers_Questions_QuestionId",
                table: "SurveyAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAnswers_Persons_PersonId",
                table: "SurveyAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAnswers_Questions_QuestionId",
                table: "SurveyAnswers");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "SurveyAnswers",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "SurveyAnswers",
                newName: "AnswerTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyAnswers_QuestionId",
                table: "SurveyAnswers",
                newName: "IX_SurveyAnswers_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyAnswers_PersonId",
                table: "SurveyAnswers",
                newName: "IX_SurveyAnswers_AnswerTypeId");

            migrationBuilder.CreateTable(
                name: "QuestionsAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    SurveyAnswersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsAnswers_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionsAnswers_SurveyAnswers_SurveyAnswersId",
                        column: x => x.SurveyAnswersId,
                        principalTable: "SurveyAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsAnswers_QuestionsId",
                table: "QuestionsAnswers",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsAnswers_SurveyAnswersId",
                table: "QuestionsAnswers",
                column: "SurveyAnswersId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswers_AnswerTypes_AnswerTypeId",
                table: "SurveyAnswers",
                column: "AnswerTypeId",
                principalTable: "AnswerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswers_Users_UsersId",
                table: "SurveyAnswers",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

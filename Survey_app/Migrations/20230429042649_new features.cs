using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_app.Migrations
{
    /// <inheritdoc />
    public partial class newfeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAnswers_Persons_PersonId",
                table: "SurveyAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAnswers_Questions_QuestionId",
                table: "SurveyAnswers");

            migrationBuilder.DropIndex(
                name: "IX_SurveyAnswers_PersonId",
                table: "SurveyAnswers");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "SurveyAnswers");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "SurveyAnswers");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "SurveyAnswers",
                newName: "SurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyAnswers_QuestionId",
                table: "SurveyAnswers",
                newName: "IX_SurveyAnswers_SurveyId");

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyResponseId = table.Column<int>(type: "int", nullable: false),
                    SurveyAnswersId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_SurveyAnswers_SurveyAnswersId",
                        column: x => x.SurveyAnswersId,
                        principalTable: "SurveyAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultiAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyResponseId = table.Column<int>(type: "int", nullable: false),
                    SurveyAnswersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiAnswer_SurveyAnswers_SurveyAnswersId",
                        column: x => x.SurveyAnswersId,
                        principalTable: "SurveyAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultiValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MultiAnswerId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiValue_MultiAnswer_MultiAnswerId",
                        column: x => x.MultiAnswerId,
                        principalTable: "MultiAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_SurveyAnswersId",
                table: "Answer",
                column: "SurveyAnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiAnswer_SurveyAnswersId",
                table: "MultiAnswer",
                column: "SurveyAnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiValue_MultiAnswerId",
                table: "MultiValue",
                column: "MultiAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswers_Surveys_SurveyId",
                table: "SurveyAnswers",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAnswers_Surveys_SurveyId",
                table: "SurveyAnswers");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "MultiValue");

            migrationBuilder.DropTable(
                name: "MultiAnswer");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "SurveyAnswers",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyAnswers_SurveyId",
                table: "SurveyAnswers",
                newName: "IX_SurveyAnswers_QuestionId");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "SurveyAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "SurveyAnswers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswers_Questions_QuestionId",
                table: "SurveyAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_app.Migrations
{
    /// <inheritdoc />
    public partial class addreftoquestiononmultianswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurveyResponseId",
                table: "MultiAnswer");

            migrationBuilder.AddColumn<int>(
                name: "QuestionsId",
                table: "MultiAnswer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MultiAnswer_QuestionsId",
                table: "MultiAnswer",
                column: "QuestionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MultiAnswer_Questions_QuestionsId",
                table: "MultiAnswer",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MultiAnswer_Questions_QuestionsId",
                table: "MultiAnswer");

            migrationBuilder.DropIndex(
                name: "IX_MultiAnswer_QuestionsId",
                table: "MultiAnswer");

            migrationBuilder.DropColumn(
                name: "QuestionsId",
                table: "MultiAnswer");

            migrationBuilder.AddColumn<int>(
                name: "SurveyResponseId",
                table: "MultiAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

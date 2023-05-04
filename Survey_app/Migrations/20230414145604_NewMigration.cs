using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_app.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Question_types_Question_type_Id",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Question_types");

            migrationBuilder.DropIndex(
                name: "IX_Questions_Question_type_Id",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "Question_type_Id",
                table: "Questions",
                newName: "Question_types");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Question_types",
                table: "Questions",
                newName: "Question_type_Id");

            migrationBuilder.CreateTable(
                name: "Question_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question_types", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Question_type_Id",
                table: "Questions",
                column: "Question_type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Question_types_Question_type_Id",
                table: "Questions",
                column: "Question_type_Id",
                principalTable: "Question_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_app.Migrations
{
    /// <inheritdoc />
    public partial class removerequiredfield4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsGroups_UniversityCampuses_UniversityCampusId",
                table: "StudentsGroups");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityCampusId",
                table: "StudentsGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsGroups_UniversityCampuses_UniversityCampusId",
                table: "StudentsGroups",
                column: "UniversityCampusId",
                principalTable: "UniversityCampuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsGroups_UniversityCampuses_UniversityCampusId",
                table: "StudentsGroups");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityCampusId",
                table: "StudentsGroups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsGroups_UniversityCampuses_UniversityCampusId",
                table: "StudentsGroups",
                column: "UniversityCampusId",
                principalTable: "UniversityCampuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_app.Migrations
{
    /// <inheritdoc />
    public partial class removerequiredfield5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentsGroups_StudentsGroupsId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectsStudents_StudentsGroups_StudentsGroupsId",
                table: "SubjectsStudents");

            migrationBuilder.AlterColumn<int>(
                name: "StudentsGroupsId",
                table: "SubjectsStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentsGroupsId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentsGroups_StudentsGroupsId",
                table: "Students",
                column: "StudentsGroupsId",
                principalTable: "StudentsGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectsStudents_StudentsGroups_StudentsGroupsId",
                table: "SubjectsStudents",
                column: "StudentsGroupsId",
                principalTable: "StudentsGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentsGroups_StudentsGroupsId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectsStudents_StudentsGroups_StudentsGroupsId",
                table: "SubjectsStudents");

            migrationBuilder.AlterColumn<int>(
                name: "StudentsGroupsId",
                table: "SubjectsStudents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentsGroupsId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentsGroups_StudentsGroupsId",
                table: "Students",
                column: "StudentsGroupsId",
                principalTable: "StudentsGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectsStudents_StudentsGroups_StudentsGroupsId",
                table: "SubjectsStudents",
                column: "StudentsGroupsId",
                principalTable: "StudentsGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_app.Migrations
{
    /// <inheritdoc />
    public partial class removerequiredfields2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Lecturers_posts_Lecturers_post_ID",
                table: "Lecturers");

            migrationBuilder.AlterColumn<int>(
                name: "Lecturers_post_ID",
                table: "Lecturers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Lecturers_posts_Lecturers_post_ID",
                table: "Lecturers",
                column: "Lecturers_post_ID",
                principalTable: "Lecturers_posts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Lecturers_posts_Lecturers_post_ID",
                table: "Lecturers");

            migrationBuilder.AlterColumn<int>(
                name: "Lecturers_post_ID",
                table: "Lecturers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Lecturers_posts_Lecturers_post_ID",
                table: "Lecturers",
                column: "Lecturers_post_ID",
                principalTable: "Lecturers_posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

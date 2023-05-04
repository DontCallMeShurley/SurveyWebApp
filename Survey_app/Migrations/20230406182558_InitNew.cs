using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_app.Migrations
{
    /// <inheritdoc />
    public partial class InitNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answer_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers_posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers_posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Second_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sex_type = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Roles_types = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "University_campuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University_campuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Second_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sex_type = table.Column<int>(type: "int", nullable: false),
                    Date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lecturers_post_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecturers_Lecturers_posts_Lecturers_post_ID",
                        column: x => x.Lecturers_post_ID,
                        principalTable: "Lecturers_posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Person_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_Person_Id",
                        column: x => x.Person_Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Question_type_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Question_types_Question_type_Id",
                        column: x => x.Question_type_Id,
                        principalTable: "Question_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students_groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Creation_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    University_campus_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students_groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_groups_University_campuses_University_campus_Id",
                        column: x => x.University_campus_Id,
                        principalTable: "University_campuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects_lecturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lecturers_Id = table.Column<int>(type: "int", nullable: false),
                    Subject_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects_lecturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_lecturers_Lecturers_Lecturers_Id",
                        column: x => x.Lecturers_Id,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subjects_lecturers_Subjects_Subject_Id",
                        column: x => x.Subject_Id,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey_answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Answer_type_Id = table.Column<int>(type: "int", nullable: false),
                    Users_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey_answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survey_answers_Answer_types_Answer_type_Id",
                        column: x => x.Answer_type_Id,
                        principalTable: "Answer_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Survey_answers_Users_Users_Id",
                        column: x => x.Users_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Students_groups_ID = table.Column<int>(type: "int", nullable: false),
                    Person_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Persons_Person_ID",
                        column: x => x.Person_ID,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Students_groups_Students_groups_ID",
                        column: x => x.Students_groups_ID,
                        principalTable: "Students_groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects_students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subjects_lecturers_Id = table.Column<int>(type: "int", nullable: false),
                    Students_groups_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects_students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_students_Students_groups_Students_groups_Id",
                        column: x => x.Students_groups_Id,
                        principalTable: "Students_groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subjects_students_Subjects_lecturers_Subjects_lecturers_Id",
                        column: x => x.Subjects_lecturers_Id,
                        principalTable: "Subjects_lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Survey_status = table.Column<int>(type: "int", nullable: false),
                    Subjects_lecturers_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Subjects_lecturers_Subjects_lecturers_Id",
                        column: x => x.Subjects_lecturers_Id,
                        principalTable: "Subjects_lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions_answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Questions_Id = table.Column<int>(type: "int", nullable: false),
                    Survey_answers_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions_answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_answers_Questions_Questions_Id",
                        column: x => x.Questions_Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_answers_Survey_answers_Survey_answers_Id",
                        column: x => x.Survey_answers_Id,
                        principalTable: "Survey_answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey_questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Survey_Id = table.Column<int>(type: "int", nullable: false),
                    Questions_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey_questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survey_questions_Questions_Questions_Id",
                        column: x => x.Questions_Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Survey_questions_Surveys_Survey_Id",
                        column: x => x.Survey_Id,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_Lecturers_post_ID",
                table: "Lecturers",
                column: "Lecturers_post_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Question_type_Id",
                table: "Questions",
                column: "Question_type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_answers_Questions_Id",
                table: "Questions_answers",
                column: "Questions_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_answers_Survey_answers_Id",
                table: "Questions_answers",
                column: "Survey_answers_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Person_ID",
                table: "Students",
                column: "Person_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Students_groups_ID",
                table: "Students",
                column: "Students_groups_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_groups_University_campus_Id",
                table: "Students_groups",
                column: "University_campus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_lecturers_Lecturers_Id",
                table: "Subjects_lecturers",
                column: "Lecturers_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_lecturers_Subject_Id",
                table: "Subjects_lecturers",
                column: "Subject_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_students_Students_groups_Id",
                table: "Subjects_students",
                column: "Students_groups_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_students_Subjects_lecturers_Id",
                table: "Subjects_students",
                column: "Subjects_lecturers_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_answers_Answer_type_Id",
                table: "Survey_answers",
                column: "Answer_type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_answers_Users_Id",
                table: "Survey_answers",
                column: "Users_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_questions_Questions_Id",
                table: "Survey_questions",
                column: "Questions_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_questions_Survey_Id",
                table: "Survey_questions",
                column: "Survey_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_Subjects_lecturers_Id",
                table: "Surveys",
                column: "Subjects_lecturers_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Person_Id",
                table: "Users",
                column: "Person_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions_answers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects_students");

            migrationBuilder.DropTable(
                name: "Survey_questions");

            migrationBuilder.DropTable(
                name: "Survey_answers");

            migrationBuilder.DropTable(
                name: "Students_groups");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Answer_types");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "University_campuses");

            migrationBuilder.DropTable(
                name: "Question_types");

            migrationBuilder.DropTable(
                name: "Subjects_lecturers");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Lecturers_posts");
        }
    }
}

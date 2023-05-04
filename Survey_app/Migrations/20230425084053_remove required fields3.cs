using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_app.Migrations
{
    /// <inheritdoc />
    public partial class removerequiredfields3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Lecturers_posts_Lecturers_post_ID",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Persons_Person_ID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Students_groups_Students_groups_ID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Subjects_lecturers_Subjects_lecturers_Id",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Persons_Person_Id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Lecturers_posts");

            migrationBuilder.DropTable(
                name: "Questions_answers");

            migrationBuilder.DropTable(
                name: "Subjects_students");

            migrationBuilder.DropTable(
                name: "Survey_questions");

            migrationBuilder.DropTable(
                name: "Survey_answers");

            migrationBuilder.DropTable(
                name: "Students_groups");

            migrationBuilder.DropTable(
                name: "Subjects_lecturers");

            migrationBuilder.DropTable(
                name: "Answer_types");

            migrationBuilder.DropTable(
                name: "University_campuses");

            migrationBuilder.RenameColumn(
                name: "Person_Id",
                table: "Users",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Person_Id",
                table: "Users",
                newName: "IX_Users_PersonId");

            migrationBuilder.RenameColumn(
                name: "Survey_status",
                table: "Surveys",
                newName: "SurveyStatus");

            migrationBuilder.RenameColumn(
                name: "Subjects_lecturers_Id",
                table: "Surveys",
                newName: "SubjectsLecturersId");

            migrationBuilder.RenameColumn(
                name: "Start_date",
                table: "Surveys",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "End_date",
                table: "Surveys",
                newName: "EndDate");

            migrationBuilder.RenameIndex(
                name: "IX_Surveys_Subjects_lecturers_Id",
                table: "Surveys",
                newName: "IX_Surveys_SubjectsLecturersId");

            migrationBuilder.RenameColumn(
                name: "Students_groups_ID",
                table: "Students",
                newName: "StudentsGroupsId");

            migrationBuilder.RenameColumn(
                name: "Person_ID",
                table: "Students",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_Students_groups_ID",
                table: "Students",
                newName: "IX_Students_StudentsGroupsId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_Person_ID",
                table: "Students",
                newName: "IX_Students_PersonId");

            migrationBuilder.RenameColumn(
                name: "Question_types",
                table: "Questions",
                newName: "QuestionTypes");

            migrationBuilder.RenameColumn(
                name: "Sex_type",
                table: "Persons",
                newName: "SexType");

            migrationBuilder.RenameColumn(
                name: "Second_name",
                table: "Persons",
                newName: "SecondName");

            migrationBuilder.RenameColumn(
                name: "Roles_types",
                table: "Persons",
                newName: "RolesTypes");

            migrationBuilder.RenameColumn(
                name: "Last_name",
                table: "Persons",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "First_name",
                table: "Persons",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Sex_type",
                table: "Lecturers",
                newName: "SexType");

            migrationBuilder.RenameColumn(
                name: "Second_name",
                table: "Lecturers",
                newName: "SecondName");

            migrationBuilder.RenameColumn(
                name: "Lecturers_post_ID",
                table: "Lecturers",
                newName: "LecturersPostId");

            migrationBuilder.RenameColumn(
                name: "Last_name",
                table: "Lecturers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "First_name",
                table: "Lecturers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Date_of_birth",
                table: "Lecturers",
                newName: "DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturers_Lecturers_post_ID",
                table: "Lecturers",
                newName: "IX_Lecturers_LecturersPostId");

            migrationBuilder.CreateTable(
                name: "AnswerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LecturersPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturersPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsLecturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturersId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsLecturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectsLecturers_Lecturers_LecturersId",
                        column: x => x.LecturersId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsLecturers_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    QuestionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestions_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyQuestions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniversityCampuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityCampuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnswerTypeId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyAnswers_AnswerTypes_AnswerTypeId",
                        column: x => x.AnswerTypeId,
                        principalTable: "AnswerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyAnswers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityCampusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsGroups_UniversityCampuses_UniversityCampusId",
                        column: x => x.UniversityCampusId,
                        principalTable: "UniversityCampuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "SubjectsStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectsLecturersId = table.Column<int>(type: "int", nullable: false),
                    StudentsGroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectsStudents_StudentsGroups_StudentsGroupsId",
                        column: x => x.StudentsGroupsId,
                        principalTable: "StudentsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsStudents_SubjectsLecturers_SubjectsLecturersId",
                        column: x => x.SubjectsLecturersId,
                        principalTable: "SubjectsLecturers",
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

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroups_UniversityCampusId",
                table: "StudentsGroups",
                column: "UniversityCampusId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsLecturers_LecturersId",
                table: "SubjectsLecturers",
                column: "LecturersId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsLecturers_SubjectId",
                table: "SubjectsLecturers",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsStudents_StudentsGroupsId",
                table: "SubjectsStudents",
                column: "StudentsGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsStudents_SubjectsLecturersId",
                table: "SubjectsStudents",
                column: "SubjectsLecturersId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_AnswerTypeId",
                table: "SurveyAnswers",
                column: "AnswerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_UsersId",
                table: "SurveyAnswers",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_QuestionsId",
                table: "SurveyQuestions",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_SurveyId",
                table: "SurveyQuestions",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_LecturersPosts_LecturersPostId",
                table: "Lecturers",
                column: "LecturersPostId",
                principalTable: "LecturersPosts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Persons_PersonId",
                table: "Students",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentsGroups_StudentsGroupsId",
                table: "Students",
                column: "StudentsGroupsId",
                principalTable: "StudentsGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_SubjectsLecturers_SubjectsLecturersId",
                table: "Surveys",
                column: "SubjectsLecturersId",
                principalTable: "SubjectsLecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_LecturersPosts_LecturersPostId",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Persons_PersonId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentsGroups_StudentsGroupsId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_SubjectsLecturers_SubjectsLecturersId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "LecturersPosts");

            migrationBuilder.DropTable(
                name: "QuestionsAnswers");

            migrationBuilder.DropTable(
                name: "SubjectsStudents");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "SurveyAnswers");

            migrationBuilder.DropTable(
                name: "StudentsGroups");

            migrationBuilder.DropTable(
                name: "SubjectsLecturers");

            migrationBuilder.DropTable(
                name: "AnswerTypes");

            migrationBuilder.DropTable(
                name: "UniversityCampuses");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Users",
                newName: "Person_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                newName: "IX_Users_Person_Id");

            migrationBuilder.RenameColumn(
                name: "SurveyStatus",
                table: "Surveys",
                newName: "Survey_status");

            migrationBuilder.RenameColumn(
                name: "SubjectsLecturersId",
                table: "Surveys",
                newName: "Subjects_lecturers_Id");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Surveys",
                newName: "Start_date");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Surveys",
                newName: "End_date");

            migrationBuilder.RenameIndex(
                name: "IX_Surveys_SubjectsLecturersId",
                table: "Surveys",
                newName: "IX_Surveys_Subjects_lecturers_Id");

            migrationBuilder.RenameColumn(
                name: "StudentsGroupsId",
                table: "Students",
                newName: "Students_groups_ID");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Students",
                newName: "Person_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StudentsGroupsId",
                table: "Students",
                newName: "IX_Students_Students_groups_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_PersonId",
                table: "Students",
                newName: "IX_Students_Person_ID");

            migrationBuilder.RenameColumn(
                name: "QuestionTypes",
                table: "Questions",
                newName: "Question_types");

            migrationBuilder.RenameColumn(
                name: "SexType",
                table: "Persons",
                newName: "Sex_type");

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "Persons",
                newName: "Second_name");

            migrationBuilder.RenameColumn(
                name: "RolesTypes",
                table: "Persons",
                newName: "Roles_types");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Persons",
                newName: "Last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Persons",
                newName: "First_name");

            migrationBuilder.RenameColumn(
                name: "SexType",
                table: "Lecturers",
                newName: "Sex_type");

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "Lecturers",
                newName: "Second_name");

            migrationBuilder.RenameColumn(
                name: "LecturersPostId",
                table: "Lecturers",
                newName: "Lecturers_post_ID");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Lecturers",
                newName: "Last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Lecturers",
                newName: "First_name");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Lecturers",
                newName: "Date_of_birth");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturers_LecturersPostId",
                table: "Lecturers",
                newName: "IX_Lecturers_Lecturers_post_ID");

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
                name: "Survey_questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Questions_Id = table.Column<int>(type: "int", nullable: false),
                    Survey_Id = table.Column<int>(type: "int", nullable: false)
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
                name: "Survey_answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer_type_Id = table.Column<int>(type: "int", nullable: false),
                    Users_Id = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                name: "Students_groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    University_campus_Id = table.Column<int>(type: "int", nullable: false),
                    Creation_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                name: "Subjects_students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Students_groups_Id = table.Column<int>(type: "int", nullable: false),
                    Subjects_lecturers_Id = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Questions_answers_Questions_Id",
                table: "Questions_answers",
                column: "Questions_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_answers_Survey_answers_Id",
                table: "Questions_answers",
                column: "Survey_answers_Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Lecturers_posts_Lecturers_post_ID",
                table: "Lecturers",
                column: "Lecturers_post_ID",
                principalTable: "Lecturers_posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Persons_Person_ID",
                table: "Students",
                column: "Person_ID",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Students_groups_Students_groups_ID",
                table: "Students",
                column: "Students_groups_ID",
                principalTable: "Students_groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Subjects_lecturers_Subjects_lecturers_Id",
                table: "Surveys",
                column: "Subjects_lecturers_Id",
                principalTable: "Subjects_lecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Persons_Person_Id",
                table: "Users",
                column: "Person_Id",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

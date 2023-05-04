using Microsoft.AspNetCore.Mvc;
using Survey_app.Models;

namespace Survey_app.Dtos
{
    public class ReportDto
    {
        public Questions Questions { get; set; }
        public List<AnswersReport> AnswersReports { get; set; }
    }
    public class AnswersReport
    {
      public string NameAnswer { get; set; }
      public int CountAnswers { get; set; }
    }
}

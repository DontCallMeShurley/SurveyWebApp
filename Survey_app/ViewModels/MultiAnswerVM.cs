
namespace Survey_app.ViewModels
{
    public class MultiAnswerVM
    {
        public List<MultiValueVM> Values { get; set; }
    }

    public class CreateMultiAnswerVM
    {
        public int QuestionId { get; set; }
        public List<CreateMultiValueVM> Values { get; set; }
    }

}

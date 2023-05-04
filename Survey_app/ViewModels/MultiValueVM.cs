namespace Survey_app.ViewModels
{
    public class MultiValueVM
    {
        public string Value { get; set; }
    }

    public class CreateMultiValueVM : MultiValueVM
    {
        public int MultiAnswerId { get; set; }
    }
}

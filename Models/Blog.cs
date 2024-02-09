namespace Shop_App.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string Date { get; set; }
        public Category category { get; set; }
    }
}

namespace VivesBlog.Ui.Mvc.Models
{
    public class Article
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Content { get; set; }
        public required string Author { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

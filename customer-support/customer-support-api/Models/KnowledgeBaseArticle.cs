namespace customer_support_api.Models
{
    public class KnowledgeBaseArticle
    {
      

        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public HashSet<string> Tags{ get; set; }

        public KnowledgeBaseArticle(string id, string title, string content, string author, HashSet<string> tags)
        {
            Id = id;
            Title = title;
            Content = content;
            Author = author;
            Tags =new HashSet<string>();
        }
    }
}

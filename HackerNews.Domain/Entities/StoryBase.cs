namespace HackerNews.Domain.Entities
{
    public abstract class StoryBase
    {
        public string Title { get; set; }
        public int Score { get; set; }
    }
}

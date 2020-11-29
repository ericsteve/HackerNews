using System;

namespace HackerNews.Domain.Entities
{
    public class BestStory: StoryBase
    {
        public string Uri { get; set; }
        public string PostedBy { get; set; }
        public DateTime Time { get; set; }
        public int CommentCount { get; set; }
    }
}

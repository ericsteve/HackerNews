using System;
using System.Collections.Generic;

namespace HackerNews.Domain.Entities
{
    public class Story: StoryBase
    {
        public string By { get; set; }
        public int Descendants { get; set; }
        public int Id { get; set; }
        public IList<int> Kids { get; set; }
        public int Time { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }

        public BestStory ToBestStory()
        {
            return new BestStory
            {
                PostedBy = By,
                Title = Title,
                Score = Score,
                Time = new DateTime(Time),
                Uri = Url,
                CommentCount = Descendants
            };
        }
    }
}

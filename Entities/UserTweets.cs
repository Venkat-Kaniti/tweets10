using System.Collections.Generic;

namespace Tweets10.Entities
{
    public class UserTweets
    {
        public User User { get; set; }
        public IEnumerable<Tweet> Tweets { get; set; }
    }
}

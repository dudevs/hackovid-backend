using System.Collections.Generic;

namespace backend.Models
{
    /*
     * SupermarketData model
     * Contains the needed info to display a the timeline of basic goods for a given supermarket
     */
    public class SupermarketData
    {
        public string item { get; set; }
        public List<BasicGoodStatus> timeline { get; set; }

        public SupermarketData() { }
    }

    public class BasicGoodStatus
    {
        public long timestamp { get; set; }
        public int upvote { get; set; }
        public int downvote { get; set; }
        public BasicGoodStatus() { }
    }
}

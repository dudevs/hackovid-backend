using System;
using System.Collections.Generic;

namespace backend.Models
{
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

using System;
namespace backend.Models
{
    public class VoteRegistered
    {
        public string id { get; set; }
        public string basicGood { get; set; }
        public bool status { get; set; }
        public bool voteRegistered { get; set; }

        public VoteRegistered()
        {
        }
    }
}

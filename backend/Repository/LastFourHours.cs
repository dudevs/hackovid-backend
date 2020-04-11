using System;
using System.Collections.Generic;

namespace backend.Repository
{
    public partial class LastFourHours
    {
        public string Idshop { get; set; }
        public string Groupname { get; set; }
        public decimal? Unixtime { get; set; }
        public decimal? Positives { get; set; }
        public decimal? Negatives { get; set; }
    }
}

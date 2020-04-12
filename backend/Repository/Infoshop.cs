using System;
using System.Collections.Generic;

namespace backend.Repository
{
    public partial class Infoshop
    {
        public string Idshop { get; set; }
        public string Groupname { get; set; }
        public decimal Unixtime { get; set; }
        public decimal? Positives { get; set; }
        public decimal? Negatives { get; set; }

        public virtual GroupTypes GroupnameNavigation { get; set; }
        public virtual Shop IdshopNavigation { get; set; }
    }
}

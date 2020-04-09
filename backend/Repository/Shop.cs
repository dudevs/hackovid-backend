using System;
using System.Collections.Generic;

namespace backend.Repository
{
    public partial class Shop
    {
        public Shop()
        {
            Infoshop = new HashSet<Infoshop>();
        }

        public string Id { get; set; }
        public string Nom { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public virtual ICollection<Infoshop> Infoshop { get; set; }
    }
}

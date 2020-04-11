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
        public string Address { get; set; }
        public string City { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public virtual ICollection<Infoshop> Infoshop { get; set; }
    }
}

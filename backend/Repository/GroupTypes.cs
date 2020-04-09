using System;
using System.Collections.Generic;

namespace backend.Repository
{
    public partial class GroupTypes
    {
        public GroupTypes()
        {
            Infoshop = new HashSet<Infoshop>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Infoshop> Infoshop { get; set; }
    }
}

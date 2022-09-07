using System;
using System.Collections.Generic;

#nullable disable

namespace store.Model
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}

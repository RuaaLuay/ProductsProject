using System;
using System.Collections.Generic;

#nullable disable

namespace store.Model
{
    public partial class Item
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}

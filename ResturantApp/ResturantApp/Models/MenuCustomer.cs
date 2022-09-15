using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ResturantApp.Models
{
    public partial class MenuCustomer
    {
        public int Id { get; set; }
        public int Mid { get; set; }
        public int Cid { get; set; }

        [Timestamp]
        public DateTime CraetedDate { get; set; }

        [Timestamp]
        public DateTime UpdatedDate { get; set; }
        public bool Archived { get; set; }

        public virtual Customer CidNavigation { get; set; }
        public virtual RestaurantMenu MidNavigation { get; set; }
    }
}

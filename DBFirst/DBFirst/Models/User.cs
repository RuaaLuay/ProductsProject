using System;
using System.Collections.Generic;

#nullable disable

namespace DBFirst.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public byte Archived { get; set; }
    }
}

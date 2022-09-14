using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store.Model
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Image { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ConfirmPassword { get; set; }

        [Timestamp]
       // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDateUTC { get; set; }

        [Timestamp] // or 
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDateUTC { get; set; }

        public bool Archived { get; set; }
    }
}

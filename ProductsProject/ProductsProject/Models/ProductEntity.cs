using System.ComponentModel.DataAnnotations;

namespace ProductsProject.Models
{
    public class ProductEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }   
        public float price { get; set; }


    }
}

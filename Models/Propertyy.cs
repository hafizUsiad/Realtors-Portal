using System.ComponentModel.DataAnnotations.Schema;

namespace Real_Estate.Models
{
    public class Propertyy
    {
        public int Id { get; set; }


        public string Title { get; set; }

   
        public string Description { get; set; }

  
        public decimal Price { get; set; }

   
        public string Address { get; set; }

        public DateTime PostedDate { get; set; } = DateTime.Now;

        public string ImageUrl { get; set; } = "Nothing";
        [NotMapped]
        public IFormFile Image { get; set; }


    }

}

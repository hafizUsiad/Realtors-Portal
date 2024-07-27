namespace Real_Estate.Models
{
    public class propertyaddmodel
    {


        public string Title { get; set; }


        public string Description { get; set; }


        public decimal Price { get; set; }


        public string Address { get; set; }

        public DateTime PostedDate { get; set; } = DateTime.Now;

        public IFormFile Image { get; set; }
    }
}

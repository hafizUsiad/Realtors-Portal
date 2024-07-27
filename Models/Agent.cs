using System.ComponentModel.DataAnnotations;

namespace Real_Estate.Models
{
    public class Agent
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Email { get; set; }

        public string Phone { get; set; }
    }
}

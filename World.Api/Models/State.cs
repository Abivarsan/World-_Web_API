using System.ComponentModel.DataAnnotations;

namespace World.Api.Models
{
    public class State
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double ?Population { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}

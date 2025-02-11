using System.ComponentModel.DataAnnotations;

namespace World.Api.DTO.State
{
    public class CreateStateDto
    {
        [Required]
        public string Name { get; set; }
        public double? Population { get; set; }
        public int CountryId { get; set; }
    }
}

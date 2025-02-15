using System.ComponentModel.DataAnnotations;

namespace World.Api.DTO.State
{
    public class UpdateStateDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double? Population { get; set; }
        public int CountryId { get; set; }
    }
}

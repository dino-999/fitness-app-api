using System.ComponentModel.DataAnnotations;

namespace Fitness.Dtos
{

    public record CreateNewsDto
    {
        [Required]
        public string Title { get; init; }
        [Required]
        public string NewsInfo { get; init; }

        [Required]
        public int Category { get; init; }
    }
}
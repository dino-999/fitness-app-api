using System;
using System.ComponentModel.DataAnnotations;

namespace Fitness.Dtos
{

    public record CreateTrainingDateDto
    {
        [Required]
        public String Title { get; init; }

        [Required]
        public DateTimeOffset DateOfTraining { get; set; }

    }
}
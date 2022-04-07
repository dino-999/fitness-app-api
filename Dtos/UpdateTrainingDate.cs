using System;
using System.ComponentModel.DataAnnotations;

namespace Fitness.Dtos
{

    public record UpdateTrainingDateDto
    {
           [Required]
        public string Title { get; init; }

        [Required]
        public DateTimeOffset DateOfTraining { get; set; }
    }
}
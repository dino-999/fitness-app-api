using System;
using System.Collections.Generic;
using Fitness.Entities;

namespace Fitness.Dtos{

      public record TrainingDateDto {

        public Guid Id { get; init; }

         public string Title { get; set; }

         public List<String> People { get; set; }

        public DateTimeOffset DateOfTraining { get; init; }
    }

}
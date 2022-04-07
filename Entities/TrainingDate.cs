using System;
using System.Collections.Generic;

namespace Fitness.Entities{

    public record TrainingDate {

        public Guid Id { get; init; }
        public string Title { get; set; }

        public List<String> People { get; set; }
        public DateTimeOffset DateOfTraining { get; set; }
    }

}
using System;

namespace Fitness.Entities{

    public record News {

        public Guid Id { get; init; }
        public string Title { get; set; }
        public string NewsInfo { get; init; }

        public int Category { get; set; }

        public DateTimeOffset CreatedDate { get; init; }
    }

}
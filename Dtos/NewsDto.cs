using System;

namespace Fitness.Dtos{

      public record NewsDto {

        public Guid Id { get; init; }

         public string Title { get; set; }
        public string NewsInfo { get; init; }
        public int Category { get; set; }

        public DateTimeOffset CreatedDate { get; init; }
    }

}
using Fitness.Dtos;
using Fitness.Entities;

namespace Fitness{

    public static class Extensions{

        public static NewsDto AsDto(this News news){
            return new NewsDto
            {
                Id = news.Id,
                Title=news.Title,
                NewsInfo = news.NewsInfo,
                Category = news.Category,
                CreatedDate = news.CreatedDate

            };
        }

            public static TrainingDateDto AsDto(this TrainingDate td){
            return new TrainingDateDto
            {
                Id = td.Id,
                Title=td.Title,
                People=td.People,
                DateOfTraining = td.DateOfTraining

            };
        }

    }

}
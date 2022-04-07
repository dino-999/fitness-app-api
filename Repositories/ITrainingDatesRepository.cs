using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fitness.Entities;

namespace Fitness.Repositories{
    public interface ITrainingDatesRepository
    {
        Task<TrainingDate> GetTrainingDateAsync(Guid id);
        Task<IEnumerable<TrainingDate>> GetTrainingDatesAsync();

        Task CreateTrainingDateAsync(TrainingDate date);
        Task UpdateTrainingDateAsync(TrainingDate date);

        Task DeleteTrainingDateAsync(Guid id);

        Task InsertPeopleAsync(Guid id, String uid);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fitness.Entities;

namespace Fitness.Repositories{
    public interface INewsRepository
    {
        Task<News> GetNewAsync(Guid id);
        Task<IEnumerable<News>> GetNewsAsync();

        Task CreateNewsAsync(News news);
        Task UpdateNewsAsync(News news);

        Task DeleteNewsAsync(Guid id);
    }
}
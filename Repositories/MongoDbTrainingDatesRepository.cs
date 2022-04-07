using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fitness.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Fitness.Repositories{


    public class MongoDbTrainingDatesRepository : ITrainingDatesRepository
    {
        private const string dbName = "fitness";
        private const string collectionName = "training";
        private readonly IMongoCollection<TrainingDate> trainingDatesCollection;
        private readonly FilterDefinitionBuilder<TrainingDate> filterBuilder= Builders<TrainingDate>.Filter;
         private readonly UpdateDefinitionBuilder<TrainingDate> updateBuilder= Builders<TrainingDate>.Update;
        public MongoDbTrainingDatesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(dbName);
            trainingDatesCollection = database.GetCollection<TrainingDate>(collectionName);
        }
    
        public async Task CreateTrainingDateAsync(TrainingDate date)
        {
            await trainingDatesCollection.InsertOneAsync(date);
        }

    
        public async Task DeleteTrainingDateAsync(Guid id)
        {
           var filter= filterBuilder.Eq(news => news.Id,id);
            await trainingDatesCollection.DeleteOneAsync(filter);
        }

        public async Task<TrainingDate> GetTrainingDateAsync(Guid id)
        {
        var filter= filterBuilder.Eq(td => td.Id,id);
            return await  trainingDatesCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TrainingDate>> GetTrainingDatesAsync()
        {
             return await trainingDatesCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task InsertPeopleAsync(Guid id, String uid)
        {
            
             var filter= filterBuilder.Eq(td => td.Id,id);
             var update= updateBuilder.Push(e => e.People, uid);
             
             await trainingDatesCollection.FindOneAndUpdateAsync(filter,update);
        }

        public async Task UpdateTrainingDateAsync(TrainingDate date)
        {
             var filter= filterBuilder.Eq(existingTd => existingTd.Id,date.Id);
            await trainingDatesCollection.ReplaceOneAsync(filter, date);
        }
    }
}
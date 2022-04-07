using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fitness.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Fitness.Repositories{


    public class MongoDbNewsRepository : INewsRepository
    {
        private const string dbName = "fitness";
        private const string collectionName = "news";
        private readonly IMongoCollection<News> newsCollection;
        private readonly FilterDefinitionBuilder<News> filterBuilder= Builders<News>.Filter;
        public MongoDbNewsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(dbName);
            newsCollection = database.GetCollection<News>(collectionName);
        }
        public async Task CreateNewsAsync(News news)
        {
           await newsCollection.InsertOneAsync(news);
        }

        public async Task DeleteNewsAsync(Guid id)
        {
            var filter= filterBuilder.Eq(news => news.Id,id);
            await newsCollection.DeleteOneAsync(filter);
        }

        public async Task<News> GetNewAsync(Guid id)
        {
            var filter= filterBuilder.Eq(news => news.Id,id);
            return await  newsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<News>> GetNewsAsync()
        {
            return await newsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateNewsAsync(News news)
        {
            var filter= filterBuilder.Eq(existingNews => existingNews.Id,news.Id);
            await newsCollection.ReplaceOneAsync(filter, news);
        }
    }
}
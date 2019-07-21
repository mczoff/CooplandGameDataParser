using CooplandGameDataParser.DatabaseDefaultHandler.Models;
using CooplandGameDataParser.MongoHandler.Abstractrions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using CooplandGameDataParser.MongoHandler.Params;

namespace CooplandGameDataParser.MongoHandler.Models
{
    public class MongoHandler
        : IMongoHandler
    {
        readonly MongoHandlerParams _mongoHandlerParams;
        readonly IMongoClient _mongoClient;
        readonly IMongoDatabase _mongoDatabase;
        readonly IMongoCollection<GameInfo> _mongoCollection;

        public MongoHandler(MongoHandlerParams mongoHandlerParams)
        {
            _mongoHandlerParams = mongoHandlerParams;
            _mongoClient = new MongoClient(_mongoHandlerParams.ConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(_mongoHandlerParams.DatabaseName);
            _mongoCollection = _mongoDatabase.GetCollection<GameInfo>("gamesinfo");
        }

        public async Task AddAsync(GameInfo gameInfo)
        {
            await _mongoCollection.InsertOneAsync(gameInfo);
        }
    }
}

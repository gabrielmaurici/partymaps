using Microsoft.Extensions.Options;
using MongoDB.Driver;
using src.Domain.Entities;
using src.Domain.Models;
using src.Domain.Repositories;

namespace src.Infra.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly IMongoCollection<Chat> _chatCollection;

    public ChatRepository(IOptions<PartymapsDataBaseSettings> context)
    {
        var mongoClient = new MongoClient(context.Value.ConnectionString);

        var mongoDb = mongoClient.GetDatabase(context.Value.DatabaseName);

        _chatCollection = mongoDb.GetCollection<Chat>(context.Value.ChatCollectionName);
    }

    public async Task Save(Chat model)
    {
        await _chatCollection.InsertOneAsync(model);
    }

    public Task<Chat[]> Get()
    {
        throw new NotImplementedException();
    }
}
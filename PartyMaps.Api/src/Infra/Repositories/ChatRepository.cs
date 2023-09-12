using Microsoft.Extensions.Options;
using MongoDB.Driver;
using src.Domain.Dto;
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

    public ChatDto[] Get(int take, int limit = 10)
    {        
        return _chatCollection.AsQueryable()
            .OrderByDescending(x => x.SendDate)
            .Skip(take)
            .Take(limit)
            .Select(x => new ChatDto(
                x.User,
                x.Message,
                x.Picture,
                x.UserCode,
                x.SendDate,
                x.IdEvent
            ))
            .ToArray();
    }
}
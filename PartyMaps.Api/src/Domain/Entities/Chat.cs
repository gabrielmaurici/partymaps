using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace src.Domain.Entities;

public class Chat 
{
    public Chat(string user, string? message, string userCode, string? picture, DateTime sendDate, int idEvent)
    {
        User = user;
        Message = message;
        UserCode = userCode;
        Picture = picture;
        SendDate = sendDate;
        IdEvent = idEvent;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; private set; }

    public string User { get; private set; } = null!;

    public string? Message { get; private set; }

    public string UserCode { get; private set; } = null!;

    public string? Picture { get; private set; }

    public DateTime SendDate { get; private set; }

    public int IdEvent { get; private set; }
}
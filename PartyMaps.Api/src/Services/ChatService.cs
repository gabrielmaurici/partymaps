using src.Domain.Dto;
using src.Domain.Entities;
using src.Domain.Repositories;
using src.Domain.Services;

namespace src.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _chatRepository;

    public ChatService(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task Save(ChatDto model)
    {
        var chat = new Chat(
            model.User, model.Message,
            model.UserCod, model.Picture,
            model.SendDate, model.IdEvent
        );

        await _chatRepository.Save(chat);
    }

    public async Task<ChatDto[]> Get()
    {
        throw new NotImplementedException();
    }
}
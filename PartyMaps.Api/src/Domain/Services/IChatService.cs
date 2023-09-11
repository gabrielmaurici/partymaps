using src.Domain.Dto;

namespace src.Domain.Services;

public interface IChatService 
{
    Task Save(ChatDto model);

    Task<ChatDto[]> Get();
}
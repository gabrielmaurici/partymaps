using src.Domain.Dto;
using src.Domain.Entities;

namespace src.Domain.Repositories;

public interface IChatRepository 
{
    Task Save(Chat model);

    ChatDto[] Get(int take, int limit = 10);
}
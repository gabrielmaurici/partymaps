using src.Domain.Entities;

namespace src.Domain.Repositories;

public interface IChatRepository 
{
    Task Save(Chat model);

    Task<Chat[]> Get();
}
namespace src.Models.Dtos
{
    public record ResponseEventDto(int Id, string? IdCreator, string? Name, string? Description, decimal EventValue, DateTime EventDate, DateTime CreationDate, DateTime ChangeDate);
}
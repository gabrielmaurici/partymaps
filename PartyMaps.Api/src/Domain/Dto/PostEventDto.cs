namespace src.Domain.Dto;

public record PostEventDto(string? IdCreator, string? Name, string? Description, decimal EventValue, DateTime EventDate);
namespace PartyMaps.Api.src.Data.Dtos;

public record PostEventDto(string? IdCreator, string? Name, string? Description, decimal EventValue, DateTime EventDate);
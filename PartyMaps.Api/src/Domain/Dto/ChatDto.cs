namespace src.Domain.Dto;

public record ChatDto(
    string User,
    string? Message,
    string? Picture,
    string UserCod,
    DateTime SendDate,
    int IdEvent
);
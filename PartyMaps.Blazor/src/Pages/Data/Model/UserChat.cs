namespace PartyMaps.Blazor.Pages.Data
{
    public record UserChat(
        string User,
        string? Message,
        string? Picture,
        string Css,
        DateTime SendDate,
        bool IsNotifyUserEntering
    );
}
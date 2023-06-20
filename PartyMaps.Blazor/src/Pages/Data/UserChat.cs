namespace PartyMaps.Blazor.Pages.Data
{
    public record UserChat(
        string User,
        string Message,
        string picture,
        string Css,
        DateTime SendDate,
        bool IsNotifyUserEntering
    );
}
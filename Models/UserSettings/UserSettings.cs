namespace BracketApp.Api.Models.UserSettings
{
    public class UserSettings : Document
    {
        public string Primary { get; set; }

        public string Secondary { get; set; }

        public string Tertiary { get; set; }

    }
}
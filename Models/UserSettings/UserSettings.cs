namespace BracketApp.Api.Models.UserSettings
{
    public class UserSettings : Document
    {
        public UserSettings()
        {
            
        }

        public UserSettings(CreateUserSettingsViewModel viewModel, string ownerId) : base(ownerId)
        {
            Primary = viewModel.Primary;
            Secondary = viewModel.Secondary;
            Tertiary = viewModel.Tertiary;
        }
        public string Primary { get; set; }

        public string Secondary { get; set; }

        public string Tertiary { get; set; }

    }
}
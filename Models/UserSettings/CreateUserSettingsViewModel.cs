using System.ComponentModel.DataAnnotations;

namespace BracketApp.Api.Models.UserSettings
{
    public class CreateUserSettingsViewModel
    {
        [Required]
        public string Primary { get; set; }

        [Required]
        public string Secondary { get; set; }

        [Required]
        public string Tertiary { get; set; }

    }
}
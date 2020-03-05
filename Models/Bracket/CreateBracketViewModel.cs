using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BracketApp.Api.Models.Bracket
{
    public class CreateBracketViewModel
    {
        [Required]
        public string BracketName { get; set; }
        [Required]
        public List<string> Seeds { get; set; }

        [Required]
        public List<string> Winners { get; set; }

        [Required]
        public List<string> Losers { get; set; }
    }
}

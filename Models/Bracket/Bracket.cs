using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BracketApp.Api.Models.Bracket
{
    public class Bracket : Document
    {
        public Bracket()
        {

        }

        public Bracket(CreateBracketViewModel viewModel, string ownerId) : base(ownerId)
        {
            BracketName = viewModel.BracketName;
            Seeds = viewModel.Seeds;
            Winners = viewModel.Winners;
            Losers = viewModel.Losers;
        }

        public string BracketName { get; set; }

        public List<string> Seeds { get; set; }

        public List<string> Winners { get; set; }

        public List<string> Losers { get; set; }
    }
}

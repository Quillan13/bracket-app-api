using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BracketApp.Api.Models.Bracket;
using BracketApp.Api.Repositories;
using System.Collections.Generic;

namespace BracketApp.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BracketController : DocumentController
    {
        private readonly BracketRepository bracketRepository;

        public BracketController(BracketRepository bracketRepository) => this.bracketRepository = bracketRepository;

        [HttpGet("{id:length(24)}")]
        public ActionResult<Bracket> GetById(string id)
        {
            Bracket bracket = bracketRepository.Get(id);

            if (bracket == null)
                return NotFound();

            if (bracket.OwnerId != GetUserId())
                return Unauthorized();

            return bracket;
        }

        [HttpGet("ByOwner")]
        public ActionResult<List<Bracket>> GetByOwnerId()
        {
            List<Bracket> bracket = bracketRepository.GetByOwnerId(GetUserId());

            if (bracket == null)
                return NotFound();

            return bracket;
        }


        [HttpPost]
        public ActionResult<Bracket> Create(CreateBracketViewModel model)
        {
            var bracket = new Bracket(model, GetUserId());

            bracketRepository.Create(bracket);

            return CreatedAtAction(actionName: "GetById", new { id = bracket.Id.ToString() }, bracket);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Bracket bracket)
        {
            Bracket existingEvent = bracketRepository.Get(id);

            if (existingEvent == null)
                return NotFound();

            if (existingEvent.OwnerId != GetUserId())
                return Unauthorized();

            bracketRepository.Update(id, bracket);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var bracket = bracketRepository.Get(id);

            if (bracket.OwnerId != GetUserId())
                return Unauthorized();

            bracketRepository.Remove(id);

            return NoContent();

        }
    }
}
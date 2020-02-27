using BracketApp.Api.Models.UserSettings;
using BracketApp.Api.Models;
using BracketApp.Api.Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BracketApp.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserSettingsController : DocumentController
    {
        private readonly UserSettingsRepository userSettingsRepository;

        public UserSettingsController(UserSettingsRepository userSettingsRepository) => this.userSettingsRepository = userSettingsRepository;

        [HttpGet("{id:length(24)}")]
        public ActionResult<UserSettings> GetById(string id)
        {
            UserSettings userSettings = userSettingsRepository.Get(id);

            if (userSettings == null)
                return NotFound();

            if (userSettings.OwnerId != GetUserId())
                return Unauthorized();

            return userSettings;
        }

        [HttpPost]
        public ActionResult<UserSettings> Create(CreateUserSettingsViewModel model)
        {
            var userSettings = new UserSettings(model, GetUserId());

            userSettingsRepository.Create(userSettings);

            return CreatedAtAction(actionName: "GetById", new { id = userSettings.Id.ToString() }, userSettings);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, UserSettings userSettings)
        {
            UserSettings existingEvent = userSettingsRepository.Get(id);

            if (existingEvent == null)
                return NotFound();

            if (existingEvent.OwnerId != GetUserId())
                return Unauthorized();

            userSettingsRepository.Update(id, userSettings);

            return NoContent();
        }


    }
}
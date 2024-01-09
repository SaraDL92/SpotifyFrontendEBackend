using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Spotify_DataLayer.Models;
using SpotiAPI.Service.Interfaces;
using System.IO;

namespace SpotiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {





        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Setting>> Get()

        {
            var settings = _settingService.GetAllSettings();
            return Ok(settings);
        }

        [HttpGet("{id}", Name = "GetSingleSetting")]
        public ActionResult<Setting> GetSingle(int id)
        {
            var setting = _settingService.GetSingleSetting(id);
            if (setting == null)
            {
                return NotFound();
            }

            return Ok(setting);
        }

        [HttpPost]
        public ActionResult<Setting> Post([FromBody] Setting setting)
        {
            if (setting == null)
            {
                return BadRequest("Invalid request body");
            }
            try
            {
                _settingService.CreateSetting(setting.LightTheme,setting.GoldPlan,  setting.FreePlan,
                    setting.PremiumPlan,setting.User,setting.SelectedTimeZoneId
              
                
             




                    );
                return CreatedAtAction("GetSingleSetting", new { id = setting.Id_Setting }, setting);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:{ex.Message}");
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateSetting(int id, [FromBody] Setting updatedSetting)
        {
            var existingSetting = _settingService.GetSingleSetting(id);
            if (existingSetting == null)
            {
                NotFound();
            }
            existingSetting.PremiumPlan = updatedSetting.PremiumPlan;
            existingSetting.GoldPlan = updatedSetting.GoldPlan;
            existingSetting.FreePlan = updatedSetting.FreePlan;
            existingSetting.User = updatedSetting.User;
           existingSetting.LightTheme= updatedSetting.LightTheme;
            existingSetting.SelectedTimeZoneId= updatedSetting.SelectedTimeZoneId;

            _settingService.UpdateSetting(id, existingSetting);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _settingService.Delete(id);

            if (result == "Item deleted")
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

    }
}

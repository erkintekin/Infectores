using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.BusinessLayer.Abstract;
using Backend.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    public class ProficiencyController : ControllerBase
    {
        private readonly IProficiencyService _proficiencyService;

        public ProficiencyController(IProficiencyService proficiencyService)
        {
            _proficiencyService = proficiencyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProficiencies()
        {
            return Ok(await _proficiencyService.GetAllProficiencies());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProficiencyById(int id)
        {
            var proficiency = await _proficiencyService.GetProficiencyById(id);
            if (proficiency == null)
                return NotFound(new { message = "Proficiency not found" });

            return Ok(proficiency);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProficiency([FromBody] Proficiency proficiency)
        {
            await _proficiencyService.CreateProficiency(proficiency);
            return Ok(new { message = "Proficiency created successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProficiency([FromBody] Proficiency proficiency)
        {
            await _proficiencyService.UpdateProficiency(proficiency);
            return Ok(new { message = "Proficiency updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProficiency(int id)
        {
            var result = await _proficiencyService.DeleteProficiency(id);
            if (!result)
                return NotFound(new { message = "Proficiency not found" });

            return Ok(new { message = "Proficiency deleted successfully" });
        }

        [HttpGet("character/{characterId}")]
        public async Task<IActionResult> GetAllCharProficiencies(int characterId)
        {
            return Ok(await _proficiencyService.GetAllCharProficiencies(characterId));
        }

        [HttpPost("character/{characterId}/add/{proficiencyId}")]
        public async Task<IActionResult> AddProficiencyToCharacter(int characterId, int proficiencyId)
        {
            var result = await _proficiencyService.AddProficiencyToCharacter(characterId, proficiencyId);
            return Ok(result);
        }

        [HttpDelete("character/{characterId}/remove/{proficiencyId}")]
        public async Task<IActionResult> DeleteCharacterProficiency(int characterId, int proficiencyId)
        {
            var result = await _proficiencyService.DeleteCharacterProficiency(characterId, proficiencyId);
            if (!result)
                return NotFound(new { message = "Proficiency not found for this character" });

            return Ok(new { message = "Proficiency removed successfully" });
        }
    }

}
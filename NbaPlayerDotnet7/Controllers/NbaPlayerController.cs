using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NbaPlayerDotnet7.Services.Interface;

namespace NbaPlayerDotnet7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NbaPlayerController : ControllerBase
    {
        private readonly INbaPlayerService _nbaPlayerService;

        public NbaPlayerController(INbaPlayerService nbaPlayerService)
        {
            _nbaPlayerService = nbaPlayerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<NbaPlayer>>> GetAllPlayers()
        {
            return await _nbaPlayerService.GetAllPlayers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NbaPlayer>> GetSinglePlayer(int id)
        {
            var result = await _nbaPlayerService.GetSinglePlayer(id);
            if (result is null)
                return NotFound("Player not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<NbaPlayer>>> AddPlayer(NbaPlayer player)
        {
            var result = await _nbaPlayerService.AddPlayer(player);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<NbaPlayer>>> UpdatePlayer(int id, NbaPlayer request)
        {
            var result = await _nbaPlayerService.UpdatePlayer(id, request);
            if (result is null)
                return NotFound("Player not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<NbaPlayer>>> DeletePlayer(int id)
        {
            var result = await _nbaPlayerService.DeletePlayer(id);
            if (result is null)
                return NotFound("Player not found.");

            return Ok(result);
        }
    }
}
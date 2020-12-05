using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Secretary.Application.Abstract;
using Secretary.Application.DTOs.Requests;

namespace Secretary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrowdController : ControllerBase
    {
        private readonly ICrowdService _crowdService;

        public CrowdController(ICrowdService crowdService)
        {
            _crowdService = crowdService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCrowdsRequestDTO request)
        {
            var result = await _crowdService.GetCrowds(request);
            return Ok(result);
        }

        [HttpPost("random/add/{count}")]
        public async Task<IActionResult> PostRandomCrowds([FromRoute] int count = 1000)
        {
            await _crowdService.CreateRandomCrowds(count);
            return Ok();
        }
    }
}

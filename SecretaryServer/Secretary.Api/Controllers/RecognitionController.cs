using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Secretary.Application.Abstract;
using Secretary.Application.DTOs.Requests;

namespace Secretary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecognitionController : ControllerBase
    {
        private readonly IRecognitionService _recognitionService;
        public RecognitionController(IRecognitionService recognitionService)
        {
            _recognitionService = recognitionService;
        }

        [HttpPost("Recognize/{languageCode}")]
        public async Task<IActionResult> Recognize([FromRoute] string languageCode, IFormFile file, CancellationToken cancellationToken = default)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream, cancellationToken);
                await _recognitionService.Recognize(new RecognitionRequestDTO()
                {
                    File = memoryStream,
                    LanguageCode = languageCode
                }, cancellationToken);
            }
            return Ok();
        }
    }
}

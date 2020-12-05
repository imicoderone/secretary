using Secretary.Application.Abstract;
using Secretary.Application.DTOs.Requests;
using Secretary.Application.DTOs.Responses;
using Secretary.Infrastructure;
using Secretary.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Secretary.Application.Services
{
    public class RecognitionService : IRecognitionService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IRecognitionApi _recognitionApi;

        public RecognitionService(
            ApplicationDbContext dbContext,
            IRecognitionApi recognitionApi)
        {
            _dbContext = dbContext;
            _recognitionApi = recognitionApi;
        }

        public async Task<RecognitionResponseDTO> Recognize(RecognitionRequestDTO dto, CancellationToken cancellationToken = default)
        {
            var response = await _recognitionApi.Recognize(dto.File.ToArray(), dto.LanguageCode);
            var alternative = response?.Results?.FirstOrDefault()?.Alternatives?.FirstOrDefault();
            return new RecognitionResponseDTO()
            {
                Transcript = alternative.Transcript,
                Confidence = alternative.Confidence
            };
        }
    }
}

using Google.Cloud.Speech.V1P1Beta1;
using Secretary.Infrastructure.Abstract;
using Secretary.Infrastructure.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Secretary.Infrastructure.Apis
{
    public class GoogleRecognitionApi : IRecognitionApi
    {
        public async Task<RecognitionResponseModel> Recognize(byte[] file, string languageCode, CancellationToken cancellationToken = default)
        {
            var speech = SpeechClient.Create();
            var response = await speech.RecognizeAsync(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.OggOpus,
                LanguageCode = "uz-UZ",
                SampleRateHertz = 48000
            }, 
            RecognitionAudio.FromBytes(file), 
            cancellationToken);
            
            var alternative = response?.Results?.FirstOrDefault()?.Alternatives?.FirstOrDefault();
            return new RecognitionResponseModel()
            {
                Transcript = alternative?.Transcript,
                Confidence = alternative?.Confidence ?? 0,
                Words = alternative?.Words.Select(p => new Models.WordInfo { Confidence = p.Confidence, EndTime = p.EndTime.ToTimeSpan().ToString(), SpeakerTag = p.SpeakerTag, StartTime = p.StartTime.ToTimeSpan().ToString(), Word = p.Word }).ToArray()
            };
        }
    }
}

using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Secretary.Infrastructure.Abstract;
using Secretary.Infrastructure.Configuration;
using Secretary.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Secretary.Infrastructure.Apis
{
    public class GoogleRecognitionApi : IRecognitionApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly RecognitionApiConfiguration _recognitionApiConfiguration;
        private readonly GoogleApiConfiguration _googleApiConfiguration;

        public GoogleRecognitionApi(
            IHttpClientFactory httpClientFactory,
            IOptions<RecognitionApiConfiguration> recognitionApiConfiguration,
            IOptions<GoogleApiConfiguration> googleApiConfiguration
            )
        {
            _httpClientFactory = httpClientFactory;
            _recognitionApiConfiguration = recognitionApiConfiguration.Value;
            _googleApiConfiguration = googleApiConfiguration.Value;
        }

        public async Task<RecognitionResponseModel> Recognize(byte[] file, string languageCode, CancellationToken cancellationToken = default)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(
                    new RecognitionRequestModel()
                        {
                            Audio = new RecognitionAudio()
                            {
                                Content = file.ToString()
                            },
                            Config = new RecognitionConfig()
                            {
                                LanguageCode = languageCode
                            }
                        })
                    );

                HttpResponseMessage response;
                switch (_recognitionApiConfiguration.Method)
                {
                    case "GET":
                        response = await client.GetAsync(_recognitionApiConfiguration.Url, cancellationToken);
                        break;
                    case "POST":
                        response = await client.PostAsync(_recognitionApiConfiguration.Url, content, cancellationToken);
                        break;
                    default:
                        throw new Exception("Method of Recognition Endpoint is not set");
                }

                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<RecognitionResponseModel>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}

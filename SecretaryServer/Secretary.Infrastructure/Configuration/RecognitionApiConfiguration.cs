using System;
using System.Collections.Generic;
using System.Text;

namespace Secretary.Infrastructure.Configuration
{
    public class RecognitionApiConfiguration
    {
        public const string Key = "RecognitionApiConfig";

        public string Url { get; set; }
        public string Method { get; set; }
    }
}

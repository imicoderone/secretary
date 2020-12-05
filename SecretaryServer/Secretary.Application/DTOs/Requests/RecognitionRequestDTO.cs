using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Secretary.Application.DTOs.Requests
{
    public class RecognitionRequestDTO
    {
        public MemoryStream File { get; set; }
        public string LanguageCode { get; set; }
    }
}

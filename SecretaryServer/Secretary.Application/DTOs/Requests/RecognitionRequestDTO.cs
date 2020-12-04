using System;
using System.Collections.Generic;
using System.Text;

namespace Secretary.Application.DTOs.Requests
{
    public class RecognitionRequestDTO
    {
        public byte[] File { get; set; }
        public string LanguageCode { get; set; }
    }
}

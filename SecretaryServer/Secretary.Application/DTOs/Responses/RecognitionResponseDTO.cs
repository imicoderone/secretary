using System;
using System.Collections.Generic;
using System.Text;

namespace Secretary.Application.DTOs.Responses
{
    public class RecognitionResponseDTO
    {
        public string Transcript { get; set; }
        public double Confidence { get; set; }
    }
}

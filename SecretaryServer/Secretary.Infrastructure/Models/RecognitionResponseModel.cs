using System;
using System.Collections.Generic;
using System.Text;

namespace Secretary.Infrastructure.Models
{
    public class RecognitionResponseModel
    {
        public string Transcript { get; set; }
        public double Confidence { get; set; }
        public WordInfo[] Words { get; set; }
    }

    public class WordInfo
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Word { get; set; }
        public double Confidence { get; set; }
        public int SpeakerTag { get; set; }
    }
}

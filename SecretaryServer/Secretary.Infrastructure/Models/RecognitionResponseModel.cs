using System;
using System.Collections.Generic;
using System.Text;

namespace Secretary.Infrastructure.Models
{
    public class RecognitionResponseModel
    {
        public SpeechRecognitionResult[] Results { get; set; }
    }

    public class SpeechRecognitionResult
    {
        public SpeechRecognitionAlternative[] Alternatives { get; set; }
        public int ChannelTag { get; set; }
        public string LanguageCode { get; set; }
    }

    public class SpeechRecognitionAlternative
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

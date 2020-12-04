using System;
using System.Collections.Generic;
using System.Text;

namespace Secretary.Infrastructure.Models
{
    public class RecognitionRequestModel
    {
        public RecognitionConfig Config { get; set; }
        public RecognitionAudio Audio { get; set; }
    }

    public class RecognitionConfig
    {
        public AudioEncoding Encoding { get; set; }
        public int SampleRateHertz { get; set; }
        public int AudioChannelCount { get; set; }
        public bool EnableSeparateRecognitionPerChannel { get; set; }
        public string LanguageCode { get; set; }
        public string[] AlternativeLanguageCodes { get; set; }
        public int MaxAlternatives { get; set; }
        public bool ProfanityFilter { get; set; }
        public SpeechContext[] SpeechContexts { get; set; }
        public bool EnableWordTimeOffsets { get; set; }
        public bool EnableWordConfidence { get; set; }
        public bool EnableAutomaticPunctuation { get; set; }
        public bool EnableSpeakerDiarization { get; set; }
        public int DiarizationSpeakerCount { get; set; }
        public SpeakerDiarizationConfig DiarizationConfig { get; set; }
        public string Model { get; set; }
        public bool UseEnhanced { get; set; }
    }

    public class SpeechContext
    {
        public string[] Phrases { get; set; }
        public double Boost { get; set; }
    }

    public class SpeakerDiarizationConfig
    {
        public bool EnableSpeakerDiarization { get; set; }
        public int MinSpeakerCount { get; set; }
        public int MaxSpeakerCount { get; set; }
        public int SpeakerTag { get; set; }
    }

    public enum AudioEncoding
    {
        ENCODING_UNSPECIFIED,
        LINEAR16,
        FLAC,
        MULAW,
        AMR,
        AMR_WB,
        OGG_OPUS,
        SPEEX_WITH_HEADER_BYTE,
        MP3
    }

    public class RecognitionAudio
    {
        public string Content { get; set; }
        public string Uri { get; set; }
    }
}

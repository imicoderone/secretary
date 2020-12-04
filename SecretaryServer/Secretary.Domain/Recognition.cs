using System;

namespace Secretary.Domain
{
    public class Recognition
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public string Transcript { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

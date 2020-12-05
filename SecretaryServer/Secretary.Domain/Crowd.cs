using System;
using System.Collections.Generic;
using System.Text;

namespace Secretary.Domain
{
    public class Crowd
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

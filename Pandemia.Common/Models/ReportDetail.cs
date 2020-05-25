using System;

namespace Pandemic.Common.Models
{
    public class ReportDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public double SourceLatitude { get; set; }

        public double TargetLongitude { get; set; }

        public DateTime DateLocal { get; set; }

        public string Observation { get; set; }

        public string Status { get; set; }
    }
}

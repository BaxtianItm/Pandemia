using System;
using System.Collections.Generic;
using System.Text;

namespace Pandemic.Common.Models
{
    public class MyReportsResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public double SourceLatitude { get; set; }

        public double TargetLongitude { get; set; }
        public ICollection<ReportDetailsResponse> ReportDetails { get; set; }

    }
}

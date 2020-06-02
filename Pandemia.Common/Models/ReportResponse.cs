using System.Collections.Generic;

namespace Pandemic.Common.Models
{
    public class ReportResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }
        public string Address { get; set; }

        public double SourceLatitude { get; set; }

        public double SourceLongitude { get; set; }

        public double TargetLatitude { get; set; }

        public double TargetLongitude { get; set; }

        public List<ReportDetailsResponse> ReportDetails { get; set; }

        public UserResponse User { get; set; }

        public CitiesResponse City { get; set; }
    }
}

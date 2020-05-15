using System;
using System.Collections.Generic;
using System.Text;

namespace Pandemic.Common.Models
{
    public class ReportDetailsResponse
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateLocal => Date.ToLocalTime();

        public string Observation { get; set; }

        public string Status { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Pandemic.Common.Models
{
    public class ReportDetailRequest
    {

        public string Observation { get; set; }

        public int StatusId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public int ReportId { get; set; }
        [Required]
        public string CultureInfo { get; set; }
    }
}

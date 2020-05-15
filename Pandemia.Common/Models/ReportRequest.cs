using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pandemic.Common.Models
{
    public class ReportRequest
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public Guid UserId { get; set; }


    }
}

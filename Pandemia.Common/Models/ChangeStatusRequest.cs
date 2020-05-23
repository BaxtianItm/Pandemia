using System;
using System.ComponentModel.DataAnnotations;

namespace Pandemic.Common.Models
{
    public class ChangeStatusRequest
    {
        public int Id { get; set; }

        public int StatusId { get; set; }

        [Required]
        public string CultureInfo { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public Guid UserId { get; set; }
    }
}

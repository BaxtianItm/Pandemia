using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandemic.Web.Models
{
    public class EditReportDetailsViewModel
    {
        public int Id { get; set; }

        public string Observation { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<SelectListItem> Status { get; set; }
        public int StatusId { get; set; }

    }
}

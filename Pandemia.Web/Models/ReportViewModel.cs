using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandemic.Web.Models
{
    public class ReportViewModel
    {
        public int Id { get; set; }

     
        public string FirstName { get; set; }
 
        public string LastName { get; set; }
        public string Document { get; set; }

        public double SourceLatitude { get; set; }

        public double SourceLongitude { get; set; }

        public double TargetLatitude { get; set; }

        public double TargetLongitude { get; set; }

        public string Status { get; set; }

        public string City { get; set; }

        public IEnumerable<SelectListItem> Details { get; set; }



    }
}

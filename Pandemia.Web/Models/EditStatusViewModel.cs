using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandemic.Web.Models
{
    public class EditStatusViewModel
    {
        public IEnumerable<SelectListItem> Status { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }

    }
}

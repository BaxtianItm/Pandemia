using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pandemic.Common.Enums;
using Pandemic.Web.Data.Entities;

namespace Pandemic.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboRoles();
        UserType GetComboRoles(int Id);
        IEnumerable<SelectListItem> GetComboStatus();
        //Status GetComboStatus(int Id);
    }
}

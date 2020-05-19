using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Pandemic.Common.Enums;
using System.Threading.Tasks;
using Pandemic.Web.Data.Entities;

namespace Pandemic.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {

        public IEnumerable<SelectListItem> GetComboRoles()
        {
            List<SelectListItem> list = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "[Select a role...]" },
                new SelectListItem { Value = "1", Text = "Admin" },
                new SelectListItem { Value = "2", Text = "User" },
                new SelectListItem { Value = "3", Text = "Emergency" }
            };

            return list;
        }


        public UserType GetComboRoles(int id)
        {
            switch (id)
            {
                case 1:
                    return UserType.Admin;
                case 2:
                    return UserType.User;
                case 3:
                    return UserType.Emergency;
            }
            return UserType.User;
        }

        public IEnumerable<SelectListItem> GetComboStatus()
        {
            List<SelectListItem> list = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "[Select a status...]" },
                new SelectListItem { Value = "1", Text = "Accepted" },
                new SelectListItem { Value = "2", Text = "Pending" },
                new SelectListItem { Value = "3", Text = "Rejected" }
            };

            return list;

        }

       /* public Status GetComboStatus(int Id)
        {
            throw new NotImplementedException();
        }*/
    }
}

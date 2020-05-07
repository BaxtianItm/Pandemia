using Pandemic.Common.Models;
using Pandemic.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandemic.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public UserResponse ToUserResponse(UserEntity user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserResponse
            {
                Address = user.Address,
                Document = user.Document,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PicturePath = user.PicturePath,
                UserType = user.UserType
            };

        }
    }
}

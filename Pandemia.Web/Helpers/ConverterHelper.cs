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
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType
                               
            };

        }

        public ReportResponse ToReportResponse(ReportEntity reportEntity)
        {
            if (reportEntity == null)
            {
                return null;
            }

            return new ReportResponse
            {
                TargetLongitude = reportEntity.TargetLongitude,
                Document = reportEntity.Document,
                TargetLatitude = reportEntity.TargetLatitude,
                FirstName = reportEntity.FirstName,
                Id = reportEntity.Id,
                LastName = reportEntity.LastName,
                SourceLongitude = reportEntity.SourceLongitude,
                SourceLatitude = reportEntity.SourceLatitude,
                ReportDetails = reportEntity.ReportDetails?.Select(rd => new ReportDetailsResponse
                {
                    Id = rd.Id,
                    Date = rd.Date,
                    Observation = rd.Observation,
                    Status = rd.Status.Name

                }).ToList(),
                User = ToUserResponse(reportEntity.User)

            };
        }

        public List<ReportResponse> ToReportResponse(List<ReportEntity> reportEntity)
        {
            throw new NotImplementedException();
        }

 
    }
}

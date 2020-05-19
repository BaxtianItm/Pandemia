using Pandemic.Common.Models;
using Pandemic.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandemic.Web.Helpers
{
    public interface IConverterHelper
    {
        UserResponse ToUserResponse(UserEntity user);

        List<ReportResponse> ToReportResponse(List<ReportEntity> reportEntity);

        ReportResponse ToReportResponse(ReportEntity reportEntity);
 
    }
}

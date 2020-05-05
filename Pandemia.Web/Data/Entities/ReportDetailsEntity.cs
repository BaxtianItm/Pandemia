using System;
using System.ComponentModel.DataAnnotations;

namespace Pandemic.Web.Data.Entities
{
    public class ReportDetailsEntity
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime DateLocal => Date.ToLocalTime();

        public string Observation { get; set; }

        public StatusReport Status { get; set; }

        public UserEntity User { get; set; }

        public ReportEntity Report { get; set; }

    }
}

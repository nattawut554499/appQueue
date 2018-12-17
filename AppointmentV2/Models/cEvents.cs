using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppointmentV2.Models
{
    public class cEvents
    {
        [Key]
        public int EventID { set; get; }
        public string Subject { set; get; }
        public string Description { set; get; }
        public DateTime Start { set; get; }
        public Nullable<DateTime> End { set; get; }
        public string ThemeColor { set; get; }
        public bool IsFullDay { set; get; }
    }
}
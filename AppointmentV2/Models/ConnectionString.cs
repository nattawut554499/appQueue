using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppointmentV2.Models
{
    public class ConnectionString:DbContext
    {
        public ConnectionString() : base("ConnectionString") { }
        public DbSet<cEvents> tbEvents { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using GNA.Models;

namespace Gna.Data
{
    public class Context : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<TransportCompany> TransportCompanies { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
    }

}
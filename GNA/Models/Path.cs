using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GNA.Models
{
    public class Path
    {
        public Path()
        {
            this.Subscriptions = new HashSet<Subscription>();
        }
        public int Id { get; set; }
        [Required]
        public string FromCity { get; set; }
        [Required]
        public string ToCity { get; set; }
        [Required]
        public DateTime DepartureTime{ get; set; }
        [Required]
        public DateTime ArivalTime { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }

        public int CompanyId { get; set; }
        public TransportCompany Company { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }

    }
}
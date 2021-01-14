using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GNA.Models
{
    public class Client
    {
        public Client()
        {
            this.Subscriptions = new HashSet<Subscription>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsSubscribed { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public override string ToString()
        {
            return Name;
        }


    }
}
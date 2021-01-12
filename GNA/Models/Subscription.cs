using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GNA.Models
{

    public class Subscription
    {

        public int Id { get; set; }
        [Required]
        public int Type { get; set; }//Type 0:monthly, Type 1:quarterly, Type 2:annual,
        [Required]
        public double Price { get; set; }

        public int CompanyId { get; set; }
        public TransportCompany Company { get; set; }


    }
}
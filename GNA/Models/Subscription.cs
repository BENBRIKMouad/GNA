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
        public int Type { get; set; }//Type 0:monthly, Type 1:quarterly, Type 2:annual
        public int Price { get; set; }
        public DateTime EndTime { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int PathId { get; set; }
        public Path Path { get; set; }
    }
}
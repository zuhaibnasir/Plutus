using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plutus.Models
{
    public class Website
    {

        public int ID { get; set; }        
        public string Name { get; set; }

        [DataType(DataType.Url)]
        public string URL { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }   
        public int? CardID { get; set; } 
        public WebsiteTypes Type { get; set; }
    }
}

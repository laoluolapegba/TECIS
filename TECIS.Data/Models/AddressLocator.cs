using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TECIS.Data.Models
{
    [Table("addresslocator")]
    public class AddressLocator
    {

        [Key]
        public int id { get; set; }
        public int itemid { get; set; }
        public string itemname { get; set; }
        public int itemtype { get; set;}
        public string address { get; set; }        
        public string city { get; set; }        
        public string region { get; set; }
        public string countrycode { get; set; }
        public string postalcode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        public string InfoWindowContent { get; set; }
    }
}


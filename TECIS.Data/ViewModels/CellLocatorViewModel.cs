using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace TECIS.Data.ViewModels
{
    using System;
    
    
    public class CellSearchResultViewModel
    {
        public string CellName { get; set; }
        //[Url]
        public string Address { get; set; }
        public string Distance { get; set; }
        
        
    }
    public class CellLocationsViewModel
    {
        public string CellName { get; set; }
        public string Address { get; set; }
        public string Distance { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


    }
    
    public  class CellLocatorViewModel 
    {
        public IEnumerable<CellLocationsViewModel> CellSearchResultViewModel { get; set; }
        public IEnumerable<CellLocationsViewModel> CellLocationsViewModel { get; set; }
    }
}

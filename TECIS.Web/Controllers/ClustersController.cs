using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using TECIS.Data.Models;
using TECIS.Web.Helpers.CrossCutting.Geo;
using System.Configuration;
using System.Data.Entity.SqlServer;
using TECIS.Data.ViewModels;
namespace TECIS.Web.Controllers
{
    public class ClustersController : Controller
    {
        private TecIsEntities db = new TecIsEntities();
        private string API_KEY = ConfigurationManager.AppSettings["GoogleMapsAPIKey"];
        // GET: /Clusters/
        public ActionResult Index()
        {
            var clusters = db.Clusters.Include(c => c.clustareas)
                .Include(d => d.clustertypes)
                .Include(e => e.clusterzones)
                .Include(f => f.clustersections)
                .OrderBy(o => o.ClusterZone)
                .ThenBy(a=>a.ClusterArea)
                .ThenBy(s=>s.ClusterSection);
            return View(clusters.ToList());
        }

        // GET: /Clusters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cluster cluster = db.Clusters.Find(id);
            if (cluster == null)
            {
                return HttpNotFound();
            }
            return View(cluster);
        }

        // GET: /Clusters/Create
        public ActionResult Create()
        {
            //ViewBag.ClusterArea = new SelectList(db.ClusterAreas, "Id", "Description");
            ViewBag.ClusterArea = new SelectList(db.CAreas, "Id", "Description");
            ViewBag.ClusterType = new SelectList(db.ClusterTypes, "Id", "Description");
            ViewBag.ClusterZone = new SelectList(db.CZones, "Id", "Description");
            ViewBag.ClusterSection = new SelectList(db.CSections, "Id", "Description");
            return View();
        }

        // POST: /Clusters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClusterName,ClusterDesc,ClusterArea,ClusterType,ClusterZone,ClusterSection,clusterhead,ClusterEmail")] Cluster cluster)
        {
            if (ModelState.IsValid)
            {
                db.Clusters.Add(cluster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClusterArea = new SelectList(db.CAreas, "Id", "Description", cluster.ClusterArea);
            ViewBag.ClusterType = new SelectList(db.ClusterTypes, "Id", "Description", cluster.ClusterType);
            ViewBag.ClusterZone = new SelectList(db.CZones, "Id", "Description", cluster.ClusterZone);
            ViewBag.ClusterSection = new SelectList(db.CSections, "Id", "Description", cluster.ClusterSection);
            return View(cluster);
        }

        // GET: /Clusters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cluster cluster = db.Clusters.Find(id);
            if (cluster == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClusterArea = new SelectList(db.CAreas, "Id", "Description", cluster.ClusterArea);
            ViewBag.ClusterType = new SelectList(db.ClusterTypes, "Id", "Description", cluster.ClusterType);
            ViewBag.ClusterZone = new SelectList(db.CZones, "Id", "Description", cluster.ClusterZone);
            ViewBag.ClusterSection = new SelectList(db.CSections, "Id", "Description", cluster.ClusterSection);
            return View(cluster);
        }

        // POST: /Clusters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClusterName,ClusterDesc,ClusterArea, ClusterType,ClusterZone,ClusterSection,clusterhead, ClusterEmail")] Cluster cluster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cluster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClusterArea = new SelectList(db.CAreas, "Id", "Description", cluster.ClusterArea);
            ViewBag.ClusterType = new SelectList(db.ClusterTypes, "Id", "Description", cluster.ClusterType);
            ViewBag.ClusterZone = new SelectList(db.CZones, "Id", "Description", cluster.ClusterZone);
            ViewBag.ClusterSection = new SelectList(db.CSections, "Id", "Description", cluster.ClusterSection);
            return View(cluster);
        }

        // GET: /Clusters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cluster cluster = db.Clusters.Find(id);
            if (cluster == null)
            {
                return HttpNotFound();
            }
            return View(cluster);
        }

        // POST: /Clusters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cluster cluster = db.Clusters.Find(id);
            db.Clusters.Remove(cluster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult GetClusterTypes()
        {
            var db = new TecIsEntities();

            return Json(db.ClusterTypes.Select(c => new { Id = c.Id, Description = c.Description }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetClusters()
        {
            var db = new TecIsEntities();
            var clusters = from Clusters in db.Clusters.Where(c => c.ClusterType == 1)                              
                          select new
                          {
                              ClusterId = Clusters.Id, 
                              ClusterName = Clusters.ClusterName //+ " - " + Clusters.clusterzones.Description
                          };

            //var clusters =
            //    db.Clusters.Select(c => new { ClusterId = c.Id, ClusterName = c.ClusterName })

            return Json( clusters.OrderBy(a => a.ClusterName), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCascadeZones()
        {
            var db = new TecIsEntities();

            return Json(db.CZones.Select(c => new { ZoneId = c.Id, ZoneName = c.Description }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeAreas(int? zones, string areaFilter)
        {
            var northwind = new TecIsEntities();
            var areas = northwind.CAreas.AsQueryable();

            if (zones != null)
            {
                areas = areas.Where(p => p.AreaZone == zones);
            }

            if (!string.IsNullOrEmpty(areaFilter))
            {
                areas = areas.Where(p => p.Description.Contains(areaFilter));
            }

            return Json(areas.Select(p => new { AreaId = p.Id, AreaName = p.Description }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCascadeSections(int? areas, string sectionFilter)
        {
            var northwind = new TecIsEntities();
            var sections = northwind.CSections.AsQueryable();

            if (areas != null)
            {
                sections = sections.Where(o => o.SectArea == areas);
            }

            if (!string.IsNullOrEmpty(sectionFilter))
            {
                sections = sections.Where(o => o.Description.Contains(sectionFilter));
            }

            return Json(sections.Select(o => new { SectionId = o.Id, SectionName = o.Description }), JsonRequestBehavior.AllowGet);
        }
        public ActionResult MemberLocator()
        {
            // GetMissingCoordinates();.Where(a => a.itemtype ==2 )
            IEnumerable<AddressLocator> data = db.AddressLocators.ToList();
            
            return View(data);
            //return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CellLocator(string searchAddress, string selectedAddress)
        {
            
            if (string.IsNullOrEmpty(searchAddress) && string.IsNullOrEmpty(selectedAddress))
            { 
                return View(); 
            }
            var matches = new List<CellSearchResultViewModel>();
            //var cells = new List<CellLocationsViewModel>();
            IEnumerable<CellLocationsViewModel> cells = new List<CellLocationsViewModel>();
            decimal _Max_distance = Convert.ToDecimal(0.25); //2KM  0.0207124245549936
            //0.25 = 15 miles

            //0.0166666666666667 = 1 mile
            //0.0166666666666667 = 1.60934 km
            //0.0103562122774968 = 1km
            //0.0207124245549936 = 2km
            #region Search
            if (string.Empty != searchAddress)
            {
                ViewBag.SearchMode = 2;
                //string selectedAddress = this.Request.QueryString["selectedaddress"];

                var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={0}&address={1}&sensor=false", this.API_KEY, Uri.EscapeDataString(searchAddress));

                var request = WebRequest.Create(requestUri);
                var response = request.GetResponse();
                var xdoc = XDocument.Load(response.GetResponseStream());

                var requestLUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={0}&address={1}&sensor=false", this.API_KEY, Uri.EscapeDataString(searchAddress));

                var results = XElement.Load(requestLUri); //used for getting the 
                var status = xdoc.Root.Element("status").Value;

                //IEnumerable<CellSearchResultViewModel> data = new List<CellSearchResultViewModel>();

                switch (status)
                {
                    case "ZERO_RESULTS":
                        // oops! no location found!
                        //Response.Write("That address does not exist");
                        break;
                    case "OK":
                        var result = xdoc.Element("GeocodeResponse").Element("result");
                        var resultCount = xdoc.Element("GeocodeResponse").Elements("result").Count();
                        //var locationElement = result.Element("geometry").Element("location");
                        //var lat = locationElement.Element("lat").Value;
                        //var lng = locationElement.Element("lng").Value;
                        if (resultCount == 0)
                        { }

                        else if (resultCount == 1)
                        {
                            var cellLocs = new List<CellLocationsViewModel>();
                            CellLocationsViewModel data = new CellLocationsViewModel();
                            data.Address = results.Element("result").Element("formatted_address").Value;
                            var locationElement = result.Element("geometry").Element("location");
                            LatLng latlng = new LatLng();
                            latlng.Latitude = Convert.ToDouble(locationElement.Element("lat").Value);
                            latlng.Longitude = Convert.ToDouble(locationElement.Element("lng").Value);

                            //data.Latitude = Convert.ToDouble(locationElement.Element("lat").Value);
                            //data.Longitude = Convert.ToDouble(locationElement.Element("lng").Value);

                            //next use the latlng to query the nearest cells
                            //SELECT StoreNumber, Address, City, Region, CountryCode, PostalCode, Latitude, Longitude, 
                            //SQRT(POWER(Latitude - @Latitude, 2) + POWER(Longitude - @Longitude, 2)) * 62.1371192 AS DistanceFromAddress 
                            //FROM Stores WHERE (ABS(Latitude - @Latitude) &lt; 0.25) AND (ABS(Longitude - @Longitude) &lt; 0.25) ORDER BY DistanceFromAddress

                            cellLocs.Add(data);
                            
                        }
                        else
                        {
                            //var resultList = new List<CellSearchResultViewModel>();                        
                            //Got back multiple results - We need to ask the user which address they mean to use...
                            matches = results.Elements("result")
                                          .Select(b => new CellSearchResultViewModel
                                          {
                                              Address = (string)b.Element("formatted_address").Value
                                          }).ToList();
                            ViewBag.SearchResult = cells;
                        }
                        break;
                    default:
                        // handle other status
                        break;

                }
            }
            #endregion
            #region ShowCells
            //ViewBag.Courses = _repository.GetCourses();
            if ( selectedAddress != null)
            {
                ViewBag.SearchMode = 3;
                //string selectedAddress = this.Request.QueryString["selectedaddress"];

                var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={0}&address={1}&sensor=false", this.API_KEY, Uri.EscapeDataString(selectedAddress));

                var request = WebRequest.Create(requestUri);
                var response = request.GetResponse();
                var xdoc = XDocument.Load(response.GetResponseStream());

                var requestLUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={0}&address={1}&sensor=false", this.API_KEY, Uri.EscapeDataString(searchAddress));

                var results = XElement.Load(requestLUri); //used for getting the 
                var status = xdoc.Root.Element("status").Value;

                switch (status)
                {
                    case "ZERO_RESULTS":
                        // oops! no location found!
                        //Response.Write("That address does not exist");
                        break;
                    case "OK":
                        var result = xdoc.Element("GeocodeResponse").Element("result");
                        var resultCount = xdoc.Element("GeocodeResponse").Elements("result").Count();
                        //var locationElement = result.Element("geometry").Element("location");
                        //var lat = locationElement.Element("lat").Value;
                        //var lng = locationElement.Element("lng").Value;
                        if (resultCount == 0)
                        { }

                        else if (resultCount == 1)
                        {
                            //var cellLocs = new List<CellLocationsViewModel>();
                            //CellLocationsViewModel data = new CellLocationsViewModel();
                            //data.Address = results.Element("result").Element("formatted_address").Value;
                            //cellLocs.Add(data);
                            var locationElement = result.Element("geometry").Element("location");
                            LatLng latlng = new LatLng();
                            latlng.Latitude = Convert.ToDouble(locationElement.Element("lat").Value);
                            latlng.Longitude = Convert.ToDouble(locationElement.Element("lng").Value);

                            //data.Latitude = Convert.ToDouble(locationElement.Element("lat").Value);
                            //data.Longitude = Convert.ToDouble(locationElement.Element("lng").Value);

                            //next use the latlng to query the nearest cells
                            //SELECT StoreNumber, Address, City, Region, CountryCode, PostalCode, Latitude, Longitude, 
                            //SQRT(POWER(Latitude - @Latitude, 2) + POWER(Longitude - @Longitude, 2)) * 62.1371192 AS DistanceFromAddress 
                            //FROM Stores WHERE (ABS(Latitude - @Latitude) &lt; 0.25) AND (ABS(Longitude - @Longitude) &lt; 0.25) ORDER BY DistanceFromAddress
                            //Math.Abs((Convert.ToDecimal(a.latitude) - Convert.ToDecimal(latlng.Latitude)) < Convert.ToDecimal(0.25))

                            //1 latitude = 69.047 statute miles = 60 nautical miles = 111.12 kilometers  
                            //99.6368706372
                            var entities = new TecIsEntities();
                            cells = (from a in entities.AddressLocators
                                         where a.itemtype == 2
                                         && (Math.Abs(Convert.ToDecimal(a.latitude) - Convert.ToDecimal(latlng.Latitude)) < _Max_distance)
                                         && (Math.Abs(Convert.ToDecimal(a.longitude) - Convert.ToDecimal(latlng.Longitude)) < _Max_distance)
                                         select new CellLocationsViewModel
                                         {
                                             Address = a.address,
                                             Latitude = a.latitude,
                                             Longitude = a.longitude,
                                             CellName = a.itemname,
                                             Distance = (Math.Sqrt(Math.Pow(a.latitude - latlng.Latitude, 2) + Math.Pow(a.longitude - latlng.Longitude, 2)) * 62.1371192 ).ToString()
                                         }).ToList();
                            ViewBag.SearchResult = cells;
                            
                        }
                       
                        break;
                    default:
                        // handle other status
                        break;

                }
            }
            #endregion
            return View(matches);
        }
        public ActionResult CellLocator()
        {
            var data = new List<CellSearchResultViewModel>();
            IEnumerable<CellLocationsViewModel> cellLocs = new List<CellLocationsViewModel>();
            //var cellLocs = new List<CellLocationsViewModel>();
            ViewBag.SearchResult = cellLocs;
            ViewBag.SearchMode = 1;
            List<CellLocationsViewModel> cells = new List<CellLocationsViewModel>();
            double _Max_distance = Convert.ToDouble(0.25); //2KM  0.0207124245549936
            string selectedAddress = Request["selectedAddress"];
            #region ShowCells
            //ViewBag.Courses = _repository.GetCourses();
            if (selectedAddress != null)
            {
                ViewBag.SearchMode = 3;
                //string selectedAddress = this.Request.QueryString["selectedaddress"];

                var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={0}&address={1}&sensor=false", this.API_KEY, Uri.EscapeDataString(selectedAddress));

                var request = WebRequest.Create(requestUri);
                var response = request.GetResponse();
                var xdoc = XDocument.Load(response.GetResponseStream());

                //var requestLUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={0}&address={1}&sensor=false", this.API_KEY, Uri.EscapeDataString(searchAddress));

                //var results = XElement.Load(requestLUri); //used for getting the 
                var status = xdoc.Root.Element("status").Value;

                switch (status)
                {
                    case "ZERO_RESULTS":
                        // oops! no location found!
                        //Response.Write("That address does not exist");
                        break;
                    case "OK":
                        var result = xdoc.Element("GeocodeResponse").Element("result");
                        var resultCount = xdoc.Element("GeocodeResponse").Elements("result").Count();
                        //var locationElement = result.Element("geometry").Element("location");
                        //var lat = locationElement.Element("lat").Value;
                        //var lng = locationElement.Element("lng").Value;
                        if (resultCount == 0)
                        { }

                        else if (resultCount == 1)
                        {
                            //var cellLocs = new List<CellLocationsViewModel>();
                            //CellLocationsViewModel data = new CellLocationsViewModel();
                            //data.Address = results.Element("result").Element("formatted_address").Value;
                            //cellLocs.Add(data);
                            var locationElement = result.Element("geometry").Element("location");
                            LatLng latlng = new LatLng();
                            latlng.Latitude = Convert.ToDouble(locationElement.Element("lat").Value);
                            latlng.Longitude = Convert.ToDouble(locationElement.Element("lng").Value);

                            //data.Latitude = Convert.ToDouble(locationElement.Element("lat").Value);
                            //data.Longitude = Convert.ToDouble(locationElement.Element("lng").Value);

                            //next use the latlng to query the nearest cells
                            //SELECT StoreNumber, Address, City, Region, CountryCode, PostalCode, Latitude, Longitude, 
                            //SQRT(POWER(Latitude - @Latitude, 2) + POWER(Longitude - @Longitude, 2)) * 62.1371192 AS DistanceFromAddress 
                            //FROM Stores WHERE (ABS(Latitude - @Latitude) &lt; 0.25) AND (ABS(Longitude - @Longitude) &lt; 0.25) ORDER BY DistanceFromAddress
                            //Math.Abs((Convert.ToDecimal(a.latitude) - Convert.ToDecimal(latlng.Latitude)) < Convert.ToDecimal(0.25))

                            //1 latitude = 69.047 statute miles = 60 nautical miles = 111.12 kilometers  
                            //99.6368706372
                            var entities = new TecIsEntities();
                            double tmpLat = Convert.ToDouble(latlng.Latitude);
                            double tmpLng = Convert.ToDouble(latlng.Longitude);
                            GeocodeCalculator calc = new GeocodeCalculator();
                            GeocodedPosition pos = new GeocodedPosition(tmpLat, tmpLng);

                            //&& (Math.Abs(a.latitude - tmpLat) < _Max_distance)
                            //         && (Math.Abs(a.longitude - tmpLng) < _Max_distance)
                            //select new CellLocationsViewModel
                            //         {
                            //             Address = a.address,
                            //             Latitude = a.latitude,
                            //             Longitude = a.longitude,
                            //             CellName = a.itemname,
                            //             Distance = calc.Distance(loc, GeocodeCalculator.DistanceType.Miles)
                            //         }

                            var dbclusters = entities.AddressLocators.Where(a => a.itemtype == 2 && a.longitude < 0).ToList();
                            foreach (var item in dbclusters)
                            {
                                GeocodedPosition clusterpos = new GeocodedPosition(item.latitude, item.longitude);
                                double dist = calc.Distance(pos, clusterpos, GeocodeCalculator.DistanceType.Miles);
                                if (Math.Abs(dist) < _Max_distance)
                                {
                                    CellLocationsViewModel _found = new CellLocationsViewModel();
                                    _found.Address = item.address;
                                    _found.Latitude = item.latitude;
                                    _found.Longitude = item.longitude;
                                    _found.CellName = item.itemname;
                                    _found.Distance = dist.ToString();
                                    cells.Add(_found);
                                }
                            }
                            ViewBag.SearchResult = cells;
                            // Distance = (SqlFunctions.SquareRoot(Math.Pow(a.latitude - latlng.Latitude, 2) + Math.Pow(a.longitude - latlng.Longitude, 2)) * 62.1371192).ToString()
                        }

                        break;
                    default:
                        // handle other status
                        break;

                }
            }
            #endregion
            return View(data);
        }
        private void GetMissingCoordinates()
        {
            try
            {
                //for every member in the db, get their address and
                var members = db.Clusters.ToList();

                //var newitems = members.Where(l => !db.AddressLocators.Select(t => t.itemid).Contains(l.Id));

                foreach (var item in members)
                {
                    try
                    {
                        AddressLocator addloc = new AddressLocator();
                        addloc.itemid = item.Id+3000;
                        addloc.itemname = item.ClusterName;
                        addloc.address = item.ClusterAddress;
                        addloc.countrycode = "NG";
                        addloc.itemtype = 2;
                        addloc.postalcode = "23401";
                        addloc.city = "Lagos";
                        addloc.InfoWindowContent = item.ClusterName;

                        /*
                        AddressLocator addloc = new AddressLocator();
                        addloc.itemid = item.Id;
                        addloc.itemname = item.surname + " " + item.firstname;
                        addloc.address = item.address;
                        addloc.countrycode = "NG";
                        addloc.itemtype = 2;
                        addloc.postalcode = "23401";
                        addloc.city = "Lagos";
                        addloc.InfoWindowContent = item.;
                        */

                        var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={0}&address={1}&sensor=false", this.API_KEY, Uri.EscapeDataString(item.ClusterAddress));

                        var request = WebRequest.Create(requestUri);
                        var response = request.GetResponse();
                        var xdoc = XDocument.Load(response.GetResponseStream());
                        var status = xdoc.Root.Element("status").Value;

                        switch (status)
                        {
                            case "ZERO_RESULTS":
                                // oops! no location found!
                                //Response.Write("That address does not exist");
                                break;
                            case "OK":
                                    var result = xdoc.Element("GeocodeResponse").Element("result");
                                    var locationElement = result.Element("geometry").Element("location");
                                    var lat = locationElement.Element("lat").Value;
                                    var lng = locationElement.Element("lng").Value;
                                    addloc.latitude = Convert.ToDouble(lat);
                                    addloc.longitude = Convert.ToDouble(lng);
                                break;
                            default:
                                // handle other status
                                break;
                        }
                        //var resultCount = xdoc.Element("GeocodeResponse").Elements("result").Count();
                        //if (resultCount == 0)
                        //    //Eep, no results!
                        //    continue;

                        //else if (resultCount == 1)
                        //{
                        
                        //}

                        db.AddressLocators.Add(addloc);
                        db.SaveChanges();
                        
                        /*
                        TECIS.Web.Helpers.CrossCutting.Geo.GoogleMaps maps = new Helpers.CrossCutting.Geo.GoogleMaps(API_KEY);
                        maps.SetApiKey(API_KEY);
                        LatLng coord = maps.GetLatLng(item.address);
                        addloc.latitude = coord.Latitude;
                        addloc.longitude = coord.Longitude;
                         */
                        /*
                         * var results = GoogleMapsAPIHelpersCS.GetGeocodingSearchResults(item.address);

                        var resultCount = results.Elements("result").Count();
                        if (resultCount == 0)
                            //Eep, no results!
                            continue;

                        else if (resultCount == 1)
                        {
                            //Got back just one result, 
                            addloc.latitude = double.Parse(results.Element("result").Element("geometry").Element("location").Element("lat").Value);
                            addloc.latitude = double.Parse(results.Element("result").Element("geometry").Element("location").Element("lng").Value);
                        }
                        else
                        {

                        }
                        */
                       
                    }
                        
                    catch (Exception dbex)
                    { 

                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("An Error Occured" + ex.Message);
            }
            //throw new NotImplementedException();
        }
        public static int GetClustIdByLeaderEmail(string email)
        {
            var db = new TecIsEntities();
            return
            (
             from p in db.Clusters
             where p.ClusterEmail == email
             select p.Id
            ).SingleOrDefault();
        }
        public static int GetSectIdbyLeaderEmail(string email)
        {
            var db = new TecIsEntities();
            return
            (
             from p in db.CSections
             where p.SectionLeader == email
             select p.Id
            ).SingleOrDefault();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        internal static int GetAreaIdbyLeaderEmail(string email)
        {
            var db = new TecIsEntities();
            return
            (
             from p in db.CAreas
             where p.AreaCoordinator == email
             select p.Id
            ).SingleOrDefault();
        }

        internal static int GetZoneIdbyLeaderEmail(string email)
        {
            var db = new TecIsEntities();
            return
            (
             from p in db.CZones
             where p.ZonalCoordinator == email
             select p.Id
            ).SingleOrDefault();
        }
    }
}

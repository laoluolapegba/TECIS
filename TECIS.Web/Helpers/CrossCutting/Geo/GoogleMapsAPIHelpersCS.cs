using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoogleMaps.LocationServices;
namespace TECIS.Web.Helpers.CrossCutting.Geo
{
public class GoogleMapsAPIHelpersCS
{
    public static XElement GetGeocodingSearchResults(string address)
    {
        // Use the Google Geocoding service to get information about the user-entered address
        // See http://code.google.com/apis/maps/documentation/geocoding/index.html for more info...
        var url = String.Format("http://maps.google.com/maps/api/geocode/xml?address={0}&sensor=false", HttpContext.Current.Server.UrlEncode(address));

        // Load the XML into an XElement object (whee, LINQ to XML!)
        var results = XElement.Load(url);

        // Check the status
        var status = results.Element("status").Value;
        if (status != "OK" && status != "ZERO_RESULTS")
            // Whoops, something else was wrong with the request...
            throw new ApplicationException("There was an error with Google's Geocoding Service: " + status);

        return results;
    }
    public LatLng GetLatLongFromAddress(string address)
    {
        
        var locationService = new GoogleLocationService();
        var point = locationService.GetLatLongFromAddress(address);
        LatLng coordinates = new LatLng();
        coordinates.Latitude = point.Latitude;
        coordinates.Longitude = point.Longitude;
        //var latitude = point.Latitude;
        //var longitude = point.Longitude;
        return coordinates;

    }

}
}
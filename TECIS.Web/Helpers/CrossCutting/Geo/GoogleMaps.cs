using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Configuration;
namespace TECIS.Web.Helpers.CrossCutting.Geo
{
    public class GoogleMaps
    {
        private string API_KEY = ConfigurationManager.AppSettings["GoogleMapsAPIKey"];
        
        public GoogleMaps(string api_key)
        {
            this.API_KEY = api_key;
        }

        public void SetApiKey(string key)
        {

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("API Key is invalid");
            }

            this.API_KEY = key;
        }

        /// <summary>
        /// Perform a geocode lookup of an address
        /// </summary>
        /// <param name="addr">The address in CSV form line1, line2, postcode</param>
        /// <param name="output">CSV or XML</param>
        /// <returns>LatLng object</returns>
        public LatLng GetLatLng(string addr)
        { //Uri.EscapeDataString
            var url = string.Format("http://maps.google.com/maps/geo?&key={0}&output=csv&q={1}",this.API_KEY , HttpContext.Current.Server.UrlEncode(addr));

            var request = WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {

                var ms = new MemoryStream();
                var responseStream = response.GetResponseStream();

                var buffer = new Byte[2048];
                int count = responseStream.Read(buffer, 0, buffer.Length);

                while (count > 0)
                {
                    ms.Write(buffer, 0, count);
                    count = responseStream.Read(buffer, 0, buffer.Length);
                }

                responseStream.Close();
                ms.Close();

                var responseBytes = ms.ToArray();
                var encoding = new System.Text.ASCIIEncoding();

                var coords = encoding.GetString(responseBytes);
                var parts = coords.Split(',');

                return new LatLng(
                              Convert.ToDouble(parts[2]),
                              Convert.ToDouble(parts[3]));
            }

            return null;
        }
    }

}

 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfriGisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "<YOUR KEY>";
            string secret = "<YOUR SECRET>";

            var factory = new AfriGIS.Services.ServiceCallFactory(key, secret);

           // var req = new AfriGIS.Services.ReverseGeocode.Request.ReverseGeocodeRequest(new AfriGIS.Services.Coordinate(23.6, 23.6));

            //var result = factory.GetAsync<AfriGIS.Services.ReverseGeocode.Response.ReverseGeocodeResponse>(req).Result;

            var rgQueryStringParams = new List<KeyValuePair<string, string>> {
            new KeyValuePair<string, string>("attributes","AVGSPEED"),
            new KeyValuePair<string, string>("attributes","ROUTESPEED")
            };
            //var request = new AfriGIS.Services.ReverseGeocode.Request.ReverseGeocodeRequest(-25.8651033, 28.2569066);
            var request = new AfriGIS.Services.ReverseGeocode.Request.ReverseGeocodeRequest(-25.8651033, 28.2569066);
            request.Layer = "AG_STREETS";
            request.ExtraParameters = rgQueryStringParams;

            var result = factory.GetAsync<AfriGIS.Services.ReverseGeocode.Response.ReverseGeocodeResponse>(request).Result;
            
            foreach (var address in result.Results)
            {
                Console.WriteLine(address.ToString());
            }

            request = new AfriGIS.Services.ReverseGeocode.Request.ReverseGeocodeRequest(-17.8312583, 31.0475716);
            request.Layer = "AG_STREETS";
            request.ExtraParameters = rgQueryStringParams;

            result = factory.GetAsync<AfriGIS.Services.ReverseGeocode.Response.ReverseGeocodeResponse>(request).Result;

            foreach (var address in result.Results)
            {
                Console.WriteLine(address.ToString());
            }
            
        }
    }
}

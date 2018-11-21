using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MaxMind.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace GeoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        private IHttpContextAccessor _accessor;

        public CheckController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        // GET api/Check
        [HttpGet]
        public ActionResult<GeoData> Check()
        {
            string path = "Database/GeoLite2-Country.mmdb";
            using (var reader = new Reader(path))
            {
                Console.WriteLine(Request.Headers["HTTP_X_FORWARDED_FOR"]);
                Console.WriteLine(_accessor.HttpContext.Connection.RemoteIpAddress.ToString());
                Console.WriteLine(HttpContext.Connection.RemoteIpAddress.ToString());
                var data = reader.Find<GeoData>(_accessor.HttpContext.Connection.RemoteIpAddress);
                return Ok(data??new GeoData());
            }
        }
    }



    public class GeoData
    {
        public GeoData()
        {
                
        }
        [MaxMind.Db.Constructor]
        public GeoData(Continent continent, Country country, Registered_Country registered_country)
        {
            this.continent = continent;
            this.country = country;
            this.registered_country = registered_country;
        }

        public Continent continent { get; set; }
        public Country country { get; set; }
        public Registered_Country registered_country { get; set; }
    }

    public class Continent
    {
        [MaxMind.Db.Constructor]
        public Continent(string code, Int64 geoname_id)
        {
            this.code = code;
            this.geoname_id = geoname_id;
        }

        public string code { get; set; }
        public Int64 geoname_id { get; set; }
    }

    
    public class Country
    {
        [MaxMind.Db.Constructor]
        public Country(Int64 geoname_id, string iso_code)
        {
            this.geoname_id = geoname_id;
            this.iso_code = iso_code;
        }

        public Int64 geoname_id { get; set; }
        public string iso_code { get; set; }
    }

    public class Registered_Country
    {
        [MaxMind.Db.Constructor]
        public Registered_Country(Int64 geoname_id, string iso_code)
        {
            this.geoname_id = geoname_id;
            this.iso_code = iso_code;
        }

        public Int64 geoname_id { get; set; }
        public string iso_code { get; set; }
    }

    

}

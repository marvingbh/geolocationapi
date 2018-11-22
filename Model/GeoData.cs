using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace geoapi.Model
{
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

}

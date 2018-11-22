using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace geoapi.Model
{
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
}

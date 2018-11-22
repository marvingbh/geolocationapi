using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace geoapi.Model
{
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

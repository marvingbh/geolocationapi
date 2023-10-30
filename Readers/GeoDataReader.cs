using System;
using System.Net;
using System.Threading.Tasks;
using geoapi.Model;
using GeoApi.Controllers;
using MaxMind.Db;
using Microsoft.AspNetCore.Http;

namespace geoapi.Readers
{
    public class GeoDataReader : IDisposable, IGeoDataReader
    {

        private string path = "Database/GeoLite2-Country.mmdb";
        private readonly Reader reader = null;

        public GeoDataReader()
        {
            reader = new Reader(path);
        }

        public async Task<GeoData> Check(HttpContext context)
        {
            var data = reader.Find<GeoData>(IPAddress.Parse(context.Request.Headers["X-Forwarded-For"][0].Split(':')[0]));
            return data ?? new GeoData();
        }

        public async Task<GeoData> Check(string ipAddress)
        {
            var data = reader.Find<GeoData>(ipAddress);
            return data ?? new GeoData();
        }

        public void Dispose()
        {
            reader?.Dispose();
        }
    }

}

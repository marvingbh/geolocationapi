using System.Threading.Tasks;
using geoapi.Model;
using GeoApi.Controllers;
using Microsoft.AspNetCore.Http;

namespace geoapi.Readers
{
    public interface IGeoDataReader
    {
        Task<GeoData> Check(HttpContext context);
    }
}
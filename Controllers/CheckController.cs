﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using geoapi.Model;
using geoapi.Readers;
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
        private readonly IGeoDataReader _geoDataReader;

        public CheckController(IGeoDataReader geoDataReader)
        {
            _geoDataReader = geoDataReader;
        }

        // GET api/Check
        [HttpGet]
        public async Task<ActionResult<GeoData>> Check()
        {
            var data = await _geoDataReader.Check(HttpContext);
            return Ok(data ?? new GeoData());
        }

    }

   


    
    

}

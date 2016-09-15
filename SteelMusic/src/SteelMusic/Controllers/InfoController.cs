using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SteelMusic.Models;

namespace SteelMusic.Controllers
{
    public class InfoController : Controller
    {
        private readonly ILogger Logger;

        public InfoController(ILoggerFactory loggerFactory)
        {
            this.Logger = loggerFactory.CreateLogger<InfoController>();
        }

        [Route("/appinfo")]
        [HttpGet]
        public ApplicationInfo Info()
        {
            return new ApplicationInfo(new string[] { "in-memory" }, null);
        }

        [Route("/service")]
        [HttpGet]
        public List<ServiceInfo> ShowServiceInfo()
        {
            throw new NotImplementedException();
        }
    }
}

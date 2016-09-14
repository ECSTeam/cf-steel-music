using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SteelMusic.Controllers
{
    [Route("/errors")]
    public class ErrorController : Controller
    {
        private readonly ILogger Logger;

        public ErrorController(ILoggerFactory loggerFactory)
        {
            this.Logger = loggerFactory.CreateLogger<ErrorController>();
            this.Logger.LogDebug("Initializing the error controller");
        }

        [HttpGet("kill")]
        public void Killer()
        {
            this.Logger.LogInformation("Forcing application exit");
            Environment.Exit(0);
        }

        [HttpGet("throw")]
        public void Thrower()
        {
            this.Logger.LogInformation("Forcing an exception to be thrown");
            throw new NullReferenceException("Forcing an exception to be thrown");
        }
    }
}

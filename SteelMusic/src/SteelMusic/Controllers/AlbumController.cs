using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SteelMusic.Models;
using SteelMusic.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SteelMusic.Controllers
{
    [Route("/albums")]
    public class AlbumController : Controller
    {
        private readonly ILogger Logger;
        private IAlbumService service;

        public AlbumController(ILoggerFactory loggerFactory, IAlbumService service)
        {
            this.Logger = loggerFactory.CreateLogger<AlbumController>();
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Album> Albums()
        {
            return this.service;
        }

        [HttpPut]
        public Album Add([FromBody] Album album)
        {
            return this.service.Add(album);
        }

        [HttpPost]
        public Album Update([FromBody] Album album)
        {
            return this.service.Update(album);
        }

        [HttpGet("{id}")]
        public Album GetById(string id)
        {
            return this.service[id];
        }

        [HttpDelete("{id}")]
        public void DeleteById(string id)
        {
            this.service.Remove(id);
        }
    }
}

using SteelMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelMusic.Services
{
    public interface IAlbumService : IEnumerable<Album>
    {
        Album Add(Album album);
        Album Update(Album album);
        void Remove(string id);

        Album this[string id] {
            get;
        }
    }
}

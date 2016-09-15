using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteelMusic.Models;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace SteelMusic.Services
{
    public class AlbumService : IAlbumService
    {
        private Dictionary<string, Album> albums = new Dictionary<string, Album>();

        public Album this[string id]
        {
            get
            {
                return this.albums[id];
            }
        }

        public Album Add(Album album)
        {
            if(album.Id == null)
            {
                album.Id = Guid.NewGuid().ToString();
            }

            this.albums.Add(album.Id, album);
            return album;
        }

        public void Remove(string id)
        {
            this.albums.Remove(id);
        }

        public Album Update(Album album)
        {
            if(album.Id == null || !this.albums.ContainsKey(album.Id))
            {
                return Add(album);
            }

            this.albums[album.Id] = album;
            return album;
        }

        public IEnumerator<Album> GetEnumerator()
        {
            return this.albums.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load(string location)
        {
            using(StreamReader reader = File.OpenText(location))
            {
                string contents = reader.ReadToEnd();
                foreach(Album album in JsonConvert.DeserializeObject(contents, typeof(List<Album>)) as List<Album>)
                {
                    this.Add(album);
                }
            }
        }
    }
}

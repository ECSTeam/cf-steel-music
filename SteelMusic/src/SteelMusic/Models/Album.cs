using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelMusic.Models
{
    public class Album
    {
        public Album()
        {
        }

        public Album(string title, string artist, string releaseYear, string genre)
        {
            this.Title = title;
            this.Artist = artist;
            this.ReleaseYear = releaseYear;
            this.Genre = genre;
        }

        public Album(string id, string title, string artist, string releaseYear, string genre)
        {
            this.Id = id;
            this.Title = title;
            this.Artist = artist;
            this.ReleaseYear = releaseYear;
            this.Genre = genre;
        }

        public string Id
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public string Artist
        {
            get; set;
        }

        public string ReleaseYear
        {
            get; set;
        }

        public string Genre
        {
            get; set;
        }

        public int TrackCount
        {
            get; set;
        }

        public string AlbumId
        {
            get; set;
        }
    }
}

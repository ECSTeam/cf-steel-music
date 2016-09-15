using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelMusic.Models
{
    public class ApplicationInfo
    {
        public ApplicationInfo(string[] profiles, string[] services)
        {
            this.Profiles = profiles;
            this.Services = services;
        }

        public string[] Profiles
        {
            get;
            set;
        }

        public string[] Services
        {
            get;
            set;
        }
    }
}

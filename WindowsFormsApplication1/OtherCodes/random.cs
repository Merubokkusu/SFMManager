using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceFilmMakerManager {

    public static class random {
        private static string[] logcreate = new[] { "S-senpai!, the folder was already created ;-;", "Onii-Chan, baka the folder is created", "Listen here maggot, the folder was already created!.", "The folder is already created, its not like I wanted it to be." };
        private static string[] VersionRun = new[] { "S-senpai!, your running the newest version (◕‿◕✿)", "Onii-Chan, your not a dumb as you look. newest version..", "Ha, looks like my teaching has gotten to you, newest version...", "Your running the newest version, its not like I'm happy for you." };
        public static string VR = VersionRun.RandomElement();
        public static string LG = logcreate.RandomElement();

        public static T RandomElement<T>(this IEnumerable<T> coll) {
            var rnd = new Random();
            return coll.ElementAt(rnd.Next(coll.Count()));
        }
    }
}
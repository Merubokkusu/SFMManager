using System;
using System.IO;

namespace SourceFilmMakerManager {

    public static class otherCodes {

        public static string GetRandomString() {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }

        public static bool IsBSP(string f) {
            return f != null &&
                f.EndsWith(".bsp", StringComparison.Ordinal);
        }

        public static bool IsRIG(string f) {
            return f != null &&
                f.EndsWith(".py", StringComparison.Ordinal);
        }
    }
}
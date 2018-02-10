using System;

namespace SourceFilmMakerManager.Manager {

    internal class AddToList {
        private string name;
        private string category;
        private DateTime date;
        private string source;
        private string author;
        private string url;

        public AddToList(string name, string category, DateTime date, string source, string author, string url) {
            this.name = name;
            this.category = category;
            this.date = date;
            this.source = source;
            this.author = author;
            this.url = url;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Category {
            get { return category; }
            set { category = value; }
        }

        public DateTime Date {
            get { return date; }
            set { date = value; }
        }

        public string Source {
            get { return source; }
            set { source = value; }
        }

        public string Author {
            get { return author; }
            set { author = value; }
        }

        public string URL {
            get { return url; }
            set { url = value; }
        }
    }
}
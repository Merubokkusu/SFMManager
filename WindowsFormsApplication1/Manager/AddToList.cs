using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceFilmMakerManager.Manager {
    class AddToList {
        string name;
        string category;
        string date;
        string source;
        string author;
        string url;
        public AddToList(string name, string category, string date, string source, string author, string url) {
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
        public string Date {
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

        /*static internal List<AddToList> GET() {
           
            
            AddToList item = new AddToList("zeko", "dunno", "9");
            AddToList xx = new AddToList("sheshe", "dunno", "9");
            AddToList ww = new AddToList("murhaf", "dunno", "9");
            AddToList qq = new AddToList("soz", "dunno", "9");
            AddToList ee = new AddToList("HELLO", "dunno", "9");
            List<AddToList> x = new List<AddToList>();
            x.Add(item);
            x.Add(xx);
            x.Add(ww);
            x.Add(qq);
            x.Add(ee);
            return x;
    }*/


    }
}

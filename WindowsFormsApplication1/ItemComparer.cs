using System;
using System.Collections;
using System.Windows.Forms;

namespace SourceFilmMakerManager {

    public class ItemComparer : IComparer {

        //column used for comparison
        public int Column { get; set; }

        //Order of sorting
        public SortOrder Order { get; set; }

        public ItemComparer(int colIndex) {
            Column = colIndex;
            Order = SortOrder.None;
        }

        public int Compare(object a, object b) {
            int result;
            ListViewItem itemA = a as ListViewItem;
            ListViewItem itemB = b as ListViewItem;
            if (itemA == null && itemB == null)
                result = 0;
            else if (itemA == null)
                result = -1;
            else if (itemB == null)
                result = 1;
            if (itemA == itemB)
                result = 0;
            // datetime comparison
            DateTime x1, y1;
            // Parse the two objects passed as a parameter as a DateTime.
            if (!DateTime.TryParse(itemA.SubItems[Column].Text, out x1))
                x1 = DateTime.MinValue;
            if (!DateTime.TryParse(itemB.SubItems[Column].Text, out y1))
                y1 = DateTime.MinValue;
            result = DateTime.Compare(x1, y1);
            if (x1 != DateTime.MinValue && y1 != DateTime.MinValue)
                goto done;
            //alphabetic comparison
            result = String.Compare(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);

            done:
            // if sort order is descending.
            if (Order == SortOrder.Descending)
                // Invert the value returned by Compare.
                result *= -1;
            return result;
        }
    }
}
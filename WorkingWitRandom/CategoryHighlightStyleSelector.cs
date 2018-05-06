using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WorkingWithRandom
{
    public class CategoryHighlightStyleSelector : StyleSelector
    {
        public Style SameLetters { get; set; }
        public Style DefaultColor { get; set; }
        public Style MaxNumber { get; set; }

        private int indexColor(string item)
        {
            item = item.Substring(item.IndexOf(':') + 1);
            int temp;
            if (!int.TryParse(item, out temp))
            {
                if (item.ToCharArray().Where((x) => x == item[0]).Count() > 1)
                    return 1;
                if (item.ToCharArray().Where((x) => x == item[1]).Count() > 1)
                    return 1;
            }
            else
            {
                if (temp == ApplicationViewModel.maxNumber)
                    return 2;
                else
                    return 0;
            }
            return 0;
        }
        public override Style SelectStyle(object item, DependencyObject container)
        {
            string elem = (string)item;
            switch (indexColor(elem))
            {
                case 1:
                    return SameLetters;
                case 2:
                    return MaxNumber;
                default:
                    return DefaultColor;
            }
        }
    }
}

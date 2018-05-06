using System.Windows.Media;
using WorkingWithRandom.TypeRandom;

namespace WorkingWithRandom
{
    public class Buttons : PropertyChange
    {
        public EnumType enumType;

        SolidColorBrush baseColor = (new BrushConverter()).ConvertFromString("#26A69A") as SolidColorBrush;
        SolidColorBrush chooseColor = (new BrushConverter()).ConvertFromString("#ef5350") as SolidColorBrush;
         
        private SolidColorBrush backgroundInt;
        public SolidColorBrush BackgroundInt
        {
            get
            {
                return backgroundInt;
            }
            set
            {
                backgroundInt = value;
                OnPropertyChanged("BackgroundInt");
            }
        }

        private SolidColorBrush backgroundString;
        public SolidColorBrush BackgroundString
        {
            get
            {
                return backgroundString;
            }
            set
            {
                backgroundString = value;
                OnPropertyChanged("BackgroundString");
            }
        }

        public Buttons()
        {
            BackgroundString = chooseColor;
            enumType = EnumType.String;
            BackgroundInt = baseColor;
        }
        private RelayCommand selectInt;
        public RelayCommand SelectInt => selectInt ??
                  (selectInt = new RelayCommand(obj =>
                  {
                      enumType = EnumType.Int;
                      BackgroundInt = chooseColor;
                      BackgroundString = baseColor;
                  }));

        private RelayCommand selectString;
        public RelayCommand SelectString => selectString ??
                  (selectString = new RelayCommand(obj =>
                  {
                      enumType = EnumType.String;
                      BackgroundString = chooseColor;
                      BackgroundInt = baseColor;
                  }));
    }
}

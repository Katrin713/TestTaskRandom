using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using WorkingWithRandom.TypeRandom;

namespace WorkingWithRandom
{
    public class ApplicationViewModel : PropertyChange
    {
        private Buttons typeButtons = new Buttons();
        public Buttons TypeButton
        {
            get
            {
                return typeButtons;
            }
            set
            {
                typeButtons = value;
                OnPropertyChanged(nameof(TypeButton));
            }
        }

        public static int maxNumber;
        private List<string> results;
        public List<string> Results
        {
            get
            {
                return results;
            }
            set
            {
                results = value;
                OnPropertyChanged(nameof(Results));
            }
        }

        private Visibility errorVisibility = Visibility.Visible;
        public Visibility ErrorVisibility
        {
            get
            {
                return errorVisibility;
            }
            set
            {
                errorVisibility = value;
                OnPropertyChanged(nameof(ErrorVisibility));
            }
        }

        private Visibility resultVisibility = Visibility.Collapsed;
        public Visibility ResultVisibility
        {
            get
            {
                return resultVisibility;
            }
            set
            {
                resultVisibility = value;
                OnPropertyChanged(nameof(ResultVisibility));
            }
        }

        private string errorText = "Список пуст!";
        public string ErrorText
        {
            get
            {
                return errorText;
            }
            set
            {
                errorText = value;
                OnPropertyChanged(nameof(ErrorText));
            }
        }

        private void makeMistake()
        {
            ErrorVisibility = Visibility.Visible;
            ResultVisibility = Visibility.Collapsed;
        }
        private void seeResult()
        {
            Results = new List<string>();
            ErrorVisibility = Visibility.Collapsed;
            ResultVisibility = Visibility.Visible;
        }

        private void getMax(List<string> needForResult)
        {
            maxNumber = needForResult.Max(el => int.Parse(el.Substring(el.IndexOf(':') + 1)));
        }
        private void getRes<T>(List<T> genObjects, string firstLetters)
        {
            List<string> needForResult = new List<string>();
            foreach (T el in genObjects)
                needForResult.Add(firstLetters + el.ToString());

            Results = needForResult;

            if (genObjects is List<int>)
                getMax(needForResult);
        }

        private void startGenerate<T>(IGenerator<T> generator, string firstLetters)
        {
            List<T> genObjects = generator.Generate();
            getRes(genObjects, firstLetters);

            ResultHistory<T>.addElement(genObjects);
        }
        private void prevGenerate<T>(List<T> genObjects, string firstLetters)
        {
            if (genObjects == null)
            {
                ErrorText = "Список пуст!";
                makeMistake();
                return;
            }
            if (genObjects.Count == 0)
            {
                ErrorText = "Не существует педыдущего элемента!";
                makeMistake();
                return;
            }

            getRes(genObjects, firstLetters);
        }

        private RelayCommand getRandom;
        public RelayCommand GetRandom => getRandom ??
                  (getRandom = new RelayCommand(obj =>
                  {
                      Thread myThread;
                      seeResult();
                      if (typeButtons.enumType == EnumType.String)
                          myThread = new Thread(() => startGenerate(new StringRandom(), "STR:"));
                      else
                          myThread = new Thread(() => startGenerate(new IntRandom(), "INT:"));
                      myThread.Start();
                  }));

        private RelayCommand getPrevious;
        public RelayCommand GetPrevious => getPrevious ??
                  (getPrevious = new RelayCommand(obj =>
                  {
                      Thread myThread;
                      seeResult();
                      if (typeButtons.enumType == EnumType.String)
                          myThread = new Thread(() => prevGenerate<string>(ResultHistory<string>.removeElem(typeof(List<string>)), "STR:"));
                      else
                          myThread = new Thread(() => prevGenerate<int>(ResultHistory<int>.removeElem(typeof(List<int>)), "INT:"));
                      myThread.Start();
                  }));
    }
}

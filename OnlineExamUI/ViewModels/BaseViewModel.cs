using System.ComponentModel;
using System.Windows;

namespace OnlineExamUI.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public abstract class BaseWindowViewModel : BaseViewModel
        {
            public Window Window;
        }

        public abstract class BaseControlViewModel : BaseViewModel
        {
            public abstract string Header { get; }

            private int currentSituation = 1;
            public int CurrentSituation
            {
                get => currentSituation;
                set
                {
                    currentSituation = value;
                    OnPropertyChanged(nameof(CurrentSituation));
                }
            }
        }
    }
}

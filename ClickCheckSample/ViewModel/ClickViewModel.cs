using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using ClickCheckSample.Models;

namespace ClickCheckSample.ViewModel
{
    class ClickViewMoel : ICommand, INotifyPropertyChanged
    {
        private ClockCounterClass model;

        public event EventHandler CanExecuteChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            model.ClickCount();
        }

        public int AreaCountProgress
        {
            get => model.AreaProgress;
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AreaCountProgress"));
        }

        public ClickViewMoel()
        {
            model = ClockCounterClass.Singleton;
            model.TimerElapsed += OnValueChanged;
        }

    }
}

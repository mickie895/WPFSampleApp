using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ClickCheckSample.Models;

namespace ClickCheckSample.ViewModels
{
    class CounterViewModel: INotifyPropertyChanged
    {
        private ClockCounterClass model;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ClickCounter
        {
            get => model.LastAreaCount;
        }

        public int AllClickCounter
        {
            get => model.AllCount;
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ClickCounter"));
        }

        public CounterViewModel()
        {
            model = ClockCounterClass.Singleton;
            model.CycleChanged += OnValueChanged;
            model.Clicked += OnClicked;
        }

        private void OnClicked(object sender, EventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllClickCounter"));
        }
    }
}

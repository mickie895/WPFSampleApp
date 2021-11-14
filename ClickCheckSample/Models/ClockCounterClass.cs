using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCheckSample.Models
{

    class ClockCounterClass
    {
        private static ClockCounterClass instance = null;

        public static ClockCounterClass Singleton
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClockCounterClass();
                }
                return instance;
            }
        }

        public int AllCount { get; set; }

        public int LastAreaCount { get; set; }

        public int AreaProgress { get; set; }

        private TaskClock clock;

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            AreaProgress = (AreaProgress + 1) % 100;
            OnTimerElapsed();
            if (AreaProgress == 0)
            {
                LastAreaCount = ProgressClickCount;
                ProgressClickCount = 0;
                OnCycleChanged();
            }
        }

        public void ClickCount()
        {
            if (!clock.Timer.Enabled)
            {
                clock.Timer.Start();
            }
            ProgressClickCount++;
            AllCount++;
            OnClicked();
        }

        private int ProgressClickCount;


        public event EventHandler TimerElapsed = null;

        protected void OnTimerElapsed()
        {
            TimerElapsed?.Invoke(this, new EventArgs());
        }

        public event EventHandler Clicked = null;

        protected void OnClicked()
        {
            Clicked?.Invoke(this, new EventArgs());
        }

        public event EventHandler CycleChanged = null;

        protected void OnCycleChanged()
        {
            CycleChanged?.Invoke(this, new EventArgs());
        }
 
        public ClockCounterClass()
        {
            clock = new TaskClock();
            clock.Timer.Elapsed += Timer_Elapsed;
        }

    }
}

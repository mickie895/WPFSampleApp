using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.ComponentModel;

namespace ClickCheckSample.Models
{
    class TaskClock
    {
        private Timer instance = null;

        public Timer Timer
        {
            get
            {
                if (instance == null)
                {
                    instance = new Timer(100);
                }
                return instance;
            }
        }

        public TaskClock()
        {
        }
    }
}

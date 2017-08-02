using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    class Controller
    {
        public delegate void StartClocksDelegate();
        public delegate void StopClocksDelegate();

        public StartClocksDelegate StartClocks = delegate { }; //start default, null by default
        public StopClocksDelegate StopClocks;

        public void StartClocksRunning()
        {
            this.StartClocks();
        }

        public void StopClocksRunning()
        {
            StopClocks?.Invoke(); //c# 6
        }
    }
}

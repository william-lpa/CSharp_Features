using System;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Timers;

namespace Delegates
{
    class UniversalClock
    {
        private DispatcherTimer ticker = null;
        private TextBox display = null;
        private TimeZoneInfo timeZoneForThisClock = null;
        private const string londonTimeZoneId = "GMT Standard Time";

        public UniversalClock(TextBox displayBox)
        {
            this.timeZoneForThisClock = TimeZoneInfo.FindSystemTimeZoneById(londonTimeZoneId);
            this.display = displayBox;
        }

        public void StartEuropeanClock()
        {
            this.ticker = new DispatcherTimer();
            this.ticker.Tick += this.OnTimedEvent;
            this.ticker.Interval = new TimeSpan(0, 0, 1); // 1 second
            this.ticker.Start();
        }

        public void StopEuropeanClock()
        {
            this.ticker.Stop();
        }

        private void OnTimedEvent(object source, EventArgs args)
        {
            DateTime localTime = DateTime.Now;
            DateTime clockTIme = TimeZoneInfo.ConvertTime(localTime, this.timeZoneForThisClock);
            int hh = clockTIme.Hour;
            int mm = clockTIme.Minute;
            int ss = clockTIme.Second;
            this.RefreshTime(hh, mm, ss);
        }

        private void RefreshTime(int hh, int mm, int ss)
        {
            this.display.Text = $"{hh}:{mm}:{ss}";
        }
    }
}

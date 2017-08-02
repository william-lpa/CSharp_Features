using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Delegates
{
    public partial class ClockWindow : Window
    {
        private LocalClock localClock = null;
        private UniversalClock londonClock = null;
        private NewYorkClock newYorkClock = null;
        private JapaneseClock tokyoClock = null;

        private Controller controller = new Controller();

        public ClockWindow()
        {
            InitializeComponent();
            localClock = new LocalClock();
            londonClock = new UniversalClock(londonTimeDisplay);
            newYorkClock = new NewYorkClock(newYorkTimeDisplay);
            tokyoClock = new JapaneseClock(tokyoTimeDisplay);

            controller.StartClocks += localClock.StartLocalClock;
            controller.StartClocks += londonClock.StartEuropeanClock;
            controller.StartClocks += newYorkClock.StartAmericanClock;
            controller.StartClocks += tokyoClock.StartJapaneseClock;

            controller.StopClocks += localClock.StopLocalClock;
            controller.StopClocks += londonClock.StopEuropeanClock;
            controller.StopClocks += newYorkClock.StopAmericanClock;
            controller.StopClocks += tokyoClock.StopJapaneseClock;

            }

    

        private void StartClick(object sender, RoutedEventArgs e)
        {
            controller.StartClocks();
            localClock.LocalClockTick += DisplayLocalTime;
            start.IsEnabled = false;
            stop.IsEnabled = true;
        }

        private void StopClick(object sender, RoutedEventArgs e)
        {
            controller.StopClocks();
            localClock.LocalClockTick -= DisplayLocalTime;
            start.IsEnabled = true;
            stop.IsEnabled = false;
        }

        private void DisplayLocalTime(string time)
        {
            localTimeDisplay.Text = time;
        }
    }
}
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
using System.Windows.Threading;

namespace Timer_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Initialize the seconds elapsed object
        private SecondsElapsed secondsElapsed = new SecondsElapsed();

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the timer control
            DispatcherTimer dispatcherTimer = new DispatcherTimer();

            // Set the time between "ticks"
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);

            // Subscribe to the tick event (add a function that occurs when it ticks)
            dispatcherTimer.Tick += DispatcherTimer_Tick;

            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            secondsElapsed.increment();
            timeDisplay.Text = secondsElapsed.secondsFormatted();
        }
    }

    public class SecondsElapsed
    {
        long seconds = 0;

        public void increment()
        {
            seconds += 1;
        }

        public void reset()
        {
            seconds = 0;
        }

        public string secondsFormatted()
        {
            TimeSpan span = TimeSpan.FromSeconds(seconds);

            return span.ToString("c");
        }
    }
}
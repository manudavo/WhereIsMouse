using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace WhereIsMouse
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConfigureTranslucentWindow();
            
            // Init temp, to update
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100); // update 100 ms
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void ConfigureTranslucentWindow()
        {
            WindowState = WindowState.Maximized;
           
            this.AllowsTransparency = true;
            this.WindowStyle = WindowStyle.None;   
            this.Background = new SolidColorBrush(Color.FromArgb(128, 255, 255, 255));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Get Coord
            System.Windows.Point cursorPosition = GetCursorPosition();

            // Show Coord
            UpdateCursorPositionLabel(cursorPosition);
        }

        private System.Windows.Point GetCursorPosition()
        {
            System.Windows.Point wpfPoint = Mouse.GetPosition(null);

            return wpfPoint;
        }

        private void UpdateCursorPositionLabel(System.Windows.Point cursorPosition)
        {
           cursorPositionLabel.Content = $"Cursor Position X = {cursorPosition.X}\nCursor Position Y = {cursorPosition.Y}";
        }

        private void Button_Click_Min(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

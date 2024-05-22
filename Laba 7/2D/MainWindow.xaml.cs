using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2D
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        System.Windows.Threading.DispatcherTimer Timer;
        DateTime dateTime = DateTime.Now;

        Line line_hour = new Line();
        Line line_minute = new Line();
        Line line_sec = new Line();

        int sec = 0;
        int min = 0;
        int hour = 0;

        public MainWindow()
        {
            InitializeComponent();

            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();


            Ellipse el_clock = new Ellipse();
            ImageBrush ib = new ImageBrush();

            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;

            ib.ImageSource = new BitmapImage(new Uri(@"C:\Users\olesy\source\repos\Minory54\GUI-programming-and-processing\Laba 7\testpic.jpg", UriKind.Absolute));
            el_clock.Fill = ib;

            el_clock.StrokeThickness = 3;
            el_clock.Stroke = Brushes.Black;

            el_clock.Width = 250;
            el_clock.Height = 250;

            scene.Children.Add(el_clock);


            line_sec.Stroke = System.Windows.Media.Brushes.Blue;
            line_sec.StrokeThickness = 3;

            line_sec.X1 = 125;
            line_sec.Y1 = 10;

            line_sec.X2 = 125;
            line_sec.Y2 = 125;

            scene.Children.Add(line_sec);


            line_minute.Stroke = System.Windows.Media.Brushes.Green;
            line_minute.StrokeThickness = 3;

            line_minute.X1 = 125;
            line_minute.Y1 = 30;

            line_minute.X2 = 125;
            line_minute.Y2 = 125;

            scene.Children.Add(line_minute);


            line_hour.Stroke = System.Windows.Media.Brushes.Red;
            line_hour.StrokeThickness = 4;

            line_hour.X1 = 125;
            line_hour.Y1 = 50;

            line_hour.X2 = 125;
            line_hour.Y2 = 125;

            scene.Children.Add(line_hour);
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            dateTime = DateTime.Now;

            sec = Convert.ToInt32(dateTime.Second);
            min = Convert.ToInt32(dateTime.Minute);
            hour = Convert.ToInt32(dateTime.Hour);

            line_sec.RenderTransform = new RotateTransform(0 + (6 * sec), 125, 125);
            line_minute.RenderTransform = new RotateTransform(0 + (6 * min), 125, 125);
            line_hour.RenderTransform = new RotateTransform(0 + (30 * hour), 125, 125);
        }

    }
}

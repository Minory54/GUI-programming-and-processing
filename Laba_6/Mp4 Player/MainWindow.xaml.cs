using Microsoft.Win32;
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
using System.Windows.Threading;

namespace Mp4_Player
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer Timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            sl_player.Value = player.Position.TotalSeconds;
            lb_timer.Content = player.Position.ToString(@"mm\:ss");
            player.MediaEnded += Player_MediaEnded;
        }

        private void Player_MediaEnded(object sender, RoutedEventArgs e)
        {
            player.Stop();
            Timer.Stop();
        }

        private void mi_openFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Выбор медиа";
            dlg.Filter = "video files (*.mp4)|*.mp4";
            if (dlg.ShowDialog() == true)
            {
                player.Source = new Uri(dlg.FileName, UriKind.Relative);
                player.Volume = sl_volume.Value;
                player.MediaOpened += Player_MediaOpened;
            }
        }

        private void Player_MediaOpened(object sender, RoutedEventArgs e)
        {
            sl_player.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;
            lb_timerTotal.Content = player.NaturalDuration.TimeSpan.ToString(@"mm\:ss");
            Timer.Interval = TimeSpan.FromMilliseconds(100);
        }

        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            player.Play();
            sl_player.Value = player.Position.TotalSeconds;
            Timer.Tick += dispatcherTimer_Tick;
            Timer.Start();
        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }

        private void sl_volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = sl_volume.Value;
        }

        private void sl_player_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Position = TimeSpan.FromSeconds(sl_player.Value);
        }
    }
}

using Microsoft.Win32;
using System;
using System.IO;
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
using System.Windows.Threading;

namespace Mp3_Player
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Dictionary<string, string> playlist = new Dictionary<string, string>();

        DispatcherTimer Timer = new DispatcherTimer();
        MediaPlayer player = new MediaPlayer();
        Random rand = new Random();
        int index = -1;

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

        private void Player_MediaOpened(object sender, EventArgs e)
        {
            lb_timerTotal.Content = player.NaturalDuration.TimeSpan.ToString(@"mm\:ss");
            sl_player.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;
            Timer.Start();
        }

        private void Player_MediaEnded(object sender, EventArgs e)
        {
            player.Stop();
            index += 1;
            if (index >= lb_listMusic.Items.Count) index = 0;
            lb_listMusic.SelectedIndex = index;
            lb_name.Content = lb_listMusic.SelectedItem.ToString();
            player.Open(new Uri(playlist[lb_listMusic.SelectedItem.ToString()], UriKind.Relative));
            player.MediaOpened += Player_MediaOpened;
            player.Play();
        }

        private void mi_addFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Выбор медиа";
            dlg.Filter = "mp3 files (*.mp3)|*.mp3";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == true)
            {
                foreach (String file in dlg.FileNames)
                {
                    lb_listMusic.Items.Add(Path.GetFileNameWithoutExtension(file));
                    playlist[Path.GetFileNameWithoutExtension(file)] = file;
                }
            }
        }

        private void mi_delFile_Click(object sender, RoutedEventArgs e)
        {
            if (lb_listMusic.SelectedItem != null)
            {
                playlist.Remove(lb_listMusic.SelectedItem.ToString());
                lb_listMusic.Items.RemoveAt(lb_listMusic.SelectedIndex);
            }
        }

        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
                player.Play();
                sl_player.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;
                Timer.Interval = TimeSpan.FromMilliseconds(100);
                Timer.Tick += dispatcherTimer_Tick;
            } 
            catch { }

        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }

        private void btn_rand_Click(object sender, RoutedEventArgs e)
        {

            if (lb_listMusic.Items.Count != 0)
            {
                player.Stop();

                index = rand.Next(0, lb_listMusic.Items.Count);
                while (index == lb_listMusic.SelectedIndex)
                {
                    index = rand.Next(0, lb_listMusic.Items.Count);
                }
                lb_listMusic.SelectedIndex = index;
                lb_name.Content = lb_listMusic.SelectedValue.ToString();
                player.Open(new Uri(playlist[lb_listMusic.SelectedItem.ToString()], UriKind.Relative));
                player.MediaOpened += Player_MediaOpened;
            }

        }

        private void sl_volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = sl_volume.Value;
        }

        private void lb_listMusic_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lb_listMusic.SelectedItem != null)
            {
                lb_name.Content = lb_listMusic.SelectedItem.ToString();
                player.Stop();
                player.Open(new Uri(playlist[lb_listMusic.SelectedItem.ToString()], UriKind.Relative));
                player.MediaOpened += Player_MediaOpened;
                index = lb_listMusic.SelectedIndex;
            }
        }

        private void sl_player_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Position = TimeSpan.FromSeconds(sl_player.Value);
        }
    }
}

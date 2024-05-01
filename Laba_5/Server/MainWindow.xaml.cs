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
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        int port = 8888;
        static TcpListener listener;
        bool server;

        public MainWindow()
        {
            InitializeComponent();
        }

        void listen()
        {
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Dispatcher.BeginInvoke(new Action(() => lb_log.Items.Add("Новый клиент подключен.")));
                Thread clientThread = new Thread(() => Process(client));
                clientThread.Start();
            }
        }

        public void Process(TcpClient tcpClient)
        {
            TcpClient client = tcpClient;
            NetworkStream stream = null; 

            try 
            {               
                stream = client.GetStream(); 
                byte[] data = new byte[64];

                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message = builder.ToString();
                    Dispatcher.BeginInvoke(new Action(() => lb_log.Items.Add(message)));
                    

                    data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(new Action(() => lb_log.Items.Add(ex.Message)));
                lb_log.Items.Add("Произошла ошибка!");
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }

        private void btn_startServer_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();
               
                Thread listenThread = new Thread(() => listen());
                listenThread.Start();   
                
                lb_log.Items.Add("Вроде подлючилось");
            }
            catch 
            {
                lb_log.Items.Add("Произошла ошибка!");
            } 
        }

        private void btn_stopServer_Click(object sender, RoutedEventArgs e)
        {
            listener.Stop();
            lb_log.Items.Add("Сервер вроде остановлен");
        }
    }
}

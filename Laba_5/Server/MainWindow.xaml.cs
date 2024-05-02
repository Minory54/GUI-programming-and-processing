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
            while (server)
            {
                try 
                { 
                    TcpClient client = listener.AcceptTcpClient();
                    Dispatcher.BeginInvoke(new Action(() => lb_log.Items.Add("Новый клиент подключен!")));
                    Thread clientThread = new Thread(() => Process(client));
                    clientThread.Start();
                }
                catch (Exception ex) 
                {
                    
                }
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

                while (server)
                {                   
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable && server);
                    string message = builder.ToString();
                    if (message == "-1")
                    {
                        Dispatcher.BeginInvoke(new Action(() => lb_log.Items.Add("Клиент отключен!")));                      
                        break;
                    }

                    Dispatcher.BeginInvoke(new Action(() => lb_log.Items.Add(message)));
                    string reversed = new string(message.Reverse().ToArray());
                    data = Encoding.Unicode.GetBytes(reversed);
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

                server = true;

                Thread listenThread = new Thread(() => listen());
                listenThread.Start();   
                
                lb_log.Items.Add("Сервер запущен!");

                btn_startServer.IsEnabled = false;
                btn_stopServer.IsEnabled = true;
            }
            catch 
            {
                lb_log.Items.Add("Произошла ошибка при запуске сервера!");
            } 
        }

        private void btn_stopServer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                server = false;
                listener.Stop();
                lb_log.Items.Add("Сервер остановлен!");

                btn_startServer.IsEnabled = true;
                btn_stopServer.IsEnabled = false;
            }
            catch
            {
                lb_log.Items.Add("Произошла ошибка при остановке сервера!");
            }
        }
    }
}

﻿using System;
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
using System.Xml.Linq;
using System.Windows.Interop;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int port = 8888;
        string address = "127.0.0.1";
        TcpClient client = null;
        NetworkStream stream = null;
        string username = "";


        public MainWindow()
        {
            InitializeComponent();
        }

        void listen()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();

                    if (message == "") break;

                    Dispatcher.BeginInvoke(new Action(() => lb_log.Items.Add("Сервер: " + message)));
                }
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(new Action(() => lb_log.Items.Add("Произошла ошибка при подключении!")));
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }

        private void btn_Connect_Click(object sender, RoutedEventArgs e)
        {
            username = tb_Name.Text;
            try 
            {
                client = new TcpClient(address, port);
                stream = client.GetStream();

                btn_Connect.IsEnabled = false;
                btn_Disconnect.IsEnabled = true;
                btn_Send.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(new Action(() => lb_log.Items.Add("Произошла ошибка при подключении!")));
            }

            Thread listenThread = new Thread(() => listen());
            listenThread.IsBackground = true;
            listenThread.Start();

        }

        private void btn_Disconnect_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string message = "-1";
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);

                btn_Connect.IsEnabled = true;
                btn_Disconnect.IsEnabled = false;
                btn_Send.IsEnabled = false;
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(new Action(() => lb_log.Items.Add("Произошла ошибка при отключении!")));
            }

        }

        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string message = tb_Message.Text;
                message = String.Format("{0}: {1}", username, message);
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(new Action(() => lb_log.Items.Add("Произошла ошибка при отправке сообщения!")));
            }
        }
    }
}

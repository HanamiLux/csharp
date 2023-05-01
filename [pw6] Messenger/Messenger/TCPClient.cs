using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Threading;
using System.Windows.Media.Animation;

namespace Messenger
{
    internal class TCPClient
    {
        private Socket server;
        private ListBox MsgListbox, UsersLB;
        private Window window;
        private IPAddress ip;
        private CancellationTokenSource cts;
        private string nickname;
        public TCPClient(ListBox listbox, Window window, IPAddress ip, string nickname, ListBox UsersLB)
        {
            this.UsersLB = UsersLB;
            this.nickname= nickname;
            this.window = window;
            this.MsgListbox = listbox;
            this.ip = ip;
        }
        public void Start()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.ConnectAsync(ip, 5225);
            if (!server.Poll(5000, SelectMode.SelectWrite))
            {
                server.Close();
                throw new Exception("Chat doesn't exist");
            }
            cts = new CancellationTokenSource();
#region передача ника с клиента серверу
            byte[] bytes = Encoding.UTF8.GetBytes($"(*&{nickname}");
            server.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
            #endregion

            ReceiveMessage();
            
        }

        private async Task ReceiveMessage()
        {
            while (!cts.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                await server.ReceiveAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                if (message.Substring(0, 3) != "(*&")
                    MsgListbox.Items.Add($"「{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year} {DateTime.Now.TimeOfDay.ToString().Substring(0, 5)}」 {message}");
                #region получение листа пользователей с сервера на клиент
                else if (message.Substring(0, 3) == "(*&")
                {
                    List<string> users = message.Substring(4).Split(' ').ToList();
                    UsersLB.ItemsSource = null;
                    UsersLB.ItemsSource = users;

                }
                #endregion



            }
            cts.Dispose();
        }

        public async Task SendMessage(string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await server.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
            if (message.Contains("/Disconnect") || message.Contains("/disconnect"))
                DisconnectServer();
        }
        public void DisconnectServer(bool createMain = false)
        {
            if(createMain)
            new MainWindow().Show();
            cts.Cancel();
            try
            {server.Close();}
            catch { }
            window.Close();
        }
    }
}


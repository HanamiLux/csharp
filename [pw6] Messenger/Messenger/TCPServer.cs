using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace Messenger
{
    internal class TCPServer
    {
        public CancellationTokenSource cts, adminCts;
        private chat_admin window;
        public Socket socket { get; private set; }
        private List<Socket> clients = new List<Socket>();
        private List<string> clientsNames = new List<string>();
        private ListBox usersLB;
        public TCPServer(ListBox listbox, chat_admin window)
        {
            usersLB = listbox;
            this.window = window;
        }
        public bool Start()
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Bind(ipPoint);
            }
            catch (Exception)
            {
                MessageBox.Show("RESTARTING THE APP!");
                return false;
            }
            
            socket.Listen(100);
            adminCts = new CancellationTokenSource();
            Listening(adminCts.Token);
            return true;
        }

        private async Task Listening(CancellationToken token)
        {
                byte[] bytes = new byte[1024];
            while (!token.IsCancellationRequested) 
            {
                var client = await socket.AcceptAsync();
                cts = new CancellationTokenSource();
                ReceiveMessage(client, cts.Token);
            }
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            adminCts.Dispose();
            cts.Dispose();
            window.Close();

        }
        private async Task ReceiveMessage(Socket client, CancellationToken token)
        {
            string nick = "";
            string allClients = string.Empty;
            while (!token.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(new ArraySegment<byte>(bytes), SocketFlags.None); 
                string message = Encoding.UTF8.GetString(bytes);

                if (message.Substring(0, 11) == "/Disconnect" || message.Substring(0, 11) == "/disconnect")
                {
                    cts.Cancel();
                    break;
                }
                else if (message.Substring(0, 11) == "&*(leftChat")
                {
                    clients.Remove(client);
                    clientsNames.Remove(message.Substring(11));
                }

                #region Передача ников с клиентов серверу
                else if (message.Substring(0, 3) == "(*&")
                {
                    message = message.Substring(3).Split('\0')[0];
                    clientsNames.Add(message);
                    nick = message;
                    #endregion

                    clients.Add(client);
                    usersLB.ItemsSource = null;
                    usersLB.ItemsSource = clientsNames;

                    #region Передача листа пользователей клиентам
                    foreach (var user in usersLB.Items)
                    {
                        allClients += " " + user.ToString();
                    }
                    foreach (var clientUser in clients)
                    {
                        SendMessage(clientUser, $"(*&{allClients}");
                    }
                    #endregion
                    continue;
                }
                foreach (var item in clients)
                {
                    SendMessage(item, message);
                }
            }
            if (client == socket)
            {
                adminCts = cts;
                return;
            }
            clients.Remove(client);
            clientsNames.Remove(nick);
            usersLB.ItemsSource = null;
            usersLB.ItemsSource = clientsNames;
            #region Передача листа пользователей клиентам
            allClients = string.Empty;
            foreach (var user in usersLB.Items)
            {
                allClients += " " + user.ToString();
            }
            foreach (var clientUser in clients)
            {
                SendMessage(clientUser, $"(*&{allClients}");
            }
            #endregion
            client.Close();
            client.Shutdown(SocketShutdown.Both);
        }

        public async Task SendMessage(Socket client, string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
        }

    }
}

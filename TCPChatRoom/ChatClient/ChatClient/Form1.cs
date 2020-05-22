using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

//technically all method names should be capitalized in C#!
namespace ChatClient
{
    public partial class Form1 : Form
    {
        //class access to client socket
        TcpClient clientSocket = new TcpClient();

        //class access to stream
        NetworkStream serverStream = default(NetworkStream);

        //class access to string
        string readData = null;
              
        //set up and show form.
        public Form1()
        {
            InitializeComponent();
        }

        //connect to server...
        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //send message to conversation text
                readData = "Connected to server!";
                msg();

                //Connect to server
                clientSocket.Connect("192.168.0.6",13000);

                //Setup stream
                serverStream = clientSocket.GetStream();

                //Convert name to bytes
                byte[] outStream = Encoding.ASCII.GetBytes(nameText.Text + "$");

                //write name to stream
                serverStream.Write(outStream, 0, outStream.Length);

                //flush stream
                serverStream.Flush();

                //new thread to get messages
                Thread ctThread = new Thread(getMessage);
                ctThread.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not connect to server!\n"+ex.Message);
            }
        }

        //send message
        private void msgBtn_Click(object sender, EventArgs e)
        {
            byte[] outStream = Encoding.ASCII.GetBytes(msgText.Text + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            msgText.Text = "";
        }

        //get messages
        private void getMessage()
        {
            while (true)
            {
                try
                {
                    //set stream
                    serverStream = clientSocket.GetStream();

                    //set buffer and memory for incoming messages
                    byte[] inStream = new byte[1024];

                    //read in messages and post them to conversation.
                    serverStream.Read(inStream, 0, inStream.Length);
                    string returndata = Encoding.ASCII.GetString(inStream);
                    readData = "" + returndata;
                    msg();
                }
                catch (Exception)
                {
                    clientSocket.Close();
                    break;
                }

            }
        }

        private void msg()
        {
            //stream safety
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(msg));
            }
            else
            {
                conversationText.Text += Environment.NewLine + " >> " + readData;
            }
        }
    }
}

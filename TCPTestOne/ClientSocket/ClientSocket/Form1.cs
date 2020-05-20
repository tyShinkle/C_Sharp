using System;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace ClientSocket
{
    public partial class Form1 : Form
    {
        // Client socket setup on machine...
        TcpClient clientSocket = new TcpClient();

        // Stream setup
        NetworkStream serverStream = default(NetworkStream);

        // read data to hold strings...
        string readData = null;

        //Show form.
        public Form1()
        {
            InitializeComponent();
        }

        //Send message.
        /*
         * This will write to our stream, and this gui's ctThread 
         * will continue updating our form with what the server
         * writes to the stream.
        */
        private void send_Click(object sender, EventArgs e)
        {
            //attempt to encode our message and write it to our stream.
            try
            {
                byte[] outStream = Encoding.ASCII.GetBytes(message.Text);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        //Connect to server. (Client runs in living room, server in bedroom)
        private void Connect_Click(object sender, EventArgs e)
        {
            try
            {
               //Connect to server (currently my bedroom)
                clientSocket.Connect("192.168.0.6", 13000);
                serverStream = clientSocket.GetStream();

                //Message...
                connectStatus.Text = "Connected!";

                //Encode message...
                byte[] outStream = Encoding.ASCII.GetBytes(message.Text);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                //start a new thread...
                Thread ctThread = new Thread(getMessage);
                ctThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /*
         * Once a thread is started (after the connection) this method 
         * will continually read the stream and set it's instance of readData 
         * to whatever the server returned. Finally it will place this text in 
         * the response text box via msg();
        */
        private void getMessage()
        {
            while (true)
            {
                //set server stream to client sockets stream.
                serverStream = clientSocket.GetStream();

                //byte array to hold bytes from stream.
                byte[] inStream = new byte[1024];

                //read incoming bytes to inStream array.
                serverStream.Read(inStream,0,1024);

                //set returnData to encoding.
                string returnData = Encoding.ASCII.GetString(inStream);

                //format string to be sent to gui...
                readData = "" + returnData;
                msg();
            }
        }

        private void msg()
        {
            //Ensure thread safety.
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(msg));
            }
            else
            {
                //Write formatted string to response textBox.
                response.Text = readData;
            }
        }
    }
}

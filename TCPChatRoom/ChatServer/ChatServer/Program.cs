using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Net;

namespace ChatServer
{
    class Program
    {
        //hashtable to hold clients, static as only one exists.
        public static Hashtable clientList = new Hashtable();

        static void Main(string[] args)
        {
            int port = 8888;

            //host server on local machine port 13000.
            TcpListener serverSocket = new TcpListener(IPAddress.Any, port);

            //start server
            serverSocket.Start();
            
            //counter
            int counter = 0;

            //message
            Console.WriteLine("Chat server started...");

            counter = 0;

            //run continuously...
            while (true)
            {
                //increment counter
                counter += 1;

                //BLOCKING
                //instantiate new client socket when signaled
                TcpClient clientSocket = serverSocket.AcceptTcpClient();

                //byte array to hold data from client
                byte[] bytesFrom = new byte[1024];

                //string to hold decoded client data.
                string dataFromClient = null;

                //stream for client 
                NetworkStream networkStream = clientSocket.GetStream();

                //read data from stream to bytesFrom
                networkStream.Read(bytesFrom, 0, 1024);

                //decode bytes
                dataFromClient = Encoding.ASCII.GetString(bytesFrom);

                //split string from client
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                //add client to client list
                clientList.Add(dataFromClient, clientSocket);

                //broadcast client joining...
                broadcast(dataFromClient + "Joined", dataFromClient, false);

                //Message
                Console.WriteLine(dataFromClient + "Joined chat!");

                //create handleClient instance to handle client from here on out.
                handleClient client = new handleClient();

                //start client with parameters
                client.startClient(clientSocket, dataFromClient, clientList);
            }
        }

        //broadcast to whole client list...
        public static void broadcast(string msg, string uName, bool flag)
        {
            //for each client...
            foreach(DictionaryEntry Item in clientList)
            {
                try
                {
                    //create socket / stream to write to...
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    //hold bytes to be encoded...
                    byte[] broadcastBytes = null;

                    //if flag is true they already joined, modify message
                    if (flag)
                    {
                        broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg);
                    }
                    else
                    {
                        broadcastBytes = Encoding.ASCII.GetBytes(msg);
                    }

                    //write appropriate mesage to stream
                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    //flush to clear buffers and truly write the message.
                    broadcastStream.Flush();
                }
                catch (Exception)
                {
                    Console.WriteLine("Could not broadcast!");
                }
            }
        }
    }//end main class

    //handle clients after they joined...
    public class handleClient
    {
        TcpClient clientSocket;
        string clientNumber;
        Hashtable clientList;

        //start new thread with client info...
        public void startClient(TcpClient clientSocket, string clientNumber, Hashtable clientList)
        {
            try
            {
                this.clientSocket = clientSocket;
                this.clientNumber = clientNumber;
                this.clientList = clientList;
                Thread clientThread = new Thread(chat);
                clientThread.Start();
            }
            catch(Exception)
            {
                Console.WriteLine("Cannot start this client!");
            }
  
        }

        public void chat()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[1024];
            string dataFromClient = null;
            byte[] sendBytes = null;
            string serverResponse = null;
            string rCount = null;
            requestCount = 0;

            while (true)
            {
                try
                {
                    //increment request count
                    requestCount++;

                    //create stream 
                    NetworkStream networkStream = clientSocket.GetStream();

                    //read bytes from stream into bytesFrom...
                    networkStream.Read(bytesFrom, 0, 1024);

                    //decode and split
                    dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                    //Message saying what client number said what.
                    Console.WriteLine("From client - " + clientNumber + " : " + dataFromClient);

                    rCount = Convert.ToString(requestCount);

                    //broadcast message in main class.
                    Program.broadcast(dataFromClient, clientNumber, true);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }//endwhile
        }//end chat
    }//end handleClient class
}

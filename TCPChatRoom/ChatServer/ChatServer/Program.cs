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

        //initiate connection and create client threads...
        static void Main(string[] args)
        {
            //try to set up ports and streams...
            try
            {
                //Constant for port...
                int PORT = 13000;
                //counter
                int counter = 0;
               
                //host server on local machine port 13000.
                TcpListener serverSocket = new TcpListener(IPAddress.Any, PORT);
                
                //start server
                serverSocket.Start();

                //message
                Console.WriteLine("Chat server started...");

                //run continuously...
                while (true)
                {
 
                    //string to hold decoded client data.
                    string dataFromClient;
                    //byte array to hold data from client
                    byte[] bytesFrom = new byte[1024];

                    //increment counter
                    counter += 1;

                    //Message
                    Console.WriteLine("Connections: " + (counter - 1));

                    //BLOCKING
                    //instantiate new client socket when signaled
                    TcpClient clientSocket = serverSocket.AcceptTcpClient();

                    //Message
                    Console.WriteLine("New connection!");

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
                    broadcast(dataFromClient + " joined the chat!", dataFromClient, false);

                    //Message
                    Console.WriteLine(dataFromClient + " joined chat!");

                    //create handleClient instance to handle client from here on out.
                    handleClient client = new handleClient();

                    //start client with parameters
                    client.startClient(clientSocket, dataFromClient, clientList);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Could not set up server!");
            }
        }

        //broadcast to whole client list...
        public static void broadcast(string msg, string uName, bool flag)
        {


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

            //for each client send message...
            foreach (DictionaryEntry Item in clientList)
            {
                TcpClient broadcastSocket = default(TcpClient);
                try
                {
                    //create socket / stream to write to...
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();

                    //write appropriate mesage to stream
                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    //flush to clear buffers and truly write the message.
                    broadcastStream.Flush();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not broadcast!\n" + ex.Message);
                    broadcastSocket.Close();
                }
            }
        }
    }//end main class

    //handle clients after they joined...
    public class handleClient
    {
        TcpClient clientSocket;
        string clientName;
        Hashtable clientList;

        //start new thread with client info...
        public void startClient(TcpClient clientSocket, string clientName, Hashtable clientList)
        {
            try
            {
                this.clientSocket = clientSocket;
                this.clientName = clientName;
                this.clientList = clientList;
                Thread clientThread = new Thread(chat);
                clientThread.Start();
            }
            catch(Exception)
            {
                Console.WriteLine("Client "+ clientName + " failed!");
                clientSocket.Close();
            }
  
        }

        public void chat()
        {
            byte[] bytesFrom = new byte[1024];

            while (true)
            {
                NetworkStream networkStream=default(NetworkStream);
                try
                {
                    //create stream 
                    networkStream = clientSocket.GetStream();

                    //read bytes from stream into bytesFrom...
                    networkStream.Read(bytesFrom, 0, 1024);

                    //decode and split
                    string dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                    //Message saying what client number said what.
                    Console.WriteLine("From client - " + clientName + " : " + dataFromClient);

                    //broadcast message in main class.
                    Program.broadcast(dataFromClient, clientName, true);
                }
                catch(Exception)
                {
                    clientList.Remove(clientName);
                    clientSocket.Close();
                    break;
                }
            }//endwhile
        }//end chat
    }//end handleClient class
}

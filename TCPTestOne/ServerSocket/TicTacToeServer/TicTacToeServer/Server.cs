using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


/*
 * At this state the server simply receives one message and returns it to the client
 * capitalized.
*/
namespace TicTacToeServer
{
    class Server
    {
        static void Main(string[] args)
        {
            //Try to initialize sockets.
            try
            {
                //set the listener on port 13000 of local machine...
                int port = 13000;
                TcpListener server = new TcpListener(IPAddress.Any, port);

                //Start listening for client requests
                server.Start();

                //Buffer for reading data @ length 1024.
                byte[] bytes = new byte[1024];

                //string to hold formatted data.
                string data;

                //Enter listening loop
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");

                    //Perform blocking call to accept requests relating to our listener object.
                    TcpClient client = server.AcceptTcpClient();

                    //When a client connects...
                    Console.WriteLine("Connected!");

                    //Get a stream object for reading and writing associated with our client.
                    NetworkStream stream = client.GetStream();

                    int i;

                    //loop to receive all data sent by the client.
                    i = stream.Read(bytes, 0, bytes.Length);

                    //if our stream contains something...
                    while (i != 0)
                    {
                        try
                        {
                            //Encode bytes to ASCII...
                            data = Encoding.ASCII.GetString(bytes, 0, i);

                            //Write message...
                            Console.WriteLine(String.Format("Received: {0}", data));

                            //Process the data sent by the client.
                            data = data.ToUpper();

                            //Convert our message back to a bitstring.
                            byte[] msg = Encoding.ASCII.GetBytes(data);

                            //Send back a response.
                            stream.Write(msg, 0, msg.Length);

                            //Write message...
                            Console.WriteLine(String.Format("Sent: {0}", data));

                            //set i to next input stream from client .
                            i = stream.Read(bytes, 0, bytes.Length);
                        }
                        // Once the client disconnects exit this loop and keep listening to start a new 
                        // client, then a new stream.
                        catch (Exception)
                        {
                            i = 0;
                        }
  
                    }

                    //Shut down  stream and connection connection
                    stream.Close();
                    client.Close();

                }
            }
            catch(SocketException e)
            {
                Console.WriteLine("Socket Exception: {0}",e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Sockets;
    using System.Text.Json;
    using System.Threading.Tasks;
    using DiceResultLib;

    namespace TCP_Server {
    internal class Program {
        private static List<DiceResult> diceList = new List<DiceResult>()
        {
            new DiceResult(){DiceValue = 3, PlayerName = "Bubber"},
            new DiceResult(){DiceValue = 2, PlayerName = "Karsten"}
        };
        static void Main(string[] args){
            //Tells the operating system that all TCP connections on port 7 should be sent to this application
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 43214);
            //Starts listening
            listener.Start();

            //Infinite loop to be able to handle more than one client
            while (true){
                //Blocks the thread until a client connects
                TcpClient socket = listener.AcceptTcpClient();


                //Starts a new thread with the incoming client, so that the application can handle several clients at the same time
                Task.Run(() => { HandleClient(socket); });
            }
        }

        static void HandleClient(TcpClient socket){
            //Gets the stream (bi-directional) that connects the server and the client
            NetworkStream ns = socket.GetStream();
            //Creates a reader for easy access to what the client sends
            StreamReader reader = new StreamReader(ns);
            //Creates a writer for easily writing to the client
            StreamWriter writer = new StreamWriter(ns);

            //Reads all data until the client sends a newline (\r\n) and stores it in a string
            string message = reader.ReadLine();

            //AddObject(message);

            //foreach (var dice in diceList) {
            //    writer.WriteLine(dice);
            //}
            //
            //Udvidet TCP
            if (message.StartsWith("Add")) {
                string[] splitJSON = message.Split(' ');
                AddObject(splitJSON[1]);
                writer.WriteLine("Your dice was added");
            }

            if (message == "GetAll") {
                foreach (var dice in diceList) {
                    writer.WriteLine(dice);
                    writer.Flush();
                }
                writer.WriteLine("Done");

            }


            //makes sure that the server sends the data immediately (it should wait for potentially more data)
            writer.Flush();
            //closes the connection, single use server.
            socket.Close();







        }

        public static void AddObject(string diceJSON){
            DiceResult newDice = JsonSerializer.Deserialize<DiceResult>(diceJSON);
            diceList.Add(newDice);
        }


    }
}

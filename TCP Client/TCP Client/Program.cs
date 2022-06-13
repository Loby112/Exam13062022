using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using DiceResultLib;

namespace TCP_Client {
    internal class Program {
        static void Main(string[] args) {
            TcpClient socket = new TcpClient("localhost", 43214);

            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);

            DiceResult Dice = new DiceResult("Tobias", 5);

            string message = JsonSerializer.Serialize(Dice);
            string message2 = Console.ReadLine();

            //writer.WriteLine(message);
            writer.WriteLine(message2);

            writer.Flush();

            //string reply = reader.ReadLine();

            //while (true) {
            //    string reply = reader.ReadLine();
            //    Console.WriteLine("Server sent " + reply);


            //    if (reply == "Player name is Tobias Dice Value is: 5") {
            //        break;
            //    }
            //}
            if (message2 == "GetAll") {
                while (true) {
                    string reply = reader.ReadLine();
                    Console.WriteLine("Server sent " + reply);
                    if (reply == "Done"){
                        break;
                    }

                }
            }

            //reply = reader.ReadLine();
            //Console.WriteLine("Server sent " + reply);
        }

    }
}

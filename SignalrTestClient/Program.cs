using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalrTestClient
{
    public class Player

    {
        public string PlayerID;
        // Add more fields here
    }

    class Program
    {
        static IHubProxy proxy;
        static void Main(string[] args)
        {
            
            HubConnection connection = new HubConnection("http://localhost:15250/");
            proxy = connection.CreateHubProxy("MyHub1");
            connection.Received += Connection_Received;
            proxy.Invoke<List<Player>>("getPlayers", (Players) => {
                foreach(Player p in Players)
                {
                    Console.WriteLine("Player ", p.PlayerID);
                }
            });

            Console.ReadLine();
        }

        private static void Connection_Received(string obj)
        {
            Console.WriteLine("Message recieved to {0} ", obj);
        }
    }
}

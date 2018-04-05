using EventsClientWS.VelibWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EventsClientWS
{
    class Program
    {

        /* Private methods */
        private static void help()
        {
            Console.WriteLine("\n" +
                "Ce service permet d'obtenir la liste des villes de l'API de JCDecaux ainsi que leurs différentes stations et les détails de ces stations.\n" +
                "Suivez les différentes étapes du programme pour obtenir les informations que vous souhaiter\n");
        }

        private static void processCity(VelibWSClient client)
        {

            Console.WriteLine("\nVeuillez choisir une ville");
            string city = Console.ReadLine();
            string stations = client.PickCity(city);
            if (stations != "null")
            {
                displayStations(city, client);
                getStation(stations, client, city);
            }
            else
            {
                Console.Write("\nLa ville demandée n'existe pas.\n");
                Console.WriteLine("Voulez-vous trouver une autre ville? (O/N)");
                string resp;
                if ((resp = Console.ReadLine()) != null)
                {
                    if (resp == "O" || resp == "o")
                    {
                        displayCities(client);
                        processCity(client);
                    }
                    else
                    {
                        Console.WriteLine("Au revoir...");
                        System.Environment.Exit(-1);
                    }
                }

            }
        }

        private static void displayCities(VelibWSClient client)
        {
            Console.WriteLine("Voulez-vous voir la liste des villes disponibles? (O/N)");
            string resp;
            if ((resp = Console.ReadLine()) != null)
            {
                if (resp == "O" || resp == "o")
                {
                    Console.WriteLine(client.GetCities());
                }

            }
        }

        private static void displayStations(string city, VelibWSClient client)
        {
            Console.WriteLine("\nVoulez-vous voir la liste des stations disponibles? (O/N)");
            string resp;
            if ((resp = Console.ReadLine()) != null)
            {
                if (resp == "O" || resp == "o")
                {
                    Console.WriteLine(client.DisplayStations(city));
                }
            }
        }

        private static void getStation(string stations, VelibWSClient client, string city)
        {
            string id;
            Boolean tryAgain = true;
            while (tryAgain)
            {
                Console.WriteLine("\nVeuillez entrer le nom d'une station à " + city);
                if ((id = Console.ReadLine()) != null)
                {

                    Console.WriteLine(client.GetStation(id, city));
                    Console.WriteLine("\nVoulez-vous trouver une autre station? (O/N)");

                    if ((id = Console.ReadLine()) != null)
                    {
                        if (id == "O" || id == "o") { tryAgain = true; }
                        else { tryAgain = false; }
                    }

                }
            }
        }

        static void Main(string[] args)
        {         
            Console.WriteLine("Entrez le nom d'une ville");
            string city = Console.ReadLine();
            Console.WriteLine("Entrez le nom d'une station");
            string station = Console.ReadLine();
            Console.WriteLine("Vous êtes abonné à la station "+ station + " à " + city);
            Console.WriteLine("Attendez afin de recevoir des notifications");
               
             
            VelibWSCallBackSink objsink = new VelibWSCallBackSink(city, station);
            InstanceContext iCntxt = new InstanceContext(objsink);

            VelibWS.VelibWSClient client = new VelibWS.VelibWSClient(iCntxt);
            client.SubscribeGetAvailableBikes();
            client.SubscribeGetAvailableBikesFinishedEvent();
            Console.ReadLine();
       

        }
    }
}

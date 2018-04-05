using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EventsVelibHostWS
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                try
                {
                    ServiceHost host = new ServiceHost(typeof(MathsLibrary.VelibWS));
                    host.Open();
                    Console.WriteLine("Service is Hosted as http://localhost:9011/VelibWS");
                   // Console.WriteLine("Service is Hosted as http://localhost:8733/Design_Time_Addresses/MathsService/maths");
                    Console.WriteLine("\nPress  key to stop the service.");
                    Console.ReadLine();
                    host.Close();
                }
                catch (Exception eX)
                {
                    Console.WriteLine("There was en error while Hosting Service [" + eX.Message + "]");
                    Console.WriteLine("\nPress  key to close.");
                    Console.ReadLine();
                }
            }
        }
    }
}

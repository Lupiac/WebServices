using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsClientWS
{
    class VelibWSCallBackSink : VelibWS.IVelibWSCallback
    {
        public void GetAvailableBikes(string station, string res)
        {
            Console.WriteLine("Event detected for station : {0} ", station);
            Console.WriteLine(res);
        }

        public void GetAvailableBikesFinished()
        {
            Console.WriteLine("End of changes");
        }
    }
}
    
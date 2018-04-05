using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsClientWS
{
    class VelibWSCallBackSink : VelibWS.IVelibWSCallback
    {
        private String city;
        private String station;
        public VelibWSCallBackSink(String city, String station)
        {
            this.city = city;
            this.station = station;
        }

        public void GetAvailableBikes(string city, string station, string res)
        {
            if ((this.city.ToLower() == city.ToLower() && station.ToLower().Contains(this.station.ToLower())))
            {
                Console.WriteLine("Event detected");
                Console.WriteLine("For city {0} ", city);
                Console.WriteLine("For station {0} ", station);
                Console.WriteLine(res);
            }
        }

        public void GetAvailableBikesFinished()
        {
            if ((this.city.ToLower() == city.ToLower() && station.ToLower().Contains(this.station.ToLower())))
            {
                Console.WriteLine("End of changes");
            }
        }
    }
}
    
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Caching;
using System.Diagnostics;
using System.ServiceModel;

namespace MathsLibrary
{
    ////////////////// Objects used /////////////////////
    public class Contract
    {
        public String Name { get; set; }
        public Contract(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Station
    {
        public String Name { get; set; }
        public int Available_bikes { get; set; }
        public int Available_bike_stands { get; set; }
        public int Bike_stands { get; set; }
        public Boolean Banking { get; set; }
        public Station(string name, int available_bikes, int available_bike_stands, int bike_stands, Boolean banking)
        {
            Name = name;
            Available_bikes = available_bikes;
            Available_bike_stands = available_bike_stands;
            Bike_stands = bike_stands;
            Banking = banking;
        }

        public override string ToString()
        {
            string str = "";
            str += "***** " + Name.ToUpper() + "*****\n";
            str += "* Il reste " + Available_bikes + " vélos disponibles \n";
            str += "* Il reste " + Available_bike_stands + " emplacements disponibles sur " + Bike_stands + '\n';
            if (Banking)
            { str += "* Le paiement par carte est possible à la borne" + '\n'; }
            else
            { str += "* Le paiement par carte n'est possible pas à la borne" + '\n'; }
            return str;
        }
    }


    public class VelibWS : IVelibWS
    {
        static Action<String, String, String> m_Event1 = delegate { };
        static Action m_Event2 = delegate { };

        /* Private attributes */
        private string apiKey = "ecde85f2f7863fbb8fe33d3f57bc2c15dddc1584";
        private int CITY_TIME = 60 * 24 * 30;
        private int STATION_TIME = 2;
        private int DETAILS_TIME = 2;

        /* Private methods */

        public static T GetObjectFromCache<T>(string cacheItemName, int cacheTimeInMinutes, Func<string, T> objectSettingFunction, string funcParam)
        {
            Debug.WriteLine(cacheItemName + "     " + objectSettingFunction + "      " + funcParam);
            ObjectCache cache = MemoryCache.Default;
            var cachedObject = (T)cache[cacheItemName];
            if (cachedObject == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheTimeInMinutes);
                cachedObject = objectSettingFunction(funcParam);
                cache.Set(cacheItemName, cachedObject, policy);
            }
            return cachedObject;
        }

 

        private Contract[] getCityContracts(string s)
        {
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts?apiKey=" + this.apiKey);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Contract[]>(responseFromServer);
        }

        /* Interface methods */

        public string PickCity(string city)
        {
            try
            {

                WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=" + this.apiKey);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                return responseFromServer;
            }
            catch
            {
                return "null";
            }
            //return JsonConvert.DeserializeObject<Station[]>(responseFromServer);

        }

        public string GetCities()
        {
            Contract[] citiesContracts = GetObjectFromCache<Contract[]>("citiesContracts", CITY_TIME, getCityContracts, "");
            string res = "\n";
            foreach (Object contract in citiesContracts)
            {
                res += contract.ToString() + "\n";
            }
            return res;
        }


        public string DisplayStations(string city)
        {
            string stations = GetObjectFromCache<string>(city, STATION_TIME, PickCity, city);
            Station[] stationList = JsonConvert.DeserializeObject<Station[]>(stations);
            if (stationList != null)
            {
                string resp = "";
                foreach (Station station in stationList)
                {
                    resp += station.Name + "\n";
                }
                return resp;
            }
            else { return ""; }
        }

        public string GetStation(string stationName, string city)
        {
            Debug.WriteLine(stationName + "    " + city);
            string stations = GetObjectFromCache<string>(city, DETAILS_TIME, PickCity, city);
            Station[] stationList = JsonConvert.DeserializeObject<Station[]>(stations);

            if (stationList != null)
            {
                foreach (Station station in stationList)
                {
                    if (station.Name.ToLower().Contains(stationName.ToLower()))
                    {
                        m_Event1(city, stationName, station.ToString());
                        m_Event2();

                        return station.ToString();
                    }
                }
            }
            return "\nLa station demandée n'a pas été trouvée";
        }

        public void ChangeCityTime(string time)
        {
            int t;
            if(int.TryParse(time, out t))
            {
                this.CITY_TIME = t;
                Debug.WriteLine("CITY_TIME: " + CITY_TIME);
            }
        }

        public void ChangeStationTime(string time)
        {
            int t;
            if (int.TryParse(time, out t))
            {
                this.STATION_TIME = t;
                Debug.WriteLine("STATION_TIME: " + STATION_TIME);
            }
        }

        public void ChangeDetailsTime(string time)
        {
            int t;
            if (int.TryParse(time, out t))
            {
                this.DETAILS_TIME = t;
                Debug.WriteLine("DETAILS_TIME: " + DETAILS_TIME);
            }
        }

        public void SubscribeGetAvailableBikes()
        {

            IVelibEvents subscriber =
            OperationContext.Current.GetCallbackChannel<IVelibEvents>();
            m_Event1 += subscriber.GetAvailableBikes;
        }
    

        public void SubscribeGetAvailableBikesFinishedEvent()
        {
            IVelibEvents subscriber =
                        OperationContext.Current.GetCallbackChannel<IVelibEvents>();
            m_Event2 += subscriber.GetAvailableBikesFinished;
        }
    }
}

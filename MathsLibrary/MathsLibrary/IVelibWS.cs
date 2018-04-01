using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MathsLibrary
{
    [ServiceContract]
    public interface IVelibWS
    {
        /*  CLIENT METHODS  */

        [OperationContract]
        string GetCities();

        [OperationContract]
        string PickCity(string city);

        [OperationContract]
        string DisplayStations(string city);

        [OperationContract]
        string GetStation(string stationName, string city);

        /*  ADMIN METHODS  */

        [OperationContract]
        void ChangeCityTime(string time);

        [OperationContract]
        void ChangeStationTime(string time);

        [OperationContract]
        void ChangeDetailsTime(string time);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MathsLibrary
{
    public interface IVelibEvents
    {
        [OperationContract(IsOneWay = true)]
        void GetAvailableBikes(String station, String res);

        [OperationContract(IsOneWay = true)]
        void GetAvailableBikesFinished();
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1.VelibWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="VelibWS.IVelibWS")]
    public interface IVelibWS {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/GetCities", ReplyAction="http://tempuri.org/IVelibWS/GetCitiesResponse")]
        string GetCities();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/GetCities", ReplyAction="http://tempuri.org/IVelibWS/GetCitiesResponse")]
        System.Threading.Tasks.Task<string> GetCitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/PickCity", ReplyAction="http://tempuri.org/IVelibWS/PickCityResponse")]
        string PickCity(string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/PickCity", ReplyAction="http://tempuri.org/IVelibWS/PickCityResponse")]
        System.Threading.Tasks.Task<string> PickCityAsync(string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/DisplayStations", ReplyAction="http://tempuri.org/IVelibWS/DisplayStationsResponse")]
        string DisplayStations(string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/DisplayStations", ReplyAction="http://tempuri.org/IVelibWS/DisplayStationsResponse")]
        System.Threading.Tasks.Task<string> DisplayStationsAsync(string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/GetStation", ReplyAction="http://tempuri.org/IVelibWS/GetStationResponse")]
        string GetStation(string stationName, string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/GetStation", ReplyAction="http://tempuri.org/IVelibWS/GetStationResponse")]
        System.Threading.Tasks.Task<string> GetStationAsync(string stationName, string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/ChangeCityTime", ReplyAction="http://tempuri.org/IVelibWS/ChangeCityTimeResponse")]
        void ChangeCityTime(string time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/ChangeCityTime", ReplyAction="http://tempuri.org/IVelibWS/ChangeCityTimeResponse")]
        System.Threading.Tasks.Task ChangeCityTimeAsync(string time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/ChangeStationTime", ReplyAction="http://tempuri.org/IVelibWS/ChangeStationTimeResponse")]
        void ChangeStationTime(string time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/ChangeStationTime", ReplyAction="http://tempuri.org/IVelibWS/ChangeStationTimeResponse")]
        System.Threading.Tasks.Task ChangeStationTimeAsync(string time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/ChangeDetailsTime", ReplyAction="http://tempuri.org/IVelibWS/ChangeDetailsTimeResponse")]
        void ChangeDetailsTime(string time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibWS/ChangeDetailsTime", ReplyAction="http://tempuri.org/IVelibWS/ChangeDetailsTimeResponse")]
        System.Threading.Tasks.Task ChangeDetailsTimeAsync(string time);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVelibWSChannel : WindowsFormsApp1.VelibWS.IVelibWS, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VelibWSClient : System.ServiceModel.ClientBase<WindowsFormsApp1.VelibWS.IVelibWS>, WindowsFormsApp1.VelibWS.IVelibWS {
        
        public VelibWSClient() {
        }
        
        public VelibWSClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VelibWSClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VelibWSClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VelibWSClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetCities() {
            return base.Channel.GetCities();
        }
        
        public System.Threading.Tasks.Task<string> GetCitiesAsync() {
            return base.Channel.GetCitiesAsync();
        }
        
        public string PickCity(string city) {
            return base.Channel.PickCity(city);
        }
        
        public System.Threading.Tasks.Task<string> PickCityAsync(string city) {
            return base.Channel.PickCityAsync(city);
        }
        
        public string DisplayStations(string city) {
            return base.Channel.DisplayStations(city);
        }
        
        public System.Threading.Tasks.Task<string> DisplayStationsAsync(string city) {
            return base.Channel.DisplayStationsAsync(city);
        }
        
        public string GetStation(string stationName, string city) {
            return base.Channel.GetStation(stationName, city);
        }
        
        public System.Threading.Tasks.Task<string> GetStationAsync(string stationName, string city) {
            return base.Channel.GetStationAsync(stationName, city);
        }
        
        public void ChangeCityTime(string time) {
            base.Channel.ChangeCityTime(time);
        }
        
        public System.Threading.Tasks.Task ChangeCityTimeAsync(string time) {
            return base.Channel.ChangeCityTimeAsync(time);
        }
        
        public void ChangeStationTime(string time) {
            base.Channel.ChangeStationTime(time);
        }
        
        public System.Threading.Tasks.Task ChangeStationTimeAsync(string time) {
            return base.Channel.ChangeStationTimeAsync(time);
        }
        
        public void ChangeDetailsTime(string time) {
            base.Channel.ChangeDetailsTime(time);
        }
        
        public System.Threading.Tasks.Task ChangeDetailsTimeAsync(string time) {
            return base.Channel.ChangeDetailsTimeAsync(time);
        }
    }
}

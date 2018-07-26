﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lbar4_BrianLiang_WebClient.CustomerWebClientServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CustomerWebClientServiceReference.IIncidentService")]
    public interface IIncidentService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIncidentService/GetAllIncidents", ReplyAction="http://tempuri.org/IIncidentService/GetAllIncidentsResponse")]
        Lab4_BrianLiang.Incident[] GetAllIncidents(int techID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIncidentService/GetAllIncidents", ReplyAction="http://tempuri.org/IIncidentService/GetAllIncidentsResponse")]
        System.Threading.Tasks.Task<Lab4_BrianLiang.Incident[]> GetAllIncidentsAsync(int techID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIncidentService/GetAllCustIncidents", ReplyAction="http://tempuri.org/IIncidentService/GetAllCustIncidentsResponse")]
        Lab4_BrianLiang.Incident[] GetAllCustIncidents(int custID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIncidentService/GetAllCustIncidents", ReplyAction="http://tempuri.org/IIncidentService/GetAllCustIncidentsResponse")]
        System.Threading.Tasks.Task<Lab4_BrianLiang.Incident[]> GetAllCustIncidentsAsync(int custID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIncidentService/GetCustomerID", ReplyAction="http://tempuri.org/IIncidentService/GetCustomerIDResponse")]
        Lab4_BrianLiang.Incident[] GetCustomerID();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIncidentService/GetCustomerID", ReplyAction="http://tempuri.org/IIncidentService/GetCustomerIDResponse")]
        System.Threading.Tasks.Task<Lab4_BrianLiang.Incident[]> GetCustomerIDAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IIncidentServiceChannel : Lbar4_BrianLiang_WebClient.CustomerWebClientServiceReference.IIncidentService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IncidentServiceClient : System.ServiceModel.ClientBase<Lbar4_BrianLiang_WebClient.CustomerWebClientServiceReference.IIncidentService>, Lbar4_BrianLiang_WebClient.CustomerWebClientServiceReference.IIncidentService {
        
        public IncidentServiceClient() {
        }
        
        public IncidentServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IncidentServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IncidentServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IncidentServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Lab4_BrianLiang.Incident[] GetAllIncidents(int techID) {
            return base.Channel.GetAllIncidents(techID);
        }
        
        public System.Threading.Tasks.Task<Lab4_BrianLiang.Incident[]> GetAllIncidentsAsync(int techID) {
            return base.Channel.GetAllIncidentsAsync(techID);
        }
        
        public Lab4_BrianLiang.Incident[] GetAllCustIncidents(int custID) {
            return base.Channel.GetAllCustIncidents(custID);
        }
        
        public System.Threading.Tasks.Task<Lab4_BrianLiang.Incident[]> GetAllCustIncidentsAsync(int custID) {
            return base.Channel.GetAllCustIncidentsAsync(custID);
        }
        
        public Lab4_BrianLiang.Incident[] GetCustomerID() {
            return base.Channel.GetCustomerID();
        }
        
        public System.Threading.Tasks.Task<Lab4_BrianLiang.Incident[]> GetCustomerIDAsync() {
            return base.Channel.GetCustomerIDAsync();
        }
    }
}
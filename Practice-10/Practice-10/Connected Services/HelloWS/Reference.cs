﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practice_10.HelloWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HelloWS.IOurFirstWebService")]
    public interface IOurFirstWebService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOurFirstWebService/GetHelloMessage", ReplyAction="http://tempuri.org/IOurFirstWebService/GetHelloMessageResponse")]
        string GetHelloMessage(string myName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOurFirstWebService/GetHelloMessage", ReplyAction="http://tempuri.org/IOurFirstWebService/GetHelloMessageResponse")]
        System.Threading.Tasks.Task<string> GetHelloMessageAsync(string myName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOurFirstWebServiceChannel : Practice_10.HelloWS.IOurFirstWebService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OurFirstWebServiceClient : System.ServiceModel.ClientBase<Practice_10.HelloWS.IOurFirstWebService>, Practice_10.HelloWS.IOurFirstWebService {
        
        public OurFirstWebServiceClient() {
        }
        
        public OurFirstWebServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OurFirstWebServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OurFirstWebServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OurFirstWebServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetHelloMessage(string myName) {
            return base.Channel.GetHelloMessage(myName);
        }
        
        public System.Threading.Tasks.Task<string> GetHelloMessageAsync(string myName) {
            return base.Channel.GetHelloMessageAsync(myName);
        }
    }
}

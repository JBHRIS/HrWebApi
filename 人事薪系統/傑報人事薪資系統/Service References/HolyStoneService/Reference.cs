﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.296
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace JBHR.HolyStoneService {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://ssiscardweb.provider.ws.holystone.com")]
    public partial class Exception1 : object, System.ComponentModel.INotifyPropertyChanged {
        
        private Exception exceptionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public Exception Exception {
            get {
                return this.exceptionField;
            }
            set {
                this.exceptionField = value;
                this.RaisePropertyChanged("Exception");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ssiscardweb.provider.ws.holystone.com")]
    public partial class Exception : object, System.ComponentModel.INotifyPropertyChanged {
        
        private object exception1Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Exception", IsNullable=true, Order=0)]
        public object Exception1 {
            get {
                return this.exception1Field;
            }
            set {
                this.exception1Field = value;
                this.RaisePropertyChanged("Exception1");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ssiscardweb.provider.ws.holystone.com", ConfigurationName="HolyStoneService.CardlogWebServiceProviderPortType")]
    public interface CardlogWebServiceProviderPortType {
        
        // CODEGEN: 參數 'return' 需要無法以參數模式來擷取的其他架構資訊。特定屬性為 'System.Xml.Serialization.XmlElementAttribute'。
        [System.ServiceModel.OperationContractAttribute(Action="urn:getCardlog", ReplyAction="urn:getCardlogResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(JBHR.HolyStoneService.Exception1), Action="urn:getCardlogException", Name="Exception")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        JBHR.HolyStoneService.getCardlogResponse getCardlog(JBHR.HolyStoneService.getCardlogRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getCardlog", WrapperNamespace="http://ssiscardweb.provider.ws.holystone.com", IsWrapped=true)]
    public partial class getCardlogRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ssiscardweb.provider.ws.holystone.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string clientName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ssiscardweb.provider.ws.holystone.com", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string sdate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ssiscardweb.provider.ws.holystone.com", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string edate;
        
        public getCardlogRequest() {
        }
        
        public getCardlogRequest(string clientName, string sdate, string edate) {
            this.clientName = clientName;
            this.sdate = sdate;
            this.edate = edate;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getCardlogResponse", WrapperNamespace="http://ssiscardweb.provider.ws.holystone.com", IsWrapped=true)]
    public partial class getCardlogResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ssiscardweb.provider.ws.holystone.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        public getCardlogResponse() {
        }
        
        public getCardlogResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CardlogWebServiceProviderPortTypeChannel : JBHR.HolyStoneService.CardlogWebServiceProviderPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CardlogWebServiceProviderPortTypeClient : System.ServiceModel.ClientBase<JBHR.HolyStoneService.CardlogWebServiceProviderPortType>, JBHR.HolyStoneService.CardlogWebServiceProviderPortType {
        
        public CardlogWebServiceProviderPortTypeClient() {
        }
        
        public CardlogWebServiceProviderPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CardlogWebServiceProviderPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CardlogWebServiceProviderPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CardlogWebServiceProviderPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        JBHR.HolyStoneService.getCardlogResponse JBHR.HolyStoneService.CardlogWebServiceProviderPortType.getCardlog(JBHR.HolyStoneService.getCardlogRequest request) {
            return base.Channel.getCardlog(request);
        }
        
        public string getCardlog(string clientName, string sdate, string edate) {
            JBHR.HolyStoneService.getCardlogRequest inValue = new JBHR.HolyStoneService.getCardlogRequest();
            inValue.clientName = clientName;
            inValue.sdate = sdate;
            inValue.edate = edate;
            JBHR.HolyStoneService.getCardlogResponse retVal = ((JBHR.HolyStoneService.CardlogWebServiceProviderPortType)(this)).getCardlog(inValue);
            return retVal.@return;
        }
    }
}

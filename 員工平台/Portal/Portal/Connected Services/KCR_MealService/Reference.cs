﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Portal.KCR_MealService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="KCR_MealApplySettingEntry", Namespace="http://schemas.datacontract.org/2004/07/JBHR2Service.KCR_Custom.Meal")]
    [System.SerializableAttribute()]
    public partial class KCR_MealApplySettingEntry : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ADateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ApplyFlagField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AutoKeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmployeeIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid GIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool HoliMealFlagField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime Key_DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Key_ManField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MealGroupField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MealGroupNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MealTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MealTypeNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NoteField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ADate {
            get {
                return this.ADateField;
            }
            set {
                if ((this.ADateField.Equals(value) != true)) {
                    this.ADateField = value;
                    this.RaisePropertyChanged("ADate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ApplyFlag {
            get {
                return this.ApplyFlagField;
            }
            set {
                if ((this.ApplyFlagField.Equals(value) != true)) {
                    this.ApplyFlagField = value;
                    this.RaisePropertyChanged("ApplyFlag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AutoKey {
            get {
                return this.AutoKeyField;
            }
            set {
                if ((this.AutoKeyField.Equals(value) != true)) {
                    this.AutoKeyField = value;
                    this.RaisePropertyChanged("AutoKey");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BTime {
            get {
                return this.BTimeField;
            }
            set {
                if ((object.ReferenceEquals(this.BTimeField, value) != true)) {
                    this.BTimeField = value;
                    this.RaisePropertyChanged("BTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DDate {
            get {
                return this.DDateField;
            }
            set {
                if ((this.DDateField.Equals(value) != true)) {
                    this.DDateField = value;
                    this.RaisePropertyChanged("DDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmployeeID {
            get {
                return this.EmployeeIDField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeeIDField, value) != true)) {
                    this.EmployeeIDField = value;
                    this.RaisePropertyChanged("EmployeeID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid GID {
            get {
                return this.GIDField;
            }
            set {
                if ((this.GIDField.Equals(value) != true)) {
                    this.GIDField = value;
                    this.RaisePropertyChanged("GID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool HoliMealFlag {
            get {
                return this.HoliMealFlagField;
            }
            set {
                if ((this.HoliMealFlagField.Equals(value) != true)) {
                    this.HoliMealFlagField = value;
                    this.RaisePropertyChanged("HoliMealFlag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Key_Date {
            get {
                return this.Key_DateField;
            }
            set {
                if ((this.Key_DateField.Equals(value) != true)) {
                    this.Key_DateField = value;
                    this.RaisePropertyChanged("Key_Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Key_Man {
            get {
                return this.Key_ManField;
            }
            set {
                if ((object.ReferenceEquals(this.Key_ManField, value) != true)) {
                    this.Key_ManField = value;
                    this.RaisePropertyChanged("Key_Man");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MealGroup {
            get {
                return this.MealGroupField;
            }
            set {
                if ((object.ReferenceEquals(this.MealGroupField, value) != true)) {
                    this.MealGroupField = value;
                    this.RaisePropertyChanged("MealGroup");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MealGroupName {
            get {
                return this.MealGroupNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MealGroupNameField, value) != true)) {
                    this.MealGroupNameField = value;
                    this.RaisePropertyChanged("MealGroupName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MealType {
            get {
                return this.MealTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.MealTypeField, value) != true)) {
                    this.MealTypeField = value;
                    this.RaisePropertyChanged("MealType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MealTypeName {
            get {
                return this.MealTypeNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MealTypeNameField, value) != true)) {
                    this.MealTypeNameField = value;
                    this.RaisePropertyChanged("MealTypeName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Note {
            get {
                return this.NoteField;
            }
            set {
                if ((object.ReferenceEquals(this.NoteField, value) != true)) {
                    this.NoteField = value;
                    this.RaisePropertyChanged("Note");
                }
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="KCR_MealResult", Namespace="http://schemas.datacontract.org/2004/07/JBHR2Service.KCR_Custom.Meal")]
    [System.SerializableAttribute()]
    public partial class KCR_MealResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMsgField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsFinishField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StackTraceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMsg {
            get {
                return this.ErrorMsgField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMsgField, value) != true)) {
                    this.ErrorMsgField = value;
                    this.RaisePropertyChanged("ErrorMsg");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsFinish {
            get {
                return this.IsFinishField;
            }
            set {
                if ((this.IsFinishField.Equals(value) != true)) {
                    this.IsFinishField = value;
                    this.RaisePropertyChanged("IsFinish");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StackTrace {
            get {
                return this.StackTraceField;
            }
            set {
                if ((object.ReferenceEquals(this.StackTraceField, value) != true)) {
                    this.StackTraceField = value;
                    this.RaisePropertyChanged("StackTrace");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="KCR_MealService.IKCR_MealService")]
    public interface IKCR_MealService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKCR_MealService/DoWork", ReplyAction="http://tempuri.org/IKCR_MealService/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKCR_MealService/DoWork", ReplyAction="http://tempuri.org/IKCR_MealService/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKCR_MealService/KCR_GetMealApplySettingByEmpID", ReplyAction="http://tempuri.org/IKCR_MealService/KCR_GetMealApplySettingByEmpIDResponse")]
        Portal.KCR_MealService.KCR_MealApplySettingEntry[] KCR_GetMealApplySettingByEmpID(string EmployeeID, System.DateTime ADate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKCR_MealService/KCR_GetMealApplySettingByEmpID", ReplyAction="http://tempuri.org/IKCR_MealService/KCR_GetMealApplySettingByEmpIDResponse")]
        System.Threading.Tasks.Task<Portal.KCR_MealService.KCR_MealApplySettingEntry[]> KCR_GetMealApplySettingByEmpIDAsync(string EmployeeID, System.DateTime ADate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKCR_MealService/KCR_UpdateMealApplySettingByEmpID", ReplyAction="http://tempuri.org/IKCR_MealService/KCR_UpdateMealApplySettingByEmpIDResponse")]
        Portal.KCR_MealService.KCR_MealResult KCR_UpdateMealApplySettingByEmpID(Portal.KCR_MealService.KCR_MealApplySettingEntry[] MealApplySetting);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKCR_MealService/KCR_UpdateMealApplySettingByEmpID", ReplyAction="http://tempuri.org/IKCR_MealService/KCR_UpdateMealApplySettingByEmpIDResponse")]
        System.Threading.Tasks.Task<Portal.KCR_MealService.KCR_MealResult> KCR_UpdateMealApplySettingByEmpIDAsync(Portal.KCR_MealService.KCR_MealApplySettingEntry[] MealApplySetting);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IKCR_MealServiceChannel : Portal.KCR_MealService.IKCR_MealService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KCR_MealServiceClient : System.ServiceModel.ClientBase<Portal.KCR_MealService.IKCR_MealService>, Portal.KCR_MealService.IKCR_MealService {
        
        public KCR_MealServiceClient() {
        }
        
        public KCR_MealServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public KCR_MealServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KCR_MealServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KCR_MealServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public Portal.KCR_MealService.KCR_MealApplySettingEntry[] KCR_GetMealApplySettingByEmpID(string EmployeeID, System.DateTime ADate) {
            return base.Channel.KCR_GetMealApplySettingByEmpID(EmployeeID, ADate);
        }
        
        public System.Threading.Tasks.Task<Portal.KCR_MealService.KCR_MealApplySettingEntry[]> KCR_GetMealApplySettingByEmpIDAsync(string EmployeeID, System.DateTime ADate) {
            return base.Channel.KCR_GetMealApplySettingByEmpIDAsync(EmployeeID, ADate);
        }
        
        public Portal.KCR_MealService.KCR_MealResult KCR_UpdateMealApplySettingByEmpID(Portal.KCR_MealService.KCR_MealApplySettingEntry[] MealApplySetting) {
            return base.Channel.KCR_UpdateMealApplySettingByEmpID(MealApplySetting);
        }
        
        public System.Threading.Tasks.Task<Portal.KCR_MealService.KCR_MealResult> KCR_UpdateMealApplySettingByEmpIDAsync(Portal.KCR_MealService.KCR_MealApplySettingEntry[] MealApplySetting) {
            return base.Channel.KCR_UpdateMealApplySettingByEmpIDAsync(MealApplySetting);
        }
    }
}

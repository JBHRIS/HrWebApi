//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option or rebuild the Visual Studio project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.Resource", global::System.Reflection.Assembly.Load("App_GlobalResources"));
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 員工工號.
        /// </summary>
        internal static string Account_aspx_EmpNameLabel_DisplayText {
            get {
                return ResourceManager.GetString("Account_aspx_EmpNameLabel_DisplayText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 工號.
        /// </summary>
        internal static string Entry_aspx_EnterEmpId {
            get {
                return ResourceManager.GetString("Entry_aspx_EnterEmpId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 密碼.
        /// </summary>
        internal static string Entry_aspx_EnterPassword {
            get {
                return ResourceManager.GetString("Entry_aspx_EnterPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 輸入密碼.
        /// </summary>
        internal static string Entry_aspx_initEnterPassword {
            get {
                return ResourceManager.GetString("Entry_aspx_initEnterPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 確認密碼.
        /// </summary>
        internal static string Entry_aspx_initEnterPasswordConfirm {
            get {
                return ResourceManager.GetString("Entry_aspx_initEnterPasswordConfirm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 初始化密碼.
        /// </summary>
        internal static string Entry_aspx_initSetPasswordShowName {
            get {
                return ResourceManager.GetString("Entry_aspx_initSetPasswordShowName", resourceCulture);
            }
        }
    }
}

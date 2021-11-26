using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace JBHRIS.Api.Tools.Tool
{
    /// <summary>
    /// 
    /// </summary>
    public class Auth
    {
        /// <summary>
        /// Impersonates the given user during the session.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool ImpersonateUser(string domain, string userName, string password)
        {
            //WindowsIdentity tempWindowsIdentity;
            //IntPtr token = IntPtr.Zero;
            //IntPtr tokenDuplicate = IntPtr.Zero;

            //if (RevertToSelf())
            //{
            //    if (LogonUser(userName, domain, password, LOGON32_LOGON_INTERACTIVE,
            //        LOGON32_PROVIDER_DEFAULT, ref token) != 0)
            //    {
            //        if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
            //        {
            //            tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
            //            impersonationContext = tempWindowsIdentity.Impersonate();
            //            if (impersonationContext != null)
            //            {
            //                CloseHandle(token);
            //                CloseHandle(tokenDuplicate);
            //                return true;
            //            }
            //        }
            //    }
            //}
            //if (token != IntPtr.Zero)
            //    CloseHandle(token);
            //if (tokenDuplicate != IntPtr.Zero)
            //    CloseHandle(tokenDuplicate);
            return false;
        }

        /// <summary>
        /// Undoes the current impersonation.
        /// </summary>
        public void undoImpersonation()
        {
            // impersonationContext.Undo();
        }

        #region Impersionation global variables
        //先引用API
        public const int LOGON32_LOGON_NEW_CREDENTIALS = 9; //直接存取網路芳鄰
        public const int LOGON32_LOGON_INTERACTIVE = 2;     //電腦存在於網域
        public const int LOGON32_PROVIDER_DEFAULT = 0;

        //static WindowsImpersonationContext impersonationContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpszUserName"></param>
        /// <param name="lpszDomain"></param>
        /// <param name="lpszPassword"></param>
        /// <param name="dwLogonType"></param>
        /// <param name="dwLogonProvider"></param>
        /// <param name="phToken"></param>
        /// <returns></returns>
        [DllImport("advapi32.dll")]
        public static extern int LogonUser(String lpszUserName,
            String lpszDomain,
            String lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            ref IntPtr phToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hToken"></param>
        /// <param name="impersonationLevel"></param>
        /// <param name="hNewToken"></param>
        /// <returns></returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DuplicateToken(IntPtr hToken,
            int impersonationLevel,
            ref IntPtr hNewToken);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RevertToSelf();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);
        #endregion
    }
}

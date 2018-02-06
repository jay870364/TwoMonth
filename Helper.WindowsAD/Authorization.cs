using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Helper.WindowsAD
{
    public class Authorization
    {
        private const int LOGON32_PROVIDER_DEFAULT = 0;
        private const int LOGON32_LOGON_NEW_CREDENTIALS = 9;

        //登入
        [DllImport("advapi32.dll", SetLastError = true)]
        protected static extern bool LogonUser(
            string lpszUsername,
            string lpszDomain,
            string lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            ref IntPtr phToken);

        //登出
        [DllImport("kernel32.dll")]
        protected extern static bool CloseHandle(IntPtr hToken);

        public static void LoginServer(string account, string password, string ip)
        {
            IntPtr tokenHandle = new IntPtr(0);
            tokenHandle = IntPtr.Zero;
            bool returnValue = LogonUser(account, ip, password, LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_DEFAULT, ref tokenHandle);
            WindowsIdentity w = new WindowsIdentity(tokenHandle);
            w.Impersonate();
        }
    }
}
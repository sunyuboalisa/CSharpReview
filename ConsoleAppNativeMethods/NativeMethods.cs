using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNativeMethods
{
    public static class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateHardLinkW", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CreateHardLink(
            [In, MarshalAs(UnmanagedType.LPStr)] string newFileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string existingFileName,
            IntPtr securityAttribute);
        
        internal static void CreateHardLink(string oldFileName,string newFileName)
        {
            if (!CreateHardLink(newFileName,oldFileName,IntPtr.Zero))
            {
                var ex = new Win32Exception(Marshal.GetLastWin32Error());
                throw new IOException(ex.Message, ex);
            }
        }

        public static class FileUtility
        {
            [FileIOPermission(SecurityAction.LinkDemand,Unrestricted =true)]
            public static void CreateHardLink(string oldFileName,string newFileName)
            {
                NativeMethods.CreateHardLink(oldFileName, newFileName);
            }
        }
    }
}

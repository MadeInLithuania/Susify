using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Susify
{
    class Program
    {
        static void Main(string[] args)
        {          
            try
            {
                #region First creation of the .sus extension
                RegistryKey reg = Registry.ClassesRoot.CreateSubKey(".sus");
                reg.OpenSubKey(".sus", true);
                reg.SetValue("", "susfile", RegistryValueKind.String);
                reg.SetValue("Content Type", "application/x-msdownload", RegistryValueKind.String);
                //reg.SetValue("Shell", "open", RegistryValueKind.String);
                //reg.SetValue("command", "", RegistryValueKind.String);
                reg.Close();
                #endregion

                #region Making computer recognize the new extension
                RegistryKey subReg = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.sus\OpenWithProgids");
                subReg.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.sus\OpenWithProgids", true);
                subReg.SetValue("susfile", new byte[0], RegistryValueKind.Binary);
                subReg.Close();
                RegistryKey subRegList = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.sus\OpenWithList");
                subRegList.Close();
                #endregion

                #region Writes the variable %PATHEXT%
                Environment.SetEnvironmentVariable("PATHEXT", ".SUS;.COM;.EXE;.BAT;.CMD;.VBS;.VBE;.JS;.JSE;.WSF;.WSH;.MSC", EnvironmentVariableTarget.Machine);
                #endregion
                MessageBox.Show("Your files are now sus !");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

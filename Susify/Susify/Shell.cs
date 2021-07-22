using Microsoft.Win32;
using System;
using System.Windows.Forms;


namespace Susify
{
    class Shell
    {
        string defaultIcon = @"susfile\DefaultIcon";
        string openShell = @"susfile\shell\open";
        string openCommand = @"susfile\shell\open\command";
        string runas = @"susfile\shell\runas";
        string runas_cmd = @"susfile\shell\runas\command";
        string runasUser = @"susfile\shell\runasuser";

        string cmdValue = "\" % 1\" %*";

        public void SetIcon()
        {
            RegistryKey icon = Registry.ClassesRoot.CreateSubKey(defaultIcon);
            RegistryKey shell_open = Registry.ClassesRoot.CreateSubKey(openShell);
            RegistryKey shell_opencmd = Registry.ClassesRoot.CreateSubKey(openCommand);
            RegistryKey shell_runas = Registry.ClassesRoot.CreateSubKey(runas);
            RegistryKey shell_runas_cmd = Registry.ClassesRoot.CreateSubKey(runas_cmd);
            RegistryKey shell_runAsUser = Registry.ClassesRoot.CreateSubKey(runasUser);

            icon.SetValue("", "%1");
            shell_open.SetValue("EditFlags", new byte[0]);
            shell_opencmd.SetValue("", cmdValue);
            shell_opencmd.SetValue("IsolatedCommand", cmdValue);
            shell_runas.SetValue("HasLUAShield", "");
            shell_runas_cmd.SetValue("", cmdValue);
            shell_runas_cmd.SetValue("IsolatedCommand", cmdValue);
            shell_runAsUser.SetValue("", "@shell32.dll,-50944");
            shell_runAsUser.SetValue("Extended", "");
            icon.Close(); shell_open.Close(); shell_opencmd.Close(); shell_runas.Close(); shell_runAsUser.Close();
        }
    }
}

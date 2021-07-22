using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Susify
{
    class SusExtensionInfos
    {
        public void WriteSusType()
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\susfile");
            key.SetValue("", "Very sus file",RegistryValueKind.String);
            key.SetValue("FriendlyTypeName", @"@%SystemRoot%\System32\shell32.dll,-10156");
            key.SetValue("EditFlags", new byte[0x38, 0x07, 0x00, 0x00], RegistryValueKind.Binary);
            key.Close();
        }
    }
}

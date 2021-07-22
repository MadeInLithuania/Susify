using Microsoft.Win32;
using System;
using System.Windows.Forms;


namespace Susify
{
    class WriteSusExt
    {
        string extension = ".sus";
        string newFile = "susfile";
        string extDesc = "Very sus file";
        public void CreateSusExtension()
        {
            try
            {
                #region First creation of the .sus extension
                RegistryKey reg = Registry.ClassesRoot.CreateSubKey(".sus");
                reg.OpenSubKey(extension, true);
                reg.SetValue("", newFile, RegistryValueKind.String);
                reg.SetValue("Content Type", "application/x-msdownload", RegistryValueKind.String);
                reg.Close();
                #endregion

                #region Making computer recognize the new extension
                RegistryKey subReg = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.sus\OpenWithProgids");
                subReg.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.sus\OpenWithProgids", true);
                subReg.SetValue(newFile, new byte[0], RegistryValueKind.Binary);
                subReg.Close();
                RegistryKey subRegList = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.sus\OpenWithList");
                subRegList.Close();
                #endregion

                #region Writes the variable %PATHEXT%
                Environment.SetEnvironmentVariable("PATHEXT", ".SUS;.COM;.EXE;.BAT;.CMD;.VBS;.VBE;.JS;.JSE;.WSF;.WSH;.MSC", EnvironmentVariableTarget.Machine);
                #endregion
                WriteSusType();
                WriteFileAssociation();
                WriteKindMap();
                MessageBox.Show("Your files are now sus !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void WriteSusType()
        {

            RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\susfile");
            key.SetValue("", extDesc, RegistryValueKind.String);
            key.SetValue("FriendlyTypeName", @"@%SystemRoot%\System32\shell32.dll,-10156");
            key.SetValue("EditFlags", new byte[4], RegistryValueKind.Binary);
            key.Close();
        }

        void WriteFileAssociation()
        {
            RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"SystemFileAssociations\.sus");
            key.SetValue("FullDetails", "prop:System.PropGroup.Description;System.FileDescription;System.ItemTypeText;System.FileVersion;System.Software.ProductName;System.Software.ProductVersion;System.Copyright;*System.Category;*System.Comment;System.Size;System.DateModified;System.Language;*System.Trademarks;*System.OriginalFileName");
            key.SetValue("InfoTip", "prop:System.FileDescription;System.Company;System.FileVersion;System.DateCreated;System.Size");
            key.SetValue("TileInfo", "prop:System.FileDescription;System.Company;System.FileVersion;System.DateCreated;System.Size");
        }

        void WriteKindMap()
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\KindMap");
            key.SetValue(".sus", "program", RegistryValueKind.String);
        }
    }
}

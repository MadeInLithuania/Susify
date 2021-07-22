using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Susify
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteSusExt ext = new WriteSusExt();
            Shell shell = new Shell();
            ext.CreateSusExtension();
            shell.SetIcon();
        }
    }
}

using Syncfusion.UI.Xaml.Grid;
using System.Windows.Media;
using System.IO;
using System.Text;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Data;

namespace KamyonTakip.Main
{
    /// <summary>
    /// App.xaml etkileşim mantığı
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTg1MzUxQDMxMzcyZTM0MmUzMGhpVURQWlFPbDZueTM5VHZodDdmZ0paa3RhSDF2VkgrMmxTSk1YVmFJWlE9;MTg1MzUyQDMxMzcyZTM0MmUzMG5CTkgrcTNUZndMbzluOHZaK29BMFIvSzMxWkxRY3NqSU9vKzZLWENkL3c9");
        }

    }
}

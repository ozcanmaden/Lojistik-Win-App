using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KamyonTakip.Main.View
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void WindowHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void WindowHeader_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            vm.MaximizeCommand.Execute(this);
        }

        private void TabControlExt_TabClosed(object sender, Syncfusion.Windows.Tools.Controls.CloseTabEventArgs e)
        {
            var content = e.TargetTabItem.Content;
            string header = content.GetType().GetProperty("Header").GetValue(content).ToString();
            var test = vm.TabItems.FirstOrDefault(a => a.Header == header);
            vm.TabItems.Remove(vm.TabItems.FirstOrDefault(a => a.Header == header));
        }
    }
}

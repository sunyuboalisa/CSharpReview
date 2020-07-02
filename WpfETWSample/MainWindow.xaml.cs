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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfETWSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Test();
        }
        
        void Test()
        {
            IntPtr handle = new WindowInteropHelper(this).Handle;
            string sHandle = handle.ToString();
            IntPtr newHandle = new IntPtr(Convert.ToInt32(sHandle)); 

        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test();
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }

        private async void Window_Activated(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            (App.Current as App).OnActivated();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfAppClassMember
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 测试下什么情况下可以引起窗体激活事件。
        int i = 0;

        public MainWindow()
        {
            InitializeComponent();
            var s=this.Resources["Storyboard1"] as System.Windows.Media.Animation.Storyboard;
            s.Begin();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            i++;
            if (i>50)
            {
                lbl.Focus();
            }
            Console.WriteLine(IsActive);
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
            }
        }
        #endregion
    }
}

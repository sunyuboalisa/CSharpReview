using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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

namespace WpfInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Window window=null;
            if(window is null)
            {

            }
        }

        public interface IBankAccount
        {
            void PayIn(decimal amount);
            bool Withdraw(decimal amount);
            decimal Balance { get; }
        }

        public interface ITransferBankAccount : IBankAccount
        {
            bool TransferTo(IBankAccount destination,decimal amount);
        }

        public class SaverAccount : IBankAccount
        {
            private decimal _balance;
            public decimal Balance => _balance;

            public void PayIn(decimal amount)
            {
                _balance+=amount;
            }

            public bool Withdraw(decimal amount)
            {
                if (_balance>=amount)
                {
                    _balance -= amount;
                    return true;
                }
                return false;
            }

            public override string ToString()
            {
                return $"{Balance,6:C}";
            }

            WeakReference weakReference = new WeakReference(new object());
            void d()
            {
                if (weakReference.IsAlive)
                {
                    var strongReference = weakReference.Target;
                }
            }
        }
    }
}

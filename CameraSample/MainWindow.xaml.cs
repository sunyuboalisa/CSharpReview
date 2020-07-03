using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CameraSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CameraController cameraController=new CameraController();
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {

            switch (e.Mode)
            {
                case Microsoft.Win32.PowerModes.Resume:
                    break;
                case Microsoft.Win32.PowerModes.StatusChange:
                    break;
                case Microsoft.Win32.PowerModes.Suspend:
                    
                    break;
                default:
                    break;
            }
        }

        private async void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            await cameraController.StartPreviewAsync();
            preview.Source = cameraController.GetCapturePreview();
        }

        private async void btnCddapture_Click(object sender, RoutedEventArgs e)
        {
            await cameraController.CleanupCameraAsync();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
            Microsoft.Win32.SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }

        private async void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case Microsoft.Win32.SessionSwitchReason.ConsoleConnect:
                    break;
                case Microsoft.Win32.SessionSwitchReason.ConsoleDisconnect:
                    break;
                case Microsoft.Win32.SessionSwitchReason.RemoteConnect:
                    break;
                case Microsoft.Win32.SessionSwitchReason.RemoteDisconnect:
                    break;
                case Microsoft.Win32.SessionSwitchReason.SessionLogon:
                    break;
                case Microsoft.Win32.SessionSwitchReason.SessionLogoff:
                    break;
                case Microsoft.Win32.SessionSwitchReason.SessionLock:
                    break;
                case Microsoft.Win32.SessionSwitchReason.SessionUnlock:
                    await cameraController.StartPreviewAsync();
                    preview.Source = cameraController.GetCapturePreview();
                    break;
                case Microsoft.Win32.SessionSwitchReason.SessionRemoteControl:
                    break;
                default:
                    break;
            }
        }
    }
}

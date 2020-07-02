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

        private async void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            await cameraController.StartPreviewAsync();
            preview.Source = cameraController.GetCapturePreview();
            Timer timer = new Timer(para =>
            {
                Debug.WriteLine(cameraController.GetCameraStreamState());
            });
            timer.Change(100, 100);
        }
    }
}

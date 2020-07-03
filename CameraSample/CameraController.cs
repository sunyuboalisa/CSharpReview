using MediaCaptureWPF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Windows.Graphics.Display;
using Windows.Media;
using Windows.Media.Capture;
using Windows.Media.Devices;
using Windows.System.Display;
using Windows.UI.Core;

namespace CameraSample
{
    public class CameraController
    {
        MediaCapture mediaCapture;
        CapturePreview capturePreview;
        DisplayRequest displayRequest=new DisplayRequest();

        bool _isPreviewing;
        public bool IsPreviewing => _isPreviewing;

        public async Task StartPreviewAsync()
        {
            if (IsPreviewing)
            {
                return;
            }
            try
            {
                mediaCapture = new MediaCapture();
                await mediaCapture.InitializeAsync();// there will throw an exception if there no camera device.
                mediaCapture.Failed += MediaCapture_Failed;

                displayRequest.RequestActive();
                DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;
            }
            catch (Exception e)// it will throw exception if there no camera device. 
            {
                await CleanupCameraAsync();
                Debug.WriteLine(e.Message+"++++45");
                return;
            }
            try
            {
                capturePreview = new CapturePreview(mediaCapture);

                //if (mediaCapture.VideoDeviceController.)
                //{
                //    mediaCapture.CaptureDeviceExclusiveControlStatusChanged += MediaCapture_CaptureDeviceExclusiveControlStatusChanged;
                //}
                await capturePreview.StartAsync();// it will raise MediaCapture Failed event when camera is used by other application.

                _isPreviewing = true;
            }
            catch (Exception e)// it will throw exception if camera device is used by other application.
            {
                Debug.WriteLine(e.Message + "+++62");
            }
        }

        private void MediaCapture_Failed(MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs)
        {
            _isPreviewing = false;
            mediaCapture.CaptureDeviceExclusiveControlStatusChanged += MediaCapture_CaptureDeviceExclusiveControlStatusChanged;
        }

        private void MediaCapture_CaptureDeviceExclusiveControlStatusChanged(MediaCapture sender, MediaCaptureDeviceExclusiveControlStatusChangedEventArgs args)
        {
            switch (args.Status)
            {
                case MediaCaptureDeviceExclusiveControlStatus.ExclusiveControlAvailable:
                    break;
                case MediaCaptureDeviceExclusiveControlStatus.SharedReadOnlyAvailable:
                    break;
                default:
                    break;
            }
        }

        public CapturePreview GetCapturePreview()
        {
            return capturePreview;
        }

        public async Task<VideoFrame> GetVideoFrameAsync()
        {
            var ss = await mediaCapture.GetPreviewFrameAsync();
            return ss;
        }
        public async Task CleanupCameraAsync()
        {
            if (mediaCapture != null)
            {
                if (IsPreviewing)
                {
                    await capturePreview.StopAsync();
                }

                await Dispatcher.CurrentDispatcher.InvokeAsync( () =>
                {
                    if (displayRequest != null)
                    {
                        displayRequest.RequestRelease();
                    }

                    mediaCapture.Dispose();
                    mediaCapture = null;
                    _isPreviewing = false;
                });
            }
        }
    }
}

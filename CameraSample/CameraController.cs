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
            try
            {
                mediaCapture = new MediaCapture();
                var s = mediaCapture.CameraStreamState;
                Debug.WriteLine(s);
                await mediaCapture.InitializeAsync();

                displayRequest.RequestActive();
                DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;
            }
            catch (Exception e)// it will throw exception if there no camera device. 
            {
                displayRequest.RequestRelease();
            }

            try
            {
                capturePreview = new CapturePreview(mediaCapture);
                mediaCapture.InitializeAsync();
                //await capturePreview.StartAsync();
                _isPreviewing = true;
                mediaCapture.CaptureDeviceExclusiveControlStatusChanged += MediaCapture_CaptureDeviceExclusiveControlStatusChanged;
            }
            catch (Exception e)// it will throw exception if camera device is used by other application.
            {
               
            }
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
        public CameraStreamState GetCameraStreamState()
        {
            return mediaCapture.CameraStreamState;
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
                });
            }
        }
    }
}

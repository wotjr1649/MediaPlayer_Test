// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture.Frames;
using Windows.Media.Core;
using Windows.Storage;
using Windows.UI.Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MediaPlayer_Test
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public nint hWnd;
        public Windows.UI.Core.CoreDispatcher _disPatcher { get; set; }
        public MainWindow()
        {
            this.InitializeComponent();
            // hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            // var md = new MediaPlayerElement();
            //var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            // WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hWnd);

            var dispatcherQueue = Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread();
            

            if (dispatcherQueue.HasThreadAccess)
            {
                
                var task = dispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
                {
                    mediaPlayer.Source = Windows.Media.Core.MediaSource.CreateFromUri(new Uri("C:\\Users\\User\\Videos\\ADVR\\ADVR_10-28-2022_09-59-53 am.mpg"));

                });
                //
            }
           
            var tasks = dispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Normal, () =>
            {
                Task.Delay(300).Wait();
                mediaPlayer.MediaPlayer.Play();
                Debug.WriteLine(mediaPlayer.MediaPlayer.NaturalDuration);
              

            });

            /*      var task = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                  {
                      mediaPlayer.Source = Windows.Media.Core.MediaSource.CreateFromUri(new Uri("C:\\Users\\User\\Videos\\ADVR\\ADVR_10-28-2022_09-59-53 am.mpg"));
                  });*/

            //_disPatcher = this.CoreWindow.Dispatcher;
            //mediaPlayer.Source = Windows.Media.Core.MediaSource.CreateFromUri(new Uri("C:\\Users\\User\\Videos\\ADVR\\ADVR_10-28-2022_09-59-53 am.mpg"));
            //mediaPlayer.Source = Windows.Media.Core.MediaSource.CreateFromUri(new Uri("C:\\Users\\User\\Videos\\ADVR\\ADVR_10-28-2022_09-59-53 am.mpg"));
            //(Windows.Media.Playback.IMediaPlaybackSource)
            //v();

            //Task.Run(async () => { mediaPlayer.Source = MediaSource.CreateFromStorageFile(await StorageFile.GetFileFromPathAsync("C:\\Users\\User\\Videos\\ADVR\\ADVR_10-28-2022_09-59-53 am.mpg")); }).Wait();
        }

        private async void v()
        {
            Debug.WriteLine(this.CoreWindow.Dispatcher.CurrentPriority);
            
      /*      await CoreApplication.GetCurrentView().CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                Debug.WriteLine("Start");

                //mediaPlayer.Source = MediaSource.CreateFromStorageFile(await StorageFile.GetFileFromPathAsync("C:\\Users\\User\\Videos\\ADVR\\ADVR_10-28-2022_09-59-53 am.mpg"));
                //mediaPlayer.Source = Windows.Media.Core.MediaSource.CreateFromUri(new Uri("C:\\Users\\User\\Videos\\ADVR\\ADVR_10-28-2022_09-59-53 am.mpg"));
                Debug.WriteLine("End");
            });

            Debug.WriteLine("HELLO");*/

/*            await CoreApplication.GetCurrentView().CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,async  () =>
            {
                mediaPlayer.Source = MediaSource.CreateFromStorageFile(await StorageFile.GetFileFromPathAsync("C:\\Users\\User\\Videos\\ADVR\\ADVR_10-28-2022_09-59-53 am.mpg"));
                //Task.Run(async () => { mediaPlayer.Source = MediaSource.CreateFromStorageFile(await StorageFile.GetFileFromPathAsync("C:\\Users\\User\\Videos\\ADVR\\ADVR_10-28-2022_09-59-53 am.mpg")); }).Wait();
                //Debug.WriteLine("HELLO");
                //mediaPlayer.Source = MediaSource.CreateFromStorageFile(await StorageFile.GetFileFromPathAsync("C:\\Users\\User\\Videos\\ADVR\\ADVR_10-28-2022_09-59-53 am.mpg"));
            });*/
    /*        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Debug.WriteLine("HELLO");
                //mediaPlayer.Source = MediaSource.CreateFromStorageFile(await StorageFile.GetFileFromPathAsync("C:\\Users\\User\\Videos\\ADVR\\ADVR_10-28-2022_09-59-53 am.mpg"));
            });*/
/*
            IAsyncAction asyncAction = Windows.System.Threading.ThreadPool.RunAsync((workItem) =>
            {
                if (workItem.Status == AsyncStatus.Canceled)
                    return;

            });

            var a = asyncAction;
            var task =  CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new Windows.UI.Core.DispatchedHandler(() =>
            {
                Debug.WriteLine("HELLO");
            }));*/
        }


    }
}

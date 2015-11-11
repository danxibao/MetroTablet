using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_try.Pictures
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Flower : Page
    {
        //static int flower_pic_cnt = 4;
        bool run = true;
        public Flower()
        {
            this.InitializeComponent();
            //this.AddHandler(FrameworkElement.Loaded, new TappedEventHandler(pageRoot_Tapped), true);
        }

        static void Sleep(int ms)
        {
            new System.Threading.ManualResetEvent(false).WaitOne(ms);
        }

        private void self_Tapped(object sender, TappedRoutedEventArgs e)
        {
        }
         
        protected   void OnTapped(TappedRoutedEventArgs e)
        {
            int i = 0;
        }
         
        //     事件的数据。
        protected   void OnGotFocus(RoutedEventArgs e)
        {

            int i = 0;
        }
          private   void xxxx()
        { 
        }

        // 摘要: 
        //     在 Page 上载后，并且不再是父 Frame 的当前源时立即调用。
        //
        // 参数: 
        //   e:
        //     可以通过重写的代码检查的事件数据。事件数据具有代表性的导航，该导航已卸载当前 Page。
        async void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

            run = true; 
            
        }

        //鼠标进入这个图片，可以实现图片变动
         private void self_Entered(object sender, PointerRoutedEventArgs e)
        {

            run = true;
        }

        private void self_Exited(object sender, PointerRoutedEventArgs e)
        { 
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }


        DispatcherTimer timer = new DispatcherTimer();
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            int i = 0;
            timer.Tick += dispatcherTimer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0,10);
            
            timer.Start();

        }
        async void dispatcherTimer_Tick(object sender, object e)
        {
            //int i = 0;
            //timer.Stop();
            //timer.Interval = new TimeSpan(0, 0, 0, 10);

            try
            {
                var install_home = Package.Current.InstalledLocation;
                var fld = await install_home.GetFolderAsync("Assets\\Images\\Flower\\");
                var fldf = await fld.GetFilesAsync();
                int flower_pic_cnt = fldf.Count;

                var file = await install_home.GetFileAsync(@"serial_port_buf.txt");
                string read = await FileIO.ReadTextAsync(file);
                await file.DeleteAsync();
                string[] ls = read.Split(",".ToCharArray());
                for (int i = 0; i < ls.Length; i++)
                {
                    string c = ls[i];
                    currentFlower.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Flower/" + ((Int16.Parse(c.ToString()) % flower_pic_cnt) + 1) + ".jpg"));
                    //Sleep(1000);
                    await Task.Delay(TimeSpan.FromMilliseconds(2));
                }

                //timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            }
            catch (Exception e00)
            {
                //ignore
            }

        }
        private void Page_Tapped(object sender, TappedRoutedEventArgs e)
        {

            int i = 0;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

            timer.Stop();
        }


    }
}

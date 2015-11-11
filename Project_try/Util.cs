using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Windows.Networking.Connectivity;
using System.Net.Http;
using Windows.UI.Core;
using Windows.Devices;
using Windows.Devices.Usb;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Foundation;

namespace Project_try
{
    class Util
    {
        public 
            async 
            static void Test()
        {
            //access file at home_dir test
            var folder = Package.Current.InstalledLocation;
            var file = await folder.GetFileAsync(@"tmp\usb.txt");
            var read = await FileIO.ReadTextAsync(file);
            int i = 0;




        }

        public static string CurrentIPAddress()
        {
            var icp = NetworkInformation.GetInternetConnectionProfile();

            if (icp != null && icp.NetworkAdapter != null)
            {
                var hostname =
                    NetworkInformation.GetHostNames()
                        .SingleOrDefault(
                            hn =>
                            hn.IPInformation != null && hn.IPInformation.NetworkAdapter != null
                            && hn.IPInformation.NetworkAdapter.NetworkAdapterId
                            == icp.NetworkAdapter.NetworkAdapterId);

                if (hostname != null)
                {
                    // the ip address
                    return hostname.CanonicalName;
                }
            }

            return string.Empty;
        }
         

          public static void  guessServiceIp(){
            string localIp = Util.CurrentIPAddress();
            string serviceIp = null;
            string[] ipx = localIp.Split(new char[] { '.' });
            int x = -1;
            Int32.TryParse(ipx[3], out x);
            string ipPre = ipx[0] + "." + ipx[1] + "." + ipx[2] + ".";
            string service_url = App.service_url_error;

            serviceIp = ipPre + "250";
            service_url = string.Format("http://{0}:8080/bjpmr_service/webservice", serviceIp);
            Config.service_url = App.service_url = service_url;

        }
    }
}

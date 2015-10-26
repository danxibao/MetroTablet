using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.Storage;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Networking;
namespace Project_try
{
    class SerialPortTcpRecv
    {
    }

     public class Client
    {
        async void x()
        {
            const int port = 8000;
            using (HttpServer server = new HttpServer(port))
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        byte[] data = await client.GetByteArrayAsync(
                                      "http://localhost:" + port + "/foo.txt");
                        // do something with 
                    }
                    catch (HttpRequestException)
                    {
                        // possibly a 404
                    }
                }
            }
        }
    }
    public class HttpServer : IDisposable
    {
        private const uint BufferSize = 8192;
        private static readonly StorageFolder LocalFolder
                     = Windows.ApplicationModel.Package.Current.InstalledLocation;

        private readonly StreamSocketListener listener;

        public HttpServer(int port)
        {
            this.listener = new StreamSocketListener();
            this.listener.ConnectionReceived += (s, e) => ProcessRequestAsync(e.Socket);

            HostName host = new HostName("192.168.183.200");
            this.listener.BindEndpointAsync(host, port.ToString());
        }

        public void Dispose()
        {
            this.listener.Dispose();
        }

        private async void ProcessRequestAsync(StreamSocket socket)
        {
            // this works for text only
            StringBuilder request = new StringBuilder();
            using (IInputStream input = socket.InputStream)
            {
                byte[] data = new byte[BufferSize];
                IBuffer buffer = data.AsBuffer();
                uint dataRead = BufferSize;
                while (dataRead == BufferSize)
                {
                    await input.ReadAsync(buffer, BufferSize, InputStreamOptions.Partial);
                    request.Append(Encoding.UTF8.GetString(data, 0, data.Length));
                    dataRead = buffer.Length;
                }
            }

            string req = request.ToString();//收到的数据在req中 
        }
         
    }
}

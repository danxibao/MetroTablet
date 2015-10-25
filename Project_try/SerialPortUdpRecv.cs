using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace Project_try
{
    public class Utility
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

    }
    class SerialPortUdpRecv
    {
        static
            DatagramSocket socket = null;//局部变量;
        public  async void ConnSocket(int max, string content)
        {

            try
            {
                socket = new DatagramSocket();
                if (Utility.IsConnectedToInternet())
                {
                    HostName host = new HostName("localhost");
                    string port = "10000";
                    try
                    {
                        socket.MessageReceived += MessageReceived;
                        await socket.BindServiceNameAsync(port);
                        //await socket.ConnectAsync(host, port);
                        //将发送内容的信息存放进Socket异步事件参数中
                        //DataWriter udpWriter = new DataWriter(socket.OutputStream);
                        //把数据写入到发送流
                        //udpWriter.WriteString(content);
                        //异步发送
                        //await udpWriter.StoreAsync();
                        //异步刷新数据
                        //await udpWriter.FlushAsync();
                        // this.isConnected = true;
                    }
                    catch (Exception exception)
                    {
                        if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown)
                        {
                            socket.Dispose();
                            return;
                        }
                    }
                }
                else
                {
                    //MessageDialog dlg = new MessageDialog("未连接到网络", "友情提示");
                    //await dlg.ShowAsync();
                }
            }
            catch (Exception e)
            {
                string mm = e.ToString();

            }
        }


        async void MessageReceived(DatagramSocket socket, DatagramSocketMessageReceivedEventArgs eventArguments)
        {
            IBuffer buffer;
            try
            {
                IOutputStream outputStream = await socket.GetOutputStreamAsync(eventArguments.RemoteAddress, eventArguments.RemotePort);
                buffer = eventArguments.GetDataReader().DetachBuffer();
                await outputStream.WriteAsync(buffer);

                byte[] bytes = WindowsRuntimeBufferExtensions.ToArray(buffer, 0, (int)buffer.Length);
                string dataFromServer = Encoding.UTF8.GetString(bytes, 0, bytes.Length);//这为UDP返回的数据

                 
            }
            catch (Exception exception)
            {
                SocketErrorStatus socketError = SocketError.GetStatus(exception.HResult);
                if (socketError == SocketErrorStatus.ConnectionResetByPeer)
                {

                }
                else if (socketError != SocketErrorStatus.Unknown)
                {

                }
                else
                {
                }
            }
            finally
            {
                //socket.Dispose();
                //socket = null;
            }
        }
    }
}

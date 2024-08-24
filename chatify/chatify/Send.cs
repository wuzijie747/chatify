using chatify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace send
{
    class Send
    {
        internal static bool chat(int port,string ip,UdpClient udpClient,string content,string id)
        {
            try
            {
                DateTime now = DateTime.Now;
                string message = "chat:" + id + "," + content + "," + now.ToString("yyyy/MM/dd HH:mm:ss");

                byte[] sendData = Encoding.ASCII.GetBytes(message);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                udpClient.Send(sendData, sendData.Length, endPoint);
                Console.WriteLine("Sent: " + message);
            }
            catch
            {
                return false;
            }
            return true;
        }
        internal static bool query(int port, string SERVER_IP, UdpClient udpClient, int EndId)
        {
            try
            {
                // 发送数据
                string message = "query:" + EndId.ToString();


                byte[] sendData = Encoding.ASCII.GetBytes(message);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(SERVER_IP), port);
                udpClient.Send(sendData, sendData.Length, endPoint);
                Console.WriteLine("Sent: " + message);

                // 接收响应
                int num;
                if (EndId <= 15)
                {
                    num = EndId;
                }
                else
                {
                    num = 15;
                }
                for (int i = 1; i <= num; i++)
                {
                    IPEndPoint receiveEndPoint = new IPEndPoint(IPAddress.Any, port);
                    byte[] receiveData = udpClient.Receive(ref receiveEndPoint);
                    string responseMessage = Encoding.ASCII.GetString(receiveData);
                    ReadWrite.Write("123.txt", responseMessage);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (udpClient != null)
                {
                    udpClient.Close();
                }
            }
            return true;
        }
    }
}

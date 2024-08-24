using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms.VisualStyles;
namespace chatify;

public class get
{
    internal static int GetLength(int port,string ip,UdpClient udpClient)
    {
        try
        {
            // 发送数据
            string message = "getLine:";


            byte[] sendData = Encoding.ASCII.GetBytes(message);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            udpClient.Send(sendData, sendData.Length, endPoint);
            Console.WriteLine("Sent: " + message);
            IPEndPoint receiveEndPoint = new IPEndPoint(IPAddress.Any, port);
            byte[] receiveData = udpClient.Receive(ref receiveEndPoint);
            string responseMessage = Encoding.ASCII.GetString(receiveData);
            return int.Parse(responseMessage);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
            return -1;
        }
    }
    internal static void WriteData(int endId,int port,string ip,UdpClient udpClient,int omissions,int needed)
    {
        try
        {
            // 发送数据
            string message = "query:" + endId.ToString();

                    
            byte[] sendData = Encoding.ASCII.GetBytes(message);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            udpClient.Send(sendData, sendData.Length, endPoint);
            Console.WriteLine("Sent: " + message);

            for (int i = 0; i < omissions; i++)
            {
                IPEndPoint receiveEndPoint = new IPEndPoint(IPAddress.Any, port);
                byte[] receiveData = udpClient.Receive(ref receiveEndPoint);
                string responseMessage = Encoding.ASCII.GetString(receiveData);
            }
            for (int i = 0; i < needed; i++)
            {
                IPEndPoint receiveEndPoint = new IPEndPoint(IPAddress.Any, port);
                byte[] receiveData = udpClient.Receive(ref receiveEndPoint);
                string responseMessage = Encoding.ASCII.GetString(receiveData);
                ReadWrite.Write("data.txt", responseMessage);
            }

        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
    }
    internal static bool GetData(int startId, int endId,int port,string ip)
    {
        UdpClient udpClient = new UdpClient();
        
        int start = startId;
        int end = startId;
        /*
          s = 0
          e = 16
          
          e=15
          
         */
        if (endId - startId <= 15)
        {
            int total;
            if (endId <= 15)
            {
                total = endId;
            }
            else
            {
                total = 15;
            }

            WriteData(endId, port, ip, udpClient, total - (endId - startId), endId - startId);
            return true;
        }

        while (true)
        {
            
            if (end+15 < endId)
            {
                WriteData(end+15,port, ip, udpClient, 0, 15);
                end += 15;
                start += 15;
            }
            else if (end+15 == endId)
            {
                WriteData(end+15,port, ip, udpClient, 0, 15);
                break;
            }
            else
            {
                WriteData(endId,port, ip, udpClient,15-(endId-end), endId-end);
                break;
            }
        }
        if (udpClient != null)
        {
            udpClient.Close();
        }
        

        return true;
    }
}
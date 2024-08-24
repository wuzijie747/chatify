package cn.chatify;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.concurrent.Executor;
import java.util.concurrent.Executors;

public class Main {

    static ReadProperties readProperties = new ReadProperties();
    private static final int PORT; // 监听的端口

    static {
        try {
            PORT = Integer.parseInt(readProperties.read("setting.properties","port"));
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static void main(String[] args) {
        SqlOperations sqlOperations = new SqlOperations();
        System.out.println(SqlOperations.getDataNumber("chat.db","Chat_History"));
        DatagramSocket socket = null;
        try {
            // 创建 DatagramSocket 对象并绑定到指定端口
            socket = new DatagramSocket(PORT);
            System.out.println("UDP Server is running on port " + PORT);

            while (true) {
                // 接收数据
                byte[] receiveData = new byte[1024];
                DatagramPacket receivePacket = new DatagramPacket(receiveData, receiveData.length);
                socket.receive(receivePacket);
                System.out.println(123);
                Executor executor = Executors.newVirtualThreadPerTaskExecutor();
                DatagramSocket finalSocket = socket;
                executor.execute(() -> {
                    InetAddress clientAddress = receivePacket.getAddress();
                    int clientPort = receivePacket.getPort();

                    // 打印接收到的数据
                    String receivedMessage = new String(receivePacket.getData(), 0, receivePacket.getLength());
                    System.out.println("Received: " + receivedMessage);

                    DataProcessing dataProcessing = new DataProcessing();
                    dataProcessing.Processing(receivedMessage,clientAddress,clientPort,finalSocket);
                    // 准备响应数据
                    /*
                    String responseMessage = "123";
                    byte[] sendData = responseMessage.getBytes();

                    // 创建并发送响应数据包
                    DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length, clientAddress, clientPort);

                    try {
                        finalSocket.send(sendPacket);
                    } catch (IOException e) {
                        throw new RuntimeException(e);
                    }
                    System.out.println("Sent: " + responseMessage);
                     */
                });
                // 获取发送方的地址和端口

            }

        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (socket != null && !socket.isClosed()) {
                socket.close();
            }
        }
    }
}

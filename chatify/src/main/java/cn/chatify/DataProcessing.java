package cn.chatify;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

public class DataProcessing {
    static boolean Processing(String data, InetAddress clientAddress, int clientPort, DatagramSocket finalSocket) {
            //data = chat:发送id,内容,日期
            if (data.startsWith("chat:")) {
                data = data.substring(5);
                String[] parts = data.split(",");
                SqlOperations sqlOperations = new SqlOperations();
                boolean t=SqlOperations.insertChatHistory("chat.db","Chat_History",Integer.parseInt(parts[0]),parts[1],parts[2]);
                //发送代码
                String responseMessage = String.valueOf(t);
                SqlOperations.sendData(clientAddress, clientPort, finalSocket, responseMessage);
                return t;
            }
            //data = query:数据id
            else if(data.startsWith("query:")) {
                data = data.substring(6);
                SqlOperations sqlOperations = new SqlOperations();
                //发送已经在queryChatHistory方法中实现
                return sqlOperations.queryChatHistory("chat.db","Chat_History",Integer.parseInt(data),clientAddress,clientPort,finalSocket);
            }
            else if (data.startsWith("getLine:")){
                SqlOperations sqlOperations = new SqlOperations();
                String t = Integer.toString(sqlOperations.getDataNumber("chat.db","Chat_History"));
                SqlOperations.sendData(clientAddress,clientPort,finalSocket,t);
                return true;
            }
            else {
                return false;
            }

    }
}

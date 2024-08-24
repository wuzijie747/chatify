package cn.chatify;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.sql.*;

public class SqlOperations {
    static boolean isTableExists(String dbName, String tableName) {
        String url = "jdbc:sqlite:" + dbName;
        try (Connection conn = DriverManager.getConnection(url);
             Statement stmt = conn.createStatement()) {
            ResultSet rs = stmt.executeQuery("SELECT count(*) FROM sqlite_master WHERE type='table' AND name='" + tableName + "';");
            if (rs.next()) {
                int count = rs.getInt(1);
                return count > 0;
            }
        } catch (SQLException e) {
            System.out.println("SQL Error: " + e.getMessage());
        }
        return false;
    }
    static boolean queryChatHistory(String name, String table, int endId, InetAddress clientAddress, int clientPort, DatagramSocket finalSocket) {
        int startId;
        if (endId <= 15) {
            startId = 0;
        }
        else {
            startId = endId-15+1;
        }
        String url = "jdbc:sqlite:" + name;
        String sql = "SELECT content FROM "+table+" WHERE id BETWEEN "+Integer.toString(startId)+" AND "+Integer.toString(endId)+" ORDER BY id ASC;";
        try (Connection conn = DriverManager.getConnection(url);
             PreparedStatement pstmt = conn.prepareStatement(sql);
             ResultSet rs = pstmt.executeQuery()) {
            // 遍历结果集
            while (rs.next()) {
                // 获取context列的值
                String contentData = rs.getString("content");
                System.out.println(contentData);
                sendData(clientAddress, clientPort, finalSocket, contentData);
            }
            return true;
        } catch (SQLException e) {
            System.out.println(e.getMessage());
            return false;
        }
    }

    public static void sendData(InetAddress clientAddress, int clientPort, DatagramSocket finalSocket, String contentData) {
        byte[] sendData = contentData.getBytes();

        DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length, clientAddress, clientPort);
        try {
            finalSocket.send(sendPacket);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        System.out.println("Sent: " + contentData);
    }

    static int getDataNumber(String name,String table) {
        String url = "jdbc:sqlite:" + name;
        String sql = "SELECT COUNT(*) FROM "+table+";";

        try (Connection conn = DriverManager.getConnection(url);
             PreparedStatement pstmt = conn.prepareStatement(sql);
             ResultSet rs = pstmt.executeQuery()) {

            // 获取查询结果
            if (rs.next()) {
                int rowCount = rs.getInt(1); // 因为COUNT(*)只返回一个值，所以使用索引1来获取
                System.out.println("表中的行数: " + rowCount);
                return rowCount;
            }
            return -1;
        } catch (SQLException e) {
            System.out.println(e.getMessage());
            return -1;
        }
    }
    //添加数据
    static boolean insertChatHistory(String name, String table, int id, String content, String time) {
        String url = "jdbc:sqlite:" + name;
        try (Connection conn = DriverManager.getConnection(url)) {
            if (conn != null) {
                System.out.println("Database connection established.");

                // 创建表和插入数据
                String createTableSQL = "CREATE TABLE IF NOT EXISTS "+table+" (" +
                        "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "content TEXT NOT NULL, " +
                        "time TEXT NOT NULL, " +
                        "sendId INTEGER NOT NULL)";
                String insertDataSQL = "INSERT INTO "+table+" (content, time, sendId) VALUES (?, ?, ?);";

                try (Statement stmt = conn.createStatement()) {
                    // 执行创建表SQL
                    if(!isTableExists(name,table)) {
                        stmt.execute(createTableSQL);
                        System.out.println("Table created or already exists.");
                    }



                    // 执行插入数据SQL
                    try (PreparedStatement pstmt = conn.prepareStatement(insertDataSQL)) {

                        // 设置参数值
                        pstmt.setString(1, content); // 设置content参数
                        pstmt.setString(2, time); // 设置time参数
                        pstmt.setInt(3,id); //设置sendId参数

                        // 执行插入操作
                        int affectedRows = pstmt.executeUpdate();
                        System.out.println("Rows affected: " + affectedRows);


                    } catch (SQLException e) {
                        System.out.println(e.getMessage());
                        return false;
                    }
                    System.out.println("Data inserted.");

                }
                return true;
            }
            return false;
        } catch (SQLException e) {
            System.out.println("SQL Error: " + e.getMessage());
            return false;
        }
    }
}

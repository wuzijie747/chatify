package cn.chatify;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

public class ReadProperties {
    public String read(String name,String QueryName) throws IOException {
        InputStream inputStream = this.getClass().getClassLoader().getResourceAsStream(name);
        Properties properties = new Properties();
        properties.load(inputStream);
        return properties.getProperty(QueryName);
    }
}

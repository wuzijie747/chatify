using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
namespace chatify
{
    internal class ReadWrite
    {
        internal static bool Write(string filename, string content)
        {
            string path = filename; // 请替换为你的文件路径
            string tempPath = Path.GetTempFileName(); // 创建临时文件
            string textToAdd = content; // 你要添加到文件末尾的字符串
            int maxLines = 100; // 文件最大行数
            int lineCount = 0; // 当前行数
            if (!File.Exists(path))
            {
                // 文件不存在，创建文件
                try
                {
                    using (FileStream fs = File.Create(path))
                    {
                        // 文件已创建，可以在这里写入内容，如果需要的话
                        // 例如写入一些初始化内容
                        // byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                        // fs.Write(info, 0, info.Length);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            try
            {
                using (StreamReader sr = new StreamReader(path))
                using (StreamWriter sw = new StreamWriter(tempPath))
                {
                    string line;

                    // 逐行读取原文件
                    while ((line = sr.ReadLine()) != null)
                    {
                        // 当行数少于100时，直接写入临时文件
                        if (lineCount < maxLines)
                        {
                            sw.WriteLine(line);
                            lineCount++;
                        }
                        else
                        {
                            // 当行数达到100时，开始丢弃前面的行
                            sw.WriteLine(line);
                            sw.BaseStream.Seek(0, SeekOrigin.Begin); // 回到文件开头
                                                                     // 跳过第一行，即最旧的行
                            sr.ReadLine();
                        }
                    }

                    // 添加新行到文件末尾
                    sw.WriteLine(textToAdd);
                }

                // 替换原文件
                File.Delete(path);
                File.Move(tempPath, path);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(e.Message);
                return false;
            }
        }

    }
}

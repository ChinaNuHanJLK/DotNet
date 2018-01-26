using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFW
{
    class Program
    {
        static void Main(string[] args)
        {

          
        }
    }





    public class Test
    {

        #region 数据类型
        //Enumerable
        //string str;
        //int a = 1;
        //double number;
        //float num;
        //bool flag;
        //DateTime dataTime;
        //Enum eEnum;
        //byte bytes;
        //long numone;
        //short numtwo;
        //sbyte bSbyte;
        //ulong onUlong;
        //decimal dDecimal;
        //char dchar;
        //object obj = null;
        //var result = obj is null;
        //var f = obj as object;
        #endregion

        #region File 类
        //if (File.Exists("D:/2.txt"))
        //{
        //   FileStream fileStream = File.Create("D:/2.txt");

        //   fileStream.Lock(0,fileStream.Length);
        //   StreamWriter sw = new StreamWriter(fileStream);
        //   sw.WriteLine("我是写入\n的字符串");
        //   fileStream.Unlock(0,fileStream.Length);
        //   sw.Flush();
        //}
        #endregion

        #region FileInfo 类

        ////读取文件
        //FileInfo fileInfo = new FileInfo("D:/10.txt");
        ////文件不存在则创建
        //if (!fileInfo.Exists)
        //{
        //    using (fileInfo.Create()) { }
        //}

        //    //写入文件内容
        //    using (StreamWriter streamWriter = fileInfo.AppendText())
        //    {
        //        //要写入的字符串
        //        streamWriter.Write("我是写入的字符串");
        //        //写入流
        //        streamWriter.Flush();
        //    }              
        //    //读取文件内容
        //    StreamReader streamReader = fileInfo.OpenText();
        //    //关闭流
        //    //using 和 Close效果等同 using用完资源之后立马释放
        //    //streamReader.Close();
        //    using (streamReader)
        //    {
        //        //输出文件内容
        //        Console.WriteLine(streamReader.ReadToEnd());
        //        //streamWriter.Close();
        //    }
        #endregion

        #region 转换
        //string 转换成 Char[]
        //string ss = "abcdefg";
        //char[] cc = ss.ToCharArray();
        //Char[] 转换成string

        //string s = new string(cc);
        //byte[] 与 string 之间的转换

        //byte[] bb = Encoding.UTF8.GetBytes(ss);
        //string s = Encoding.UTF8.GetString(bb);
        //byte[] 与 char[] 之间的转换
        //byte[] bb;
        //char[] cc = Encoding.ASCII.GetChars(bb);
        //byte[] bb = Encoding.ASCII.GetBytes(cc);
        #endregion

        #region BinaryWriter 类

        //string path = "D:/10.txt";
        //if (!File.Exists(path))
        //{
        //    using (File.Create(path)) { }

        //}
        //FileStream fs =  File.Open("D:/10.txt", FileMode.Open);
        //BinaryReader br = new BinaryReader(fs,Encoding.Default);
        //char [] cr =  br.ReadChars(int.Parse(fs.Length.ToString()));          
        //string crstr = new string(cr);
        //Console.WriteLine(crstr);
        //BinaryWriter bw = new BinaryWriter(fs,Encoding.Default);
        //string bstr = "我是刚刚写入的";
        ////Encoding.UTF8.GetBytes()
        ////bw.Write();
        //Console.ReadKey();

        #endregion

        #region DriveInfo 类

        //DriveInfo[] allDrives = DriveInfo.GetDrives();

        //foreach (DriveInfo d in allDrives)
        //{
        //    Console.WriteLine("Drive {0}", d.Name);
        //    Console.WriteLine("  Drive type: {0}", d.DriveType);
        //    if (d.IsReady)
        //    {
        //        Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
        //        Console.WriteLine("  File system: {0}", d.DriveFormat);
        //        Console.WriteLine(
        //            "  Available space to current user:{0, 15} bytes",
        //            d.AvailableFreeSpace);

        //        Console.WriteLine(
        //            "  Total available space:          {0, 15} bytes",
        //            d.TotalFreeSpace);

        //        Console.WriteLine(
        //            "  Total size of drive:            {0, 15} bytes ",
        //            d.TotalSize);
        //    }
        //}
        #endregion

        #region FileSystemEventArgs 类  
        //  Create a FileSystemWatcher to monitor all files on drive C.
        //FileSystemWatcher fsw = new FileSystemWatcher("D:\\")
        //{
        //    NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
        //                   | NotifyFilters.FileName | NotifyFilters.DirectoryName
        //};

        ////  Watch for changes in LastAccess and LastWrite times, and
        ////  the renaming of files or directories. 

        ////  Register a handler that gets called when a 
        ////  file is created, changed, or deleted.
        //fsw.Changed += OnChanged;

        //fsw.Created += OnChanged;

        //fsw.Deleted += OnChanged;

        ////  Register a handler that gets called when a file is renamed.
        //fsw.Renamed += OnRenamed;

        ////  Register a handler that gets called if the 
        ////  FileSystemWatcher needs to report an error.
        //fsw.Error += OnError;

        ////  Begin watching.
        //fsw.EnableRaisingEvents = true;

        //Console.WriteLine("Press \'Enter\' to quit the sample.");
        //Console.ReadLine();

        #endregion

        #region MyRegion


        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            //  Show that a file has been created, changed, or deleted.
            WatcherChangeTypes wct = e.ChangeType;
            Console.WriteLine("File {0} {1}", e.FullPath, wct.ToString());
        }


        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            //  Show that a file has been renamed.
            WatcherChangeTypes wct = e.ChangeType;
            Console.WriteLine("File {0} {2} to {1}", e.OldFullPath, e.FullPath, wct.ToString());
        }

        //  This method is called when the FileSystemWatcher detects an error.

        private static void OnError(object source, ErrorEventArgs e)
        {
            //  Show that an error has been detected.
            Console.WriteLine("The FileSystemWatcher has detected an error");
            //  Give more information if the error is due to an internal buffer overflow.
            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                //  This can happen if Windows is reporting many file system events quickly 
                //  and internal buffer of the  FileSystemWatcher is not large enough to handle this
                //  rate of events. The InternalBufferOverflowException error informs the application
                //  that some of the file system events are being lost.
                Console.WriteLine(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
            }
        }

        #endregion
    }
}

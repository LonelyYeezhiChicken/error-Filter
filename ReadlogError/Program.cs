using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadlogError
{
    class Program
    {
        static void Main(string[] args)
        {
            File_Name();
            Console.ReadKey();
        }
        //讀取檔案名稱
        public static void File_Name()
        {
            try
            {
                string[] NameList = Directory.GetFiles("C:\\Users\\Duke\\Desktop\\ERRORLOG\\");

                //分析出路徑中的檔案名稱
                foreach (string AllName in NameList)
                {

                    string Name = Path.GetFileName(AllName);
                    Console.WriteLine(Name);
                    ReadError(Name);
                }
            }
            catch (Exception ex)
            {

            }

        }
        //過濾error
        public static void ReadError(string _filename)
        {

            string path = "C:\\Users\\Duke\\Desktop\\ERRORLOG\\" + _filename;

            using (StreamReader rd = new StreamReader(path))
            {
                string line;
                while ((line = rd.ReadLine()) != null)
                {
                    if (line.StartsWith("ER") || line.Contains("ER"))
                    {
                        Console.WriteLine(line);
                    }

                }
                rd.Close();  //關掉
                             // LogHelper.Info("Item: 列清單模組完成讀取");
            }

        }
    }
}

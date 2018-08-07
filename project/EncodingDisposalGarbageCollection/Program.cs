using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingDisposalGarbageCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "This is Sparta!!!";
            const string Path = @"D:\Dilan Nicolae\15. Encoding Disposal GarbageCollection\EncodingDisposalGarbageCollection\Test.txt";
            const string ListPath = @"D:\Dilan Nicolae\15. Encoding Disposal GarbageCollection\EncodingDisposalGarbageCollection\List.txt";
            const string DatePath = @"D:\Dilan Nicolae\15. Encoding Disposal GarbageCollection\EncodingDisposalGarbageCollection\DateTime.txt";


            Encoding encoder = Encoding.Default;
            byte[] outStream = encoder.GetBytes(text);          

            

            using (FileStream fs = File.Create(Path))
            {
                fs.Write(outStream, 0, outStream.Length);
            }


            var list=new Dictionary<string,int>();

            var aux = File.ReadLines(ListPath);
            aux.ToList();

            foreach (var item in aux)
            {
                var s=item.Split(' ');
                 list.Add(s[0],Convert.ToInt32(s[1]));
            }

            

           // var composite = "Num.of order: {0}  Name: {1} Grade: {2}";

            //list.ForEach(Console.WriteLine);
           

            //int i = 0;
            //foreach (var item in sortedList)
            //{

            //    Console.WriteLine(string.Format(composite,++i,item.Key,item.Value));

            //}
            
            var sortedList = from entry in list orderby entry.Value descending select entry;

            sortedList.ToDictionary(t => t.Key);
            

            Salary salary = new Salary(sortedList.ToDictionary(t => t.Key,t=>t.Value));
            salary.Dispose();

            CultureInfo culture = CultureInfo.GetCultureInfo("ja");



            DateTime dateTime;
#if DEBUG
            dateTime = DateTime.Parse("2011/11/11").t;






            // byte[] dateBytes = encoder.GetBytes(dateTime.ToFileTimeUtc().ToString());

            using (FileStream fs = File.Create(DatePath))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(dateTime);
            }
#endif
#if !DEBUG

           
            dateTime= DateTime.Parse(File.ReadAllText(DatePath));
            Console.WriteLine(dateTime.ToLocalTime());
            
#endif

            Console.ReadKey();
        }
    }
}

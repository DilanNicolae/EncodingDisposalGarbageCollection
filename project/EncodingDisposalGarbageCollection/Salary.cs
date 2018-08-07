using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingDisposalGarbageCollection
{
    class Salary:IDisposable
    {
        private List<int> Salaries  = new List<int>();
        private Dictionary<string, int> list;
        const string Path = @"D:\Dilan Nicolae\15. Encoding Disposal GarbageCollection\EncodingDisposalGarbageCollection\Salary.txt";
        private FileStream fs;

        ~Salary()
        {

            Console.WriteLine($"I am a finalizer! {1}");
            fs.Dispose();
        }
        public Salary(Dictionary<string, int> list)
        {
            this.list = list;
            var rnd = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                var randomNumber = rnd.Next(100, 1001);
                Salaries.Add(randomNumber);

            }
            Salaries = Salaries.OrderByDescending(x => x).ToList();

            Write();
            
        }


        private void Write()
        {
            int i = 0;
            fs = File.Create(Path);
            

            foreach (var item in list)
            {
                byte[] bytes = Encoding.Default.GetBytes($"{item.Key} {item.Value} {Salaries[i++]}  \n");
                fs.Write(bytes,0, bytes.Length);

            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            ((IDisposable)fs).Dispose();
        }
    }
}

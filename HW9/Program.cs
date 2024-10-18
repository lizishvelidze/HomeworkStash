using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HW9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NewFileWorker newWorker = new NewFileWorker();
            newWorker.MaxStorage = 128;
            newWorker.Write();
            newWorker.Read();
            newWorker.Edit();
            newWorker.Delete();
        }
    }
    public abstract class FileWorker
    {
        public int MaxStorage { get; set; }

        public abstract void Write();
        public abstract void Read();
        public abstract void Edit();
        public abstract void Delete();
    }
    public class NewFileWorker : FileWorker
    {
        public override void Delete()
        {
            Console.WriteLine($"I can delete from txt file with max storage {MaxStorage}");
        }

        public override void Edit()
        {
            Console.WriteLine($"I can edit from txt file with max storage {MaxStorage}");
        }

        public override void Read()
        {
            Console.WriteLine($"I can read from txt file with max storage {MaxStorage}");
        }

        public override void Write()
        {
            Console.WriteLine($"I can write from txt file with max storage {MaxStorage}");
        }
    }
}
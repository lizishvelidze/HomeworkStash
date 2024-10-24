using System;

namespace Homework11
{
    using System;
    using static Homework11.Strategy;
    using System.IO;

    namespace HW11
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                PerformTasks();
            }

            static void PerformTasks()
            {
                Task1();
                Task2();
                Task3();
                Task4();
            }

            static void Task1()
            {
                Client client = new Client(new ModernFurnitureFactory());
                client.Run();

                client = new Client(new VictorianFurnitureFactory());
                client.Run();

                client = new Client(new ArtDecoFurnitureFactory());
                client.Run();
            }

            static void Task2()
            {
                Actor actorProxy = new ActorProxy();
                actorProxy.Act();

                RealActor realActor = new RealActor();
                realActor.Act();
            }

            static void Task3() 
            {
                Facade facade = new Facade();
                facade.OperationHTML();
                facade.OperationPDF();
            }

            static void Task4() 
            {
                string[] files = { "something.zip", "random.json", "some.txt" };

                foreach (var file in files)
                {
                    IFileHandler handler = FileHandlerFactory.GetFileHandler(Path.GetExtension(file));
                    handler.HandleFile(file);
                }
            }
        }
    }
}


      
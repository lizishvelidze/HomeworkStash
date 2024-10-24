using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11
{
    internal class Client
    {
        private IFurnitureFactory factory;

            public Client(IFurnitureFactory factory)
            {
                this.factory = factory;
            }

            public void Run()
            {
                var chair = factory.CreateChair();
                var sofa = factory.CreateSofa();
                Console.WriteLine($"Client: I've got a {chair.GetType().Name} and a {sofa.GetType().Name}");
            }
        }

        interface IFurnitureFactory
        {
            IChair CreateChair();
            ISofa CreateSofa();
        }

        class ModernFurnitureFactory : IFurnitureFactory
        {
            public IChair CreateChair() => new ModernChair();
            public ISofa CreateSofa() => new ModernSofa();
        }

        class VictorianFurnitureFactory : IFurnitureFactory
        {
            public IChair CreateChair() => new VictorianChair();
            public ISofa CreateSofa() => new VictorianSofa();
        }

        class ArtDecoFurnitureFactory : IFurnitureFactory
        {
            public IChair CreateChair() => new ArtDecoChair();
            public ISofa CreateSofa() => new ArtDecoSofa();
        }
  
        interface IChair { }
        class ModernChair : IChair { }
        class VictorianChair : IChair { }
        class ArtDecoChair : IChair { }

        interface ISofa { }
        class ModernSofa : ISofa { }
        class VictorianSofa : ISofa { }
        class ArtDecoSofa : ISofa { }
    }
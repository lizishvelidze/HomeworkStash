using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11
{ 
        abstract class Actor
        {
            public abstract void Act();
        }

        class RealActor : Actor
        {
            public override void Act()
            {
                Console.WriteLine("Actor is performing a simple scene");
            }
        }

        class ActorProxy : Actor
        {
            private Cascadeur cascadeur;

            public override void Act()
            {
                if (DangerousScene())
                {
                    cascadeur = new Cascadeur();
                    cascadeur.Act();
                    cascadeur.PerformDangerousAct();
                }
                else
                {
                    RealActor realActor = new RealActor();
                    realActor.Act();
                }
            }

            private bool DangerousScene()
            {
                return new Random().Next(0, 2) == 0;
            }

            class Cascadeur
            {
                public void Act()
                {
                    Console.WriteLine("Cascadeur is performing a stunt");
                }

                public void PerformDangerousAct()
                {
                    Console.WriteLine("Cascadeur is performing a dangerous stunt");
                }
            }
        }
    }


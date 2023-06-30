using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model.LabNadoknada
{
    class Program
    {
        static void Main(string[] args)
        {
            Shipwright ships = new Shipwright(10, 10);
            Fleet fleet;            
            Gunner g = new Gunner(10, 10, new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });            
            Square target;
            int miss = 0;
            for (int i=0;i<10000; ++i) {
                fleet = ships.CreateFleet(new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
                while (true) {
                    target = g.NextTarget();                    
                    if (fleet.Hit(target) == HitResult.Hit)
                        break;
                    ++miss;
                }                
            }
            Console.WriteLine(miss/ 10000.0);

            g = new Gunner(10, 10, new int[] { 1 });
            miss = 0;
            for (int i = 0; i < 10000; ++i)
            {
                fleet = ships.CreateFleet(new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
                while (true)
                {
                    target = g.NextTarget();                    
                    if (fleet.Hit(target) == HitResult.Hit)
                        break;
                    ++miss;
                }
            }
            Console.WriteLine(miss / 10000.0);
        }
    }
}

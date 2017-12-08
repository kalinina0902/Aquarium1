using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Aquarium_task3._10_
{
    class CreatorFish:CreatorDweller
    {
        public override Dweller Create(Random rnd, IStrategy s,Graphics g,int x,int y)
        {
            
            return new Fish(rnd, s,g,x,y);
        }
    }
}

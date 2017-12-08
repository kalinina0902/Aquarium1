using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Aquarium_task3._10_
{
    abstract class CreatorDweller
    {
        public abstract Dweller Create(Random rnd, IStrategy s,Graphics g,int x,int y);
    }
}

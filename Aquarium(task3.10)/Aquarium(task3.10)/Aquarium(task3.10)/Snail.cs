using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Aquarium_task3._10_
{
    class Snail : Dweller
    {
        public Snail(Random rnd, IStrategy s)
        {
            Satiety = 10;
            X = rnd.Next(0, 100);
            Y = rnd.Next(10, 150);
            TX = rnd.Next(80, 1400);
            TY = rnd.Next(630, 700);
            s = new SnailStrategy();
            Pictureliife = new Rectangle(X, Y + 50, 150, 10);
            /*  private int satiety;
              public int Satiety { get { return satiety; } set { satiety = value; } }
              private string kind;
              public string Kind { get { return kind; } set { kind = value; } }
              public void Create() { }*/
        }
    }
}

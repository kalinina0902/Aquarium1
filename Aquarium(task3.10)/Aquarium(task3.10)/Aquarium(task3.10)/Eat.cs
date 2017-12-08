using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium_task3._10_
{
    public class Eat
    {
        public List<Crumb> Korm { get; private set; } = new List<Crumb>();
        public class Crumb
        {
            public Crumb(int x, int y) 
            {
                this.x = x;
                this.y = y;
                this.flag = false;
            }
            public int x;
            public int y;
            public bool flag;

            public void Sink()
            {
                if (y <= 642)
                y += 5;
                
                
            }
        }


        Random rnd = new Random();
        public Eat(int x, int y)
        {
            for (int i = 0; i < 3; i++)
            {
                Korm.Add(new Crumb(rnd.Next(x - 30, x + 30), rnd.Next(y, y + 20)));
            }
        }


    }
}

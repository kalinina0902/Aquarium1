using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium_task3._10_
{
    class SnailStrategy:IStrategy
    {
        public void Move(Dweller f, List<Eat> plant)
        {
            if (IsHungry(f))
            {
                Eating(f, plant);
            }
            int dx = f.TX - f.X;

            int stepX = 1;
            if (Math.Abs(dx) > 2)
            {
                if (dx < 0)
                    f.X -= stepX;
                else
                {
                    f.X += stepX;
                    f.turn = true;
                }
            }
            f.Pictureliife.X = f.X;

        }
        public bool IsHungry(Dweller f)
        {
            if (f.Satiety < 30) { return true; }
            return false;
        }
        public bool IsDeath(Dweller f)
        {
            if (f.Satiety == 0) { return true; }
            return false;
        }
        public void Death(Dweller f)
        {
            /*if (IsDeath(f))
            {

            }*/
        }
        public void Eating(Dweller f, List<Eat> plant)
        {
            double min = 5000;
            int indexI = -1;
            int indj = -1;
            double distance;
            foreach (Eat ea in plant)
                for (int j = 0; j < plant.Count; j++)
                    for (int k = 0; k < ea.Korm.Count; k++)
                    {
                        distance = f.X - ea.Korm.ElementAt(k).x;
                        if (distance < min)
                        {
                            min = distance;
                            indexI = k;
                            indj = j;
                        }
                    }
            if (min <= 20)
            {
                plant[indj].Korm.RemoveAt(indexI);
                f.Satiety += 15;
                return;
            }
            int dx = f.X - plant[indj].Korm[indexI].x;
            int dy = f.Y - plant[indj].Korm[indexI].y;
            int stepX = 10;
            int stepY = 2;

            if (dx < 0)
            {
                f.X += stepX;
            }
            else if (dx == 0)
            {
                f.X += 0;
            }
            else
            {
                f.X -= stepX;
            }

            if (dy < 0)
            {
                f.Y += stepY;
            }
            else if (dy == 0)
            {
                f.Y += 0;
            }
            else
            {
                f.Y -= stepY;
            }
            f.Pictureliife.X = f.X;
            f.Pictureliife.Y = f.Y;

        }
        public void Reproduction()
        {
         //   Snail a = new Snail(1,);
        }
    }
   
}

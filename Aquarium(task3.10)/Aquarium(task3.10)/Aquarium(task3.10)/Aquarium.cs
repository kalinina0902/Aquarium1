using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium_task3._10_
{

    public class Aquarium
    {
        public List<Dweller> AllFish = new List<Dweller>();
        public List<Dweller> AllSnail = new List<Dweller>();
        public List<Eat> Feed { get; private set; } = new List<Eat>();
        private int temper;
        public int Temper { get; set; }
        public bool Light { get; set; }
        //CreatorDweller creator;
        //private int light;
        //private Fish[] fish;
        //private Fry[] fry;
        //private Snail[] snail;
        public void AddFish(Dweller fish)
        {
            AllFish.Add(fish);
        }
        public void AddSnail(Dweller snail)
        {
            AllSnail.Add(snail);
        }
        /* public Aquarium(int t)
         {

             temper = t;
             //light = l;

         }
        /* public void StartGame()
         {
             Random rnd=new Random();
             creator = new CreatorFish();
             IStrategy s;
             for (int i = 0; i < fish.Length; i++)
             {
                 Dweller f = creator.Create(rnd, s);
                 fish[i] = f;
                 f.Draw();
             }
             creator = new CreatorSnail();
             IStrategy s1;
             for (int i = 0; i < snail.Length; i++)
             {
                 Dweller sn = creator.Create(rnd, s1);
             }



         }*/
         public void MinesSatiety()
        {
            for(int i = 0; i < AllFish.Count(); i++)
            {
                if (AllFish[i].Satiety!=0)
                    AllFish[i].Satiety--;
            }
            
        }
        public void CreateFood(int x, int y)
        {
            Feed.Add(new Eat(x, y));
        }

        public void FallFood()
        {
            foreach (Eat ea in Feed)
                foreach (Eat.Crumb kr in ea.Korm)
                    kr.Sink();
        }
        public void RemoveFood()
        {
            for (int i = 0; i < Feed.Count(); i++)
            {   for (int j = 0; j < Feed[i].Korm.Count(); j++)
                {
                    if (Feed[i].Korm[j].y >= 641)
                    {
                        Feed[i].Korm.RemoveAt(j);
                    }
                }
            }
        }
        public void IsHungry()
        {
            for (int i = 0; i < AllFish.Count; i++)
            {
                if (AllFish[i].Satiety < 45)
                {
                    AllFish[i].s.Eating(AllFish[i], Feed);
                }
            }
        }
        public void Move()
        {

            if (AllFish.Count != 0)
            {
                for (int i = 0; i < AllFish.Count; i++)
                {
                    if (AllFish[i].Satiety == 0)
                    {
                        AllFish[i].s.Death(AllFish[i]);
                        if (AllFish[i].die)
                        {
                            AllFish.RemoveAt(i);
                        }
                    }
                    else
                    {
                        
                        if (Math.Abs(AllFish[i].TX - AllFish[i].X) < 5 || Math.Abs(AllFish[i].TY - AllFish[i].Y) < 3)
                        {
                            AllFish[i].SetPoint();
                        }

                        AllFish[i].s.Move(AllFish[i], Feed);
                    }

                }
            }
        }
        
    }
}

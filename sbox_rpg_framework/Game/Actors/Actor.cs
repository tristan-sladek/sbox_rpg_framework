using System;
using System.Collections.Generic;
using System.Text;
using sbox_rpg_framework.Game.Jobs;

namespace sbox_rpg_framework.Game.Actors
{
    public class Actor
    {
        public bool isPlayer = false;
        public Actor(int level)
        {
            if (level < 1) level = 1;
            debug_LoadBaseActor();
            for(int i = 1; i < level; i++)
            {
                LevelUp();
            }
        }
        public void debug_LoadBaseActor()
        {//Creates a debug LVL 1 human
            LVL = 1;
            Job = new Squire();
            Stats = new Stats();
            Stats.SaveStats.HP = 32;
            Stats.SaveStats.MP = 15;
            Stats.SaveStats.SP = 6;
            Stats.SaveStats.PA = 5;
            Stats.SaveStats.MA = 4;
            Stats.Init(this);
            Name = "Generic Actor";
        }
        public void LevelUp()
        {
            LVL += 1;
            Stats.LevelUp(this);
        }
        public int CT { get; set; }
        public int XP { get; set; }
        public int LVL { get; set; }
        public String Name { get; set; }
        public Stats Stats { get; set; }
        public Job Job { get; set; }
        public void Tick()
        {
            if (IsAlive())
            {
                CT += Stats.SP;
                if (CT > 100) CT = 100;
            }            
        }
        public void PostTick()
        {
            while(XP >= 100)
            {
                LevelUp();
                XP -= 100;
            }
        }
        public bool IsAlive()
        {
            return Stats.CurHP > 0;
        }
        public bool IsTurn()
        {
            return CT >= 100;
        }
        override public String ToString()
        {
            return Name + " - " +
                Job.Name + " - " +
                "LVL " + LVL + " " +
                "[" + Stats.CurHP + "/" + Stats.HP + "] " +
                "[" + Stats.CurMP + "/" + Stats.MP + "] " +
                "[" + CT + "/100] " +
                Stats.SP + " " +
                Stats.PA + " " +
                Stats.MA
                ;
        }
        public void PrintStatus()
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Stats.CurHP + "/" + Stats.HP);

            if (isPlayer)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" " + Stats.CurMP + "/" + Stats.MP);
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" " + CT + "/" + 100);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("]");
            Console.ResetColor();
        }
    }
}

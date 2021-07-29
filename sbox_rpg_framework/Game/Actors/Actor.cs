using System;
using System.Collections.Generic;
using System.Text;
using sbox_rpg_framework.Game.Jobs;

namespace sbox_rpg_framework.Game.Actors
{
    public class Actor
    {
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
        public void debug_LevelUp()
        {
            LVL += 1;
            Stats.LevelUp(this);
        }
        public int XP { get; set; }
        public int LVL { get; set; }
        public String Name { get; set; }
        public Stats Stats { get; set; }
        public Job Job { get; set; }

        override public String ToString()
        {
            return Name + " - " +
                Job.Name + " - " +
                "LVL " + LVL + " " +
                "[" + Stats.CurHP + "/" + Stats.HP + "] " +
                "[" + Stats.CurMP + "/" + Stats.MP + "] " +
                Stats.SP + " " +
                Stats.PA + " " +
                Stats.MA
                ;
        }
    }
}

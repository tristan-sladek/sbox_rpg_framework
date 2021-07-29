using System;
using System.Collections.Generic;
using System.Text;

namespace sbox_rpg_framework.Game.Actors
{
    public class Stats // All things statistical
    {
        public Stats()
        {
            SaveStats = new StatValues();
            HardStats = new StatValues();
            SoftStats = new StatValues();
        }
        public StatValues SaveStats { get; set; } // Persistant Raw Values; Saved between battles
        public StatValues HardStats { get; set; } // Determined before battle; base values for stats
        public StatValues SoftStats { get; set; } // In Combat Modifiers (CurStat = BaseStat + SoftStat) ~ Can be negative
        
        // TODO: Passives
        // TODO: Effects

        public int CurHP { get; set; } // Current Health Points (distinct because SoftStat would modify MaxHP)
        public int CurMP { get; set; } // Current Mana Points (distinct because SoftStat would modify MaxMP)

        // Battle Adjusted Stat Returns
        public int HP => HardStats.HP + SoftStats.HP;
        public int MP => HardStats.MP + SoftStats.MP;
        public int SP => HardStats.SP + SoftStats.SP;
        public int PA => HardStats.PA + SoftStats.PA;
        public int MA => HardStats.MA + SoftStats.MA;

        public void Init(Actor actor)
        {
            LoadHardStats(actor);
            LoadSoftStats(actor);
            CurHP = HardStats.HP;
            CurMP = HardStats.MP;
        }
        public void LoadHardStats(Actor actor) {
            //TODO add effect calculations
            //TODO add equipment load

            //Hard Stats:
            //Load Actor's Job Stats ~ apply job multipliers 
            HardStats.HP = (int)Math.Ceiling((Decimal)SaveStats.HP * actor.Job.HPM / 100);
            HardStats.MP = (int)Math.Ceiling((Decimal)SaveStats.MP * actor.Job.MPM / 100);
            HardStats.SP = (int)Math.Ceiling((Decimal)SaveStats.SP * actor.Job.SPM / 100);
            HardStats.PA = (int)Math.Ceiling((Decimal)SaveStats.PA * actor.Job.PAM / 100);
            HardStats.MA = (int)Math.Ceiling((Decimal)SaveStats.MA * actor.Job.MAM / 100);
        }
        public void LoadSoftStats(Actor actor)
        {
            SoftStats = new StatValues(); //Soft Stat Reset            
            //TODO: add more if soft stats are affected by buffs.. ect.
        }
        public void LevelUp(Actor actor)
        {
            SaveStats.HP += (int)Math.Ceiling((Decimal)SaveStats.HP / (actor.Job.HPC + actor.LVL));
            SaveStats.MP += (int)Math.Ceiling((Decimal)SaveStats.MP / (actor.Job.MPC + actor.LVL));
            SaveStats.SP += (int)Math.Ceiling((Decimal)SaveStats.SP / (actor.Job.SPC + actor.LVL));
            SaveStats.PA += (int)Math.Ceiling((Decimal)SaveStats.PA / (actor.Job.PAC + actor.LVL));
            SaveStats.MA += (int)Math.Ceiling((Decimal)SaveStats.MA / (actor.Job.MAC + actor.LVL));
            LoadHardStats(actor); //reload hard stats
        }
    }
    public class StatValues 
    {
        public int HP { get; set; } // Max Health Points
        public int MP { get; set; } // Max Mana Points
        public int SP { get; set; } // Speed (initiative)         
        public int PA { get; set; } // Physical Attack
        public int MA { get; set; } // Magic Attack

        //Attributes
        // public int BR { get; set; } // Bravery (Physical Scale)
        // public int FA { get; set; } // Faith  (Magical Scale)
    }
}

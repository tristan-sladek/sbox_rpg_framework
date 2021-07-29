using sbox_rpg_framework.Game.Actors;
using System;
using sbox_rpg_framework.Game;

namespace sbox_rpg_framework
{
    class Program
    {
        static void Main(string[] args)
        {
            Actor player = new Actor(1);
            player.Stats.SoftStats.HP = 6;
            player.Stats.SoftStats.PA = 4;
            player.Stats.SoftStats.SP = 2;

            player.isPlayer = true;
            player.Name = "Player";

            CombatHandler combat = new CombatHandler();
            combat.party1.Add(player);
            Actor enemy = new Actor(player.LVL + new Random().Next(-1, 1));
            enemy.Name = "Enemy";
            combat.party2.Add(enemy);
            
            combat.Init();
            while (combat.active)
            {
                combat.Update();
            }





            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n");
        }
    }
}

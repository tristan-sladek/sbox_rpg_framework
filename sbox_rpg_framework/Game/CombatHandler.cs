using System;
using System.Collections.Generic;
using System.Text;
using sbox_rpg_framework.Game.Actors;

namespace sbox_rpg_framework.Game
{
    public class CombatHandler
    {
        public bool active = true;
        public List<Actor> party1 = new List<Actor>();
        public List<Actor> party2 = new List<Actor>();
        public List<Actor> allActors = new List<Actor>(); //used for initiative
        public void Init()
        {
            foreach (Actor a in party1) allActors.Add(a);
            foreach (Actor a in party2) allActors.Add(a);
        }
        public void Update()
        {
            foreach(Actor a in allActors)
            {
                a.Tick();
                if (a.IsTurn() && a.IsAlive())
                    ProcessTurn(a);
                a.PostTick();
            }
            bool dead = true;
            foreach(Actor a in party1)            
                if (a.IsAlive())
                    dead = false;
            if (dead)
                active = false;
            dead = true;
            foreach (Actor a in party2)
                if (a.IsAlive())
                    dead = false;
            if (dead)
                active = false;
        }
        public void ProcessTurn(Actor a)
        {
            if (a.isPlayer)
            {
                bool turn = true;
                while (turn)
                {
                    Console.Write("Enter Command:");
                    String command = Console.ReadLine();
                    switch (command)
                    {
                        case "a":
                            AttackRandom(a, party2);
                            turn = false;
                            break;                        
                        default:
                            //Console.WriteLine("Invalid Command!");
                            AttackRandom(a, party2);
                            turn = false;
                            break;
                    }
                }
            }
            else
            {
                AttackRandom(a,party1);
            }
        }
        public void AttackRandom(Actor caster, List<Actor> party)
        {
            Actor target = party[new Random().Next(0, party.Count - 1)];
            //Hard Coded Combat Attack
            int damage = caster.Stats.PA + new Random().Next(-3, 3);
            target.Stats.CurHP -= damage;
            
            Console.Write(target.Name + " Took ");
            WriteC(damage, ConsoleColor.Red);
            Console.Write(" Damage. ");
            if(target.IsAlive())
                target.PrintStatus();
            else
            {
                Console.WriteLine(target.Name + " is slain!");
                caster.XP += 20;
            }
            
            caster.CT = 0;
        }        

        //I got tired of writing these
        void WriteC(Object T, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(T);
            Console.ResetColor();
        }
    }
}

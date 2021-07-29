using sbox_rpg_framework.Game.Actors;
using System;

namespace sbox_rpg_framework
{
    class Program
    {
        static void Main(string[] args)
        {
            Actor actor = new Actor();
            actor.debug_LoadBaseActor();
            Console.WriteLine(actor.ToString());

            for(int i = 1; i < 10; i++)
            {
                actor.debug_LevelUp();
                Console.WriteLine(actor.ToString());
            }
            


            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n");
        }
    }
}

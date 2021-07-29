using System;
using System.Collections.Generic;
using System.Text;
using sbox_rpg_framework.Game.Actors;

namespace sbox_rpg_framework.Game.Items.Weapons
{
    class Sword : Weapon
    {
        public int GetDamage(Actor actor)
        {
            return 1;
        }
    }
}

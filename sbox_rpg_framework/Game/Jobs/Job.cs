using System;
using System.Collections.Generic;
using System.Text;

namespace sbox_rpg_framework.Game.Jobs
{
    public class Job
    {
        public String Name { get; set; }
        // Stat Multipliers (BaseStat = RawStat * StatMult)
        public int HPM { get; set; }
        public int MPM { get; set; }
        public int SPM { get; set; }
        public int PAM { get; set; }
        public int MAM { get; set; }

        // Leveling Constants (LVLBonus_X = CurRaw_X / ( C_X + LVL ) ) ~ LVL is current level, not next level ; X = stat
        public int HPC { get; set; }
        public int MPC { get; set; }
        public int SPC { get; set; }
        public int PAC { get; set; }
        public int MAC { get; set; }
    }
}

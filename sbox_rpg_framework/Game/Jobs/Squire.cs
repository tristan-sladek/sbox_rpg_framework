using System;
using System.Collections.Generic;
using System.Text;

namespace sbox_rpg_framework.Game.Jobs
{
    public class Squire : Job
    {
        public Squire()
        {
            HPM = 100;
            MPM = 75;
            SPM = 100;
            PAM = 90;
            MAM = 80;
            HPC = 11;
            MPC = 15;
            SPC = 100;
            PAC = 60;
            MAC = 50;
            Name = "Squire";
        }
    }
}

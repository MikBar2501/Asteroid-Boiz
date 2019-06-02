using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    namespace Command
    {
        public class Wait : VirtualCommand
        {
            float seconds = 5;
            
            public Wait(float seconds)
            {
                this.seconds = seconds;
            }

            public override void Execute()
            {
                base.Execute();
                Timer.WaitForSeconds(5, Finish);
            }
        }
    }
}

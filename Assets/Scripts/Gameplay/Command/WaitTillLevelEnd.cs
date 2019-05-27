using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Command
{
    public class WaitTillLevelEnd : VirtualCommand
    {
        public override void Execute()
        {
            GameManager.instance.onBeginLevel += Finish;
        }
    }
}

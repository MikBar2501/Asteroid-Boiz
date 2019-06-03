using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Command
{
    public class WaitTillLevelEnd : VirtualCommand
    {
        public override void Execute()
        {
            base.Execute();
            GameManager.instance.onBeginLevel += Finish;
            GameManager.instance.SetState(State.lookForLevelFinish);
        }

        protected override void OnFinish()
        {
            GameManager.instance.onBeginLevel -= Finish;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    namespace Command
    {
        public class VirtualCommand
        {
            public virtual void Execute()
            {

            }

            public void Finish()
            {
                OnFinish();
                CommandsManager.instance.NextCommand();
            }

            protected virtual void OnFinish()
            {

            }
        }
    }
}

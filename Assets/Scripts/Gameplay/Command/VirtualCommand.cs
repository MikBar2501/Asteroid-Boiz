using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    namespace Command
    {
        public class VirtualCommand
        {
            public delegate void FinishDel();
            public FinishDel finish;

            public VirtualCommand SetFinish(FinishDel finish)
            {
                this.finish = finish;
                return this;
            }

            public virtual void Execute()
            {
                if (finish == null)
                    finish = CommandsManager.instance.NextCommand;
            }

            public void Finish()
            {
                OnFinish();
                finish?.Invoke();
            }

            protected virtual void OnFinish()
            {
                
            }
        }
    }
}

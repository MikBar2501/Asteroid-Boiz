using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Command
{
    public class CompositeCommand : VirtualCommand
    {
        public List<VirtualCommand> commands;
        int iterator;

        public CompositeCommand(params VirtualCommand [] commands)
        {
            this.commands = new List<VirtualCommand>();
            foreach(VirtualCommand com in commands)
            {
                com.SetFinish(Next);
                this.commands.Add(com);
            }
        }

        public override void Execute()
        {
            base.Execute();
            iterator = 0;
            Next();
        }

        void Next()
        {
            //Debug.Log("it - " + iterator);

            if (iterator >= commands.Count)
            {
                Finish();
                return;
            }

            VirtualCommand com = commands[iterator];
            //commands.RemoveAt(0);
            iterator++;
            com.Execute();

        }
    }
}

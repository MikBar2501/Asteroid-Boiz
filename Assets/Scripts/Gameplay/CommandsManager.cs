using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    using Command;

    public class CommandsManager
    {
        public static CommandsManager instance;

        AbstractDesigner gameplayDesigner;

        public CommandsManager(AbstractDesigner gameplayDesigner)
        {
            instance = this;
            this.gameplayDesigner = gameplayDesigner;
        }

        public void NextCommand()
        {
            VirtualCommand command = gameplayDesigner.GetNextCommand();
            if (command == null)
                return;

            command.Execute();
        }
    }
}

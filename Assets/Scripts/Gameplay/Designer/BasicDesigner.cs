using System.Collections;
using System.Collections.Generic;
using Gameplay.Command;
using UnityEngine;
using Generator.Strategy.Unleash;
using Generator.Strategy.Pleacment;
using ObjectsCreator;

namespace Gameplay
{
    using Command;

    public class BasicDesigner : AbstractDesigner
    {
        List<VirtualCommand> commands;

        public BasicDesigner()
        {
            commands = new List<VirtualCommand>();

            VirtualCommand timer = new Command.Wait(5);

            PleacmentStrategy pleacment = new ScreenTopStrategy();
            UnleashStrategy unleash = new InstantUnleash();
            AbstractObjectsCreator objectsCreator = new ResourcesObjectsCreator(0);

            VirtualCommand spawn = new Command.ObjectsGeneratorCommand(objectsCreator, pleacment, unleash, 5);

            for (int i = 0; i < 3; i++)
            {
                commands.Add(spawn);
                commands.Add(timer);
            }

        }

        public override VirtualCommand GetNextCommand()
        {
            if (commands.Count == 0)
                return null;

            VirtualCommand command = commands[0];
            commands.RemoveAt(0);

            return command;
        }
    }
}
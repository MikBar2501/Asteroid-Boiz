﻿using System.Collections;
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

            VirtualCommand timer = new Command.Wait(5);
            VirtualCommand levelEnd = new Command.WaitTillLevelEnd();

            PleacmentStrategy pleacment = new RandomAroundScreen().Set(1, 0.5f, true, true, true, true);
            PleacmentStrategy pleacment2 = new RandomAroundScreen().Set(2, 0.5f, true, true, true, true);
            UnleashStrategy unleash = new UnleashOverTime().SetOverTime(2, 0.1f);
            AbstractObjectsCreator objectsCreator = new AsteroidObjectsCreator(1);

            VirtualCommand spawn = new Command.ObjectsGeneratorCommand(objectsCreator, pleacment, unleash, 10);
            VirtualCommand spawn2 = new Command.ObjectsGeneratorCommand(objectsCreator, pleacment2, unleash, 10);

            commands = new List<VirtualCommand>();

            VirtualCommand round = new CompositeCommand(spawn, timer, spawn2, levelEnd);

            for (int i = 0; i < 10; i++)
            {
                commands.Add(round);
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
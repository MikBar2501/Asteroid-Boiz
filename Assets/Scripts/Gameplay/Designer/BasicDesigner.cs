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

        public BasicDesigner() //może jakieś losowe generowanie rund, ktore bedzie coraz trudniejsze
        {
            //dopisz coś co encapsuluje commendy tak zeby mozna ich bylo uzyc jako jednej komendy - wzorzec kompisite. 
            //Potem bedziesz mial takie paczki, ktore beda losowane przez designer

            VirtualCommand timer = new Command.Wait(5);
            VirtualCommand levelEnd = new Command.WaitTillLevelEnd();

            PleacmentStrategy pleacment = new RandomAroundScreen().Set(1, 0.5f);
            PleacmentStrategy pleacment2 = new RandomAroundScreen().Set(2, 0.5f);
            UnleashStrategy unleash = new UnleashOverTime().Set(2, 3);
            AbstractObjectsCreator objectsCreator = new ResourcesObjectsCreator(0);

            VirtualCommand spawn = new Command.ObjectsGeneratorCommand(objectsCreator, pleacment, unleash, 10);
            VirtualCommand spawn2 = new Command.ObjectsGeneratorCommand(objectsCreator, pleacment2, unleash, 10);

            commands = new List<VirtualCommand>();

            for (int i = 0; i < 10; i++)
            {
                commands.Add(spawn);
                commands.Add(timer);
                commands.Add(spawn2);
                commands.Add(levelEnd);
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
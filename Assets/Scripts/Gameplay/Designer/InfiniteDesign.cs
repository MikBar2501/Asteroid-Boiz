using System.Collections;
using System.Collections.Generic;
using Gameplay.Command;
using UnityEngine;
using Generator.Strategy.Unleash;
using Generator.Strategy.Pleacment;
using ObjectsCreator;

namespace Gameplay
{
    public class InfiniteDesign : AbstractDesigner
    {
        int round;
        int waves;

        ObjectsGeneratorCommand[] generatorCommands;
        VirtualCommand timer;
        VirtualCommand levelEnd;

        public InfiniteDesign()
        {
            round = 0;
            waves = 1;

            generatorCommands = new ObjectsGeneratorCommand[2];

            timer = new Command.Wait(10);
            levelEnd = new Command.WaitTillLevelEnd();

            PleacmentStrategy pleacment = new RandomAroundScreen().Set(0f, 0.5f);
            UnleashStrategy unleashOneByOne = new UnleashOverTime().Set(1, 1f);
            UnleashStrategy unleashInstant = new InstantUnleash();
            AbstractObjectsCreator objectsCreator = new AsteroidObjectsCreator(1);

            generatorCommands[0] = new Command.ObjectsGeneratorCommand(objectsCreator, pleacment, unleashInstant, 5);
            generatorCommands[1] = new Command.ObjectsGeneratorCommand(objectsCreator, pleacment, unleashOneByOne, 7);
        }

        public override VirtualCommand GetNextCommand()
        {
            round++;

            if (round % 3 == 0)
                waves++;

            if((round) % 9 == 0)
                foreach( ObjectsGeneratorCommand com in generatorCommands)
                {
                    com.objectsNum += 3;
                }

            List<VirtualCommand> commands = new List<VirtualCommand>();

            for(int i = 0; i < waves; i++)
            {
                commands.Add(generatorCommands[Random.Range(0, generatorCommands.Length)]);
                if(i < waves - 1)
                {
                    commands.Add(timer);
                }
            }

            commands.Add(levelEnd);

            return new CompositeCommand(commands.ToArray());
        }
    }
}

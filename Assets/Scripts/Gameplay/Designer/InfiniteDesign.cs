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

        float[] asteroidsChances;
        AsteroidObjectsCreator objectsCreator;
        UnleashOverTime unleashOneByOne;

        public InfiniteDesign()
        {
            round = 0;
            waves = 1;

            timer = new Command.Wait(10);
            levelEnd = new Command.WaitTillLevelEnd();

            float outScreenOffset = 0.75f;
            PleacmentStrategy pleacment = new RandomAroundScreen().Set(outScreenOffset, 0.5f, true, true, true, true);

            float notRandSpacing = 2f;
            PleacmentStrategy notRandPleacment1 = new NotRandomAroundScreen().Set(outScreenOffset, notRandSpacing, true, false, false, false);
            PleacmentStrategy notRandPleacment2 = new NotRandomAroundScreen().Set(outScreenOffset, notRandSpacing, false, true, false, false);
            PleacmentStrategy notRandPleacment3 = new NotRandomAroundScreen().Set(outScreenOffset, notRandSpacing / 2, false, false, true, false);
            PleacmentStrategy notRandPleacment4 = new NotRandomAroundScreen().Set(outScreenOffset, notRandSpacing / 2, false, false, false, true);
            PleacmentStrategy notRandPleacment = new PleacmentComposite(notRandPleacment1, notRandPleacment2, notRandPleacment3, notRandPleacment4);

            unleashOneByOne = new UnleashOverTime()
                .SetOverTime(1, 3f)
                .SetAsteroidSpeed(1.4f) as UnleashOverTime;

            UnleashStrategy unleashInstant = new InstantUnleash()
                .SetAsteroidSpeed(0.7f);
            UnleashStrategy unleashWave = new UnleashWave()
                .SetOverTime(1, 1)
                .SetAsteroidSpeed(1.2f);

            objectsCreator = new AsteroidObjectsCreator(1);

            generatorCommands = new ObjectsGeneratorCommand[3];
            generatorCommands[0] = new Command.ObjectsGeneratorCommand(objectsCreator, pleacment, unleashInstant, 5);
            generatorCommands[1] = new Command.ObjectsGeneratorCommand(objectsCreator, pleacment, unleashOneByOne, 8);
            generatorCommands[2] = new Command.ObjectsGeneratorCommand(objectsCreator, notRandPleacment, unleashWave, 8);

            asteroidsChances = new float[] { 5, 0, 0 };
        }

        public override VirtualCommand GetNextCommand()
        {
            round++;

            //if (round % 2 == 0)
            {
                if (round <= 6)
                {
                    asteroidsChances[1] += 0.5f;
                }
                else
                {
                    asteroidsChances[1] += 0.2f;
                    asteroidsChances[2] += 0.5f;
                }
            }

            objectsCreator.ResetChances(asteroidsChances);

            if (round % 3 == 0)
            {
                unleashOneByOne.SetOverTime(Random.Range(1, 4), Random.Range(0.5f, 2.5f));
                waves++;
            }

            if((round) % 6 == 0)
                foreach( ObjectsGeneratorCommand com in generatorCommands)
                {
                    com.objectsNum += 1;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Generator;
using Generator.Strategy.Pleacment;
using Generator.Strategy.Unleash;
using ObjectsCreator;

namespace Gameplay.Command
{
    public class ObjectsGeneratorCommand : VirtualCommand
    {
        public PleacmentStrategy pleacment;
        public UnleashStrategy unleash;
        public AbstractObjectsCreator objectsCreator;
        public int objectsNum;

        public ObjectsGeneratorCommand(AbstractObjectsCreator objectsCreator, PleacmentStrategy pleacment, UnleashStrategy unleash, int objectsNum)
        {
            this.objectsCreator = objectsCreator;
            this.pleacment = pleacment;
            this.unleash = unleash;
            this.objectsNum = objectsNum;
        }

        public override void Execute()
        {
            ObjectsGenerator.Generate(this);
            Finish();
        }
    }
}

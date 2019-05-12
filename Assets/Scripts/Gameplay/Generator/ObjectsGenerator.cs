using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Gameplay.Command;
namespace Generator
{
    using Strategy.Pleacment;
    using Strategy.Unleash;

    public static class ObjectsGenerator
    {
        public static void Generate(ObjectsGeneratorCommand command)
        {
            GameObject[] objects = new GameObject[command.objectsNum];
            for (int i = 0; i < command.objectsNum; i++)
            {
                GameObject obj = command.objectsCreator.Create();
                obj.SetActive(false);
                objects[i] = obj;
            }

            command.pleacment.Arrange(objects);
            command.unleash.Unleash(objects);
        }
    }
}

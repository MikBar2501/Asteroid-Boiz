using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Pleacment
{
    public class PleacmentComposite : PleacmentStrategy
    {
        PleacmentStrategy[] pleacmentStrategies;

        public PleacmentComposite(params PleacmentStrategy[] pleacmentStrategies)
        {
            this.pleacmentStrategies = pleacmentStrategies;
        }

        public override void Arrange(GameObject[] objects)
        {
            pleacmentStrategies[Random.Range(0, pleacmentStrategies.Length)].Arrange(objects);
        }
    }
}

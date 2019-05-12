using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Pleacment
{
    public abstract class PleacmentStrategy
    {
        public abstract void Arrange(GameObject[] objects);
    }
}

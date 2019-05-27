using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Unleash
{
    public abstract class UnleashStrategy
    {
        public abstract void Unleash(GameObject[] objects);
    }
}

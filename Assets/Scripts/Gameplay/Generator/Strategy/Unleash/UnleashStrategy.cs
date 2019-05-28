using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Gameplay.Command;

namespace Generator.Strategy.Unleash
{
    public abstract class UnleashStrategy
    {
        public abstract float HowLongWillYouTake();

        public abstract void Unleash(GameObject[] objects);
    }
}

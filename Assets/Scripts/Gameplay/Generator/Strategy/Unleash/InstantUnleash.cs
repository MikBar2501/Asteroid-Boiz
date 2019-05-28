using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Unleash
{
    public class InstantUnleash : UnleashStrategy
    {
        public override float HowLongWillYouTake()
        {
            return 0;
        }

        public override void Unleash(GameObject[] objects)
        {
            foreach (GameObject obj in objects)
                obj.SetActive(true);
        }
    }
}


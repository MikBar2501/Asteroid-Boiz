using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Unleash
{
    public class InstantUnleash : UnleashStrategy
    {
        public override void Unleash(GameObject[] objects)
        {
            foreach (GameObject obj in objects)
                obj.SetActive(true);
        }
    }
}


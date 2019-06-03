using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Unleash
{
    public class InstantUnleash : AsteroidsUnleash
    {
        public override float HowLongWillYouTake()
        {
            return 0;
        }

        public override void Unleash(GameObject[] objects)
        {
            base.Unleash(objects);
            foreach (GameObject obj in objects)
            {
                obj.SetActive(true);
                obj.GetComponent<MovableObject>().SetDirection((-obj.transform.position).normalized);
            }
        }
    }
}


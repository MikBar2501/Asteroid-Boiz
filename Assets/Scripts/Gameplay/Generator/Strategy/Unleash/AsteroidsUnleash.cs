using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Unleash
{
    public class AsteroidsUnleash : UnleashStrategy
    {
        protected float asteroidSpeed = 0.6f;

        public UnleashStrategy SetAsteroidSpeed(float speed)
        {
            this.asteroidSpeed = speed;
            return this;
        }

        public override void Unleash(GameObject[] objects)
        {
            foreach(GameObject obj in objects)
            {
                MovableObject mObj = obj.GetComponent<MovableObject>();
                mObj.speed = asteroidSpeed;
            }
        }

        public override float HowLongWillYouTake()
        {
            return 0;
        }
    }
}

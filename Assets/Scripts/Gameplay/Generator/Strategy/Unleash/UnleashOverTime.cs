using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Unleash
{
    public class UnleashOverTime : AsteroidsUnleash
    {
        int atOnceNum = 1;
        float delay = 0.5f;

        int iterator = 0;

        GameObject[] objects;

        public UnleashOverTime SetOverTime(int atOnceNum, float delay)
        {
            this.atOnceNum = atOnceNum;
            this.delay = delay;

            return this;
        }

        public override float HowLongWillYouTake()
        {
            return ((objects.Length / atOnceNum) - 1) * delay;
        }

        public override void Unleash(GameObject[] objects)
        {
            base.Unleash(objects);
            iterator = 0;
            this.objects = objects;
            UnleashGroup();
        }

        void UnleashGroup()
        {
            for(int i = 0; i < atOnceNum; i++)
            {
                if(objects.Length > iterator)
                {
                    objects[iterator].SetActive(true);
                    MovableObject mObj = objects[iterator].GetComponent<MovableObject>();
                    mObj.SetDirection(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0));
                }
                else
                {
                    
                    return;
                }

                iterator++;
            }

            Timer.WaitForSeconds(delay, UnleashGroup);
        }
    }
}

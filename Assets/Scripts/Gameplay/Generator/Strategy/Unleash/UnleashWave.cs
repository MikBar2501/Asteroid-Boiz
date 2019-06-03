using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Unleash
{
    public class UnleashWave : UnleashOverTime
    {
        public override void Unleash(GameObject[] objects)
        {
            setDirections = false;
            base.Unleash(objects);

            foreach(GameObject obj in objects)
            {
                MovableObject mObj = obj.GetComponent<MovableObject>();
                if (mObj.transform.position.y > Area.instance.screenTop)
                {
                    mObj.SetDirection(new Vector3(0, -1));
                }
                else if (mObj.transform.position.y < Area.instance.screenBottom)
                {
                    mObj.SetDirection(new Vector3(0, 1));
                }
                else if (mObj.transform.position.x > Area.instance.screenRight)
                {
                    mObj.SetDirection(new Vector3(-1, 0));
                }
                else if (mObj.transform.position.x < Area.instance.screenLeft)
                {
                    mObj.SetDirection(new Vector3(-1, 0));
                }
            }
        }
    }
}

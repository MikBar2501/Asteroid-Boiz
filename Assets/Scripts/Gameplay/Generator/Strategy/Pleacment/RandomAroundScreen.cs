using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Pleacment
{
    public class RandomAroundScreen : AroundScreenStrategy
    {
        public override void Arrange(GameObject[] objects)
        {
            base.Arrange(objects);

            for(int i = 0; i < objects.Length; i++)
            {
                GameObject obj = objects[i];
                Vector3 position = Vector3.zero;

                //Debug.Log(i % 4);

                switch (i%4)
                {
                    case 0:
                        position = topSpots[Random.Range(0, topSpots.Count)];
                        break;

                    case 1:
                        position = bottomSpots[Random.Range(0, bottomSpots.Count)];
                        break;

                    case 2:
                        position = rightSpots[Random.Range(0, rightSpots.Count)];
                        break;

                    case 3:
                        position = leftSpots[Random.Range(0, leftSpots.Count)];
                        break;
                }

                obj.transform.position = position;
            }
        }
    }
}

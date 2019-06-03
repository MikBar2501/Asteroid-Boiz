using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Pleacment
{
    public class NotRandomAroundScreen : AroundScreenStrategy
    {
        public override void Arrange(GameObject[] objects)
        {
            base.Arrange(objects);

            for (int i = 0; i < objects.Length; i++)
            {
                GameObject obj = objects[i];
                //Debug.Log(i % 4);

                int offset = 0;
                //if(i < topSpots.Count)
                //{
                if (i >= topSpots.Count)
                {
                    offset += topSpots.Count;

                    if (i >= offset + bottomSpots.Count)
                    {
                        offset += bottomSpots.Count;

                        if (i >= offset + rightSpots.Count)
                        {
                            offset += rightSpots.Count;

                            if (i >= offset + leftSpots.Count)
                                return;

                            obj.transform.position = leftSpots[i - offset];
                            continue;
                        }

                        obj.transform.position = rightSpots[i - offset];
                        continue;
                    }

                    obj.transform.position = bottomSpots[i - offset];
                    continue;
                }

                obj.transform.position = topSpots[i];
                continue;
                // }


            }
        }
    }
}

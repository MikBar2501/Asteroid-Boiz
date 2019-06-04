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

            int backOffset = 0;
            for (int i = 0; i < objects.Length; i++)
            {
                GameObject obj = objects[i];
                //Debug.Log(i % 4);

                int offset = 0;
                //if(i < topSpots.Count)
                //{
                if (i - backOffset >= topSpots.Count )
                {
                    offset += topSpots.Count;

                    if (i - backOffset >= offset + bottomSpots.Count)
                    {
                        offset += bottomSpots.Count;

                        if (i - backOffset >= offset + rightSpots.Count)
                        {
                            offset += rightSpots.Count;

                            if (i - backOffset >= offset + leftSpots.Count)
                            {
                                backOffset += offset + leftSpots.Count;
                                i--;
                                continue;
                            }


                            obj.transform.position = leftSpots[i - offset - backOffset];
                            continue;
                        }

                        obj.transform.position = rightSpots[i - offset - backOffset];
                        continue;
                    }

                    obj.transform.position = bottomSpots[i - offset - backOffset];
                    continue;
                }

                obj.transform.position = topSpots[i - backOffset];
                continue;
                // }


            }
        }
    }
}

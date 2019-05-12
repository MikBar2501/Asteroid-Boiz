using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Pleacment
{
    public class ScreenTopStrategy : ScreenBasedStrategy
    {
        public override void Arrange(GameObject[] objects)
        {
            base.Arrange(objects);
            foreach(GameObject obj in objects)
            {
                if (obj != null)
                {
                    obj.transform.position = new Vector2(
                        Random.Range(area.screenLeft, area.screenRight),
                        Random.Range(area.screenBottom, area.screenTop));
                }
            }
        }
    }
}
    

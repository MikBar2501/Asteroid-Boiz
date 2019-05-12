using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Pleacment
{
    public class ScreenBasedStrategy : PleacmentStrategy
    {
        protected Area area;
        public override void Arrange(GameObject[] objects)
        {
            area = Area.instance;
        }
    }
}

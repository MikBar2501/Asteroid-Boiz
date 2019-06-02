using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Action
{
    public class ActionDestroyAsteroid : AbstractAction
    {
        public override void Action(MovableObject obj)
        {
            obj.Death();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Action
{
    public class ActionDestroy : AbstractAction
    {
        public override void Action(MovableObject obj)
        {
            obj.Death();
        }
    }
}

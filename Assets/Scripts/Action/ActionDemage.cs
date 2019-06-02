using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Action
{
    public class ActionDemage : AbstractAction
    {
        int dmg;

        public ActionDemage Set(int dmg)
        {
            this.dmg = dmg;
            return this;
        }

        public override void Action(MovableObject obj)
        {
            obj.Demage(dmg);
        }
    }
}

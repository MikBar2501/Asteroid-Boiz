using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    using Command;

    public abstract class AbstractDesigner
    {
        public abstract VirtualCommand GetNextCommand();
    }
}

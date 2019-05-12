using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectsCreator
{
    public class PrefabObjectsCreator : AbstractObjectsCreator
    {
        protected GameObject prefab;

        public PrefabObjectsCreator(GameObject prefab)
        {
            this.prefab = prefab;
        }

        public override GameObject Create()
        {
            return MonoBehaviour.Instantiate(prefab);
        }
    }
}

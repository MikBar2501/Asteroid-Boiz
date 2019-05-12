using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectsCreator
{
    public class ResourcesObjectsCreator : PrefabObjectsCreator
    {
        protected int ID;

        public ResourcesObjectsCreator(int ID) : base(null)
        {
            this.ID = ID;
            prefab = GetPrefab();
        }

        protected GameObject GetPrefab()
        {
            return GetPrefab(ID);
        }

        protected GameObject GetPrefab(int ID)
        {
            Spawnable[] spawnables = Resources.LoadAll<Spawnable>("");

            foreach (Spawnable spawnable in spawnables)
            {
                if (spawnable.ID == ID)
                    return spawnable.gameObject;
            }

            return null;
        }

    }
}

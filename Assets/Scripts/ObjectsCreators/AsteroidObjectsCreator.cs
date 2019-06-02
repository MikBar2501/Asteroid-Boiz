using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectsCreator
{
    public class AsteroidObjectsCreator : ResourcesObjectsCreator
    {
        ChancesNormalized rand;

        public AsteroidObjectsCreator(params float[] chances) : base(0)
        {
            rand = new ChancesNormalized(chances);
        }

        public override GameObject Create()
        {
            int id = rand.GetNextID();

            GameObject obj = base.Create();
            //obj. //przypisz liczbe
            return obj;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectsCreator;

namespace UI
{
    public class HealthUI : MonoBehaviour
    {
        ResourcesObjectsCreator healthCreator;

        private void Awake()
        {
            healthCreator = new ResourcesObjectsCreator(3);
        }

        public void SetHealth(int health)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < health - 1; i++)
            {
                GameObject obj = healthCreator.Create();
                obj.transform.parent = transform;
                obj.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}

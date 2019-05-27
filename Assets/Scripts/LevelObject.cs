using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.AddLevelObject(gameObject);
    }

    private void OnDestroy()
    {       
        GameManager.instance.Invoke("CheckForLevelEnd", 0.5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruction : MonoBehaviour
{
    public float delay;

    private void Start()
    {
        Invoke("DestroyIt", delay);
        GetComponent<AudioSource>().pitch = Random.Range(0.6f, 1.4f); //tego  tu nie powinno byc ale jest juz za pozno, za pozno
    }

    void DestroyIt()
    {
        Destroy(gameObject);
    }
}

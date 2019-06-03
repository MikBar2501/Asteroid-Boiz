using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public int shakes = 3;
    public float range = 1;
    public float speed = 8;
    public float sharpness = 0.1f;

    Vector3 basePose;

    private void Awake()
    {
        basePose = transform.position;
    }

    public void ShakeIt()
    {
        StopAllCoroutines();
        StartCoroutine(IShake());
    }

    IEnumerator IShake()
    {
        for(int i = 0; i < shakes; i++)
        {
            Vector3 target = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), transform.position.z).normalized * range;

            while(Vector2.Distance(transform.position, target) > sharpness)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                yield return null;
            }

            while (Vector2.Distance(transform.position, basePose) > sharpness)
            {
                transform.position = Vector3.MoveTowards(transform.position, basePose, speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}

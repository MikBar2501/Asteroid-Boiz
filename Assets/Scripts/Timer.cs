using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public delegate void OnFinish();

    static int ID = 0;

    public static void WaitForSeconds(float seconds, OnFinish onFinish)
    {
        GameObject gameObject = new GameObject();
        gameObject.name = "Timer" + ID++;
        Timer timer = gameObject.AddComponent<Timer>();
        timer.StartCoroutine(timer.WaitForSecondsIE(seconds, onFinish));
    }

    IEnumerator WaitForSecondsIE(float seconds, OnFinish onFinish)
    {
        yield return new WaitForSeconds(seconds);
        onFinish();
        Destroy(gameObject);
    }
    
}

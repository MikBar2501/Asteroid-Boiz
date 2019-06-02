using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{

    public static Area instance;

    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

    void Awake() {
        instance = this;
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        screenTop = stageDimensions.y;
        screenBottom = -stageDimensions.y;
        screenRight = stageDimensions.x;
        screenLeft = -stageDimensions.x;
    }
}

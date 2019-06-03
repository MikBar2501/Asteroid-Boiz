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
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, Camera.main.pixelWidth));

        screenTop = Mathf.Abs(stageDimensions.y);
        screenBottom = -Mathf.Abs(stageDimensions.y);
        screenRight = Mathf.Abs(stageDimensions.x);
        screenLeft = -Mathf.Abs(stageDimensions.x);
    }
}

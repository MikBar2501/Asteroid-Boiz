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

    void Start()
    {
        
    }

    void Awake() {
        instance = this;

        float screenHeight = transform.localScale.y / 2;
        float screenWidth = transform.localScale.x / 2;

        screenTop = screenHeight;
        screenBottom = -screenHeight;
        screenRight = screenWidth;
        screenLeft = -screenWidth;
    }
}

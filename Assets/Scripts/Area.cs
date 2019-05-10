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

        float screenHeight = Screen.height / 2;
        float screenWidth = Screen.width / 2;

        screenTop = screenHeight;
        screenBottom = -screenHeight;
        screenRight = screenWidth;
        screenLeft = -screenWidth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<Object>().SetTeleportation(true);
        Debug.Log("Coś koliduje");
    }

    public void OnTriggerExit2D(Collider2D other) {
        other.GetComponent<Object>().SetTeleportation(true);
    }
}

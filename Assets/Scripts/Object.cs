using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Object : MonoBehaviour
{
    public int health;
    public bool isTeleporting;

    public float speed;

    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    public Sprite sprite;
    Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }


    virtual public void Death() {
        Destroy(gameObject);
    }

    virtual public void Teleportation() {
        Vector3 newPos = transform.position;
        if(transform.position.y > screenTop) {
            newPos.y = screenBottom;
        }

        if(transform.position.y < screenBottom) {
            newPos.y = screenTop;
        }

        if(transform.position.x > screenRight) {
            newPos.x = screenLeft;
        }

        if(transform.position.x < screenLeft) {
            newPos.x = screenRight;
        }
        transform.position = newPos;
        SetTeleportation(false);
    }

    virtual public void Move() {
        transform.position += transform.up * speed;
    }

    virtual public void Rotation(float direction) {
        transform.Rotate(new Vector3(0,0,5f) * -direction, Space.World);
    }

    virtual public void SetTeleportation(bool teleportation) {
        isTeleporting = teleportation;
    }
}

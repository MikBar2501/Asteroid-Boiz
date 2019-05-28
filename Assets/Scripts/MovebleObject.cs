﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MovableObject : MonoBehaviour
{
    public int health;

    public float speed;
    public float angle;
    public Sprite sprite;
    Rigidbody2D rb;
    //protected Vector3 moveVector;
    protected Vector3 directionVector;

    virtual public void Initialize() {
        if(sprite != null) {
            GetComponent<SpriteRenderer>().sprite = sprite;
        }

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        //moveVector = transform.up * speed;
    }

    virtual protected void Start() {
        Initialize();
    }

    virtual public void Update()
    {
        //directionVector = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
        //float angle = Input.GetAxis("Horizontal");

        //if(Input.GetAxis("Vertical") > 0) {
        Move();
        //} 
        Rotation(angle);
        Teleportation();
        LookAt();

        if(health == 0) {
            Death();
        }

        
    }

    virtual public void Death() {
        Destroy(gameObject);
    }

    virtual public void Teleportation() {
        Vector3 newPos = transform.position;
        if(transform.position.y > Area.instance.screenTop) {
            newPos.y = Area.instance.screenBottom;
        }

        if(transform.position.y < Area.instance.screenBottom) {
            newPos.y = Area.instance.screenTop;
        }

        if(transform.position.x > Area.instance.screenRight) {
            newPos.x = Area.instance.screenLeft;
        }

        if(transform.position.x < Area.instance.screenLeft) {
            newPos.x = Area.instance.screenRight;
        }
        transform.position = newPos;
    }

    virtual public void Move() {
        //moveVector = transform.up * speed;
        //transform.position += moveVector;
        transform.position += directionVector.normalized * speed * Time.deltaTime;
        Debug.Log("Speed: " + speed);
    }

    virtual public void Rotation(float direction) {
        transform.Rotate(new Vector3(0,0,5f) * -direction, Space.World);
    }

    virtual public void LookAt() {
        Vector3 diff = (transform.position + directionVector) - transform.position;
        diff.Normalize();

        float rotZ = Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f, rotZ - 90);
    }
}
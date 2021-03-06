﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Action;

public enum ObjType
{
    Player,
    Asteroid,
    Bullet
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public abstract class MovableObject : MonoBehaviour
{
    public int health = 1;

    public float speed;
    public float angle;
    public Sprite sprite;
    protected Rigidbody2D rb;
    //protected Vector3 moveVector;
    protected Vector3 directionVector;

    public ObjType type;
    protected Dictionary<ObjType, AbstractAction> collisionActions;

    float teleportationOffset = 0.7f;
    public AudioClip mySound;
    public AudioSource audioSource;

    public virtual void SetDirection(Vector3 dir)
    {
        directionVector = dir;
    }

    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    protected virtual void ImplementCollisions()
    {
        collisionActions = new Dictionary<ObjType, AbstractAction>();
    }

    virtual public void Initialize() {
        if(sprite != null) {
            GetComponent<SpriteRenderer>().sprite = sprite;
        }

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        ImplementCollisions();
        audioSource = GetComponent<AudioSource>();
        //moveVector = transform.up * speed;
    }

    void Start() {
        Initialize();
    }

    virtual public void Update()
    {
        Move();
        Teleportation();           
    }

    virtual public void Demage(int dmg = 1)
    {
        PlaySound();
        health -= dmg;
        if (health <= 0)
            Death();
    }

    virtual public void Death() {
        Destroy(gameObject);
    }

    virtual public void Teleportation() {
        Vector3 newPos = transform.position;
        if(transform.position.y > Area.instance.screenTop + teleportationOffset) {
            newPos.y = Area.instance.screenBottom - teleportationOffset;
        }

        if(transform.position.y < Area.instance.screenBottom - teleportationOffset) {
            newPos.y = Area.instance.screenTop + teleportationOffset;
        }

        if(transform.position.x > Area.instance.screenRight + teleportationOffset) {
            newPos.x = Area.instance.screenLeft - teleportationOffset;
        }

        if(transform.position.x < Area.instance.screenLeft - teleportationOffset) {
            newPos.x = Area.instance.screenRight + teleportationOffset;
        }
        transform.position = newPos;
    }

    virtual public void Move() {
        //moveVector = transform.up * speed;
        //transform.position += moveVector;
        transform.position += directionVector.normalized * speed * Time.deltaTime;
       // Debug.Log("Speed: " + speed);
    }

    virtual public void Rotation(float direction) {
        transform.Rotate(new Vector3(0,0,5f) * -direction * Time.deltaTime, Space.World);
    }

    public void LookAt() {
        Vector3 diff = (transform.position + directionVector) - transform.position;
        diff.Normalize();

        float rotZ = Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f, rotZ - 90);
    }

    public void Collide(ObjType type)
    {
        AbstractAction action;
        if(collisionActions.TryGetValue(type, out action))
        {
            action.Action(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovableObject obj = collision.GetComponent<MovableObject>();
        if (obj != null)
        {
            Collide(obj.type);
        }
    }

    virtual public void PlaySound() {
        if(mySound == null) return;

        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(mySound);
    }
}

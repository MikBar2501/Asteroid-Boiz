using System.Collections;
using System.Collections.Generic;
using Action;
using UnityEngine;
using ObjectsCreator;

public class Player : MovableObject
{

    public Vector3 dirVec;
    ResourcesObjectsCreator objectsCreator;

    public Sprite ship;
    public Sprite shipMed;
    public Sprite shipFull;
    private SpriteRenderer sprRenderer;

    private float fireRate = 0.5f;
    private float lastShot = 0.0f;

    public UI.HealthUI healthUI;

    #region altMove
    //public float thrust;
    private float thrustForce = 5;
    private float zeroDrag = 0;
    private float breakSpeed = 1;
    //public float turnThrust;
    private float thrustInput;
    private float turnInput;
    private float turnMultiply = 5;
    private float maxSpeed = 2; //to limit max force
    #endregion altMove

    public override void Initialize()
    {
        base.Initialize();
        base.directionVector = dirVec;

        sprRenderer = GetComponent<SpriteRenderer>();
        sprRenderer.sprite = ship;
        objectsCreator = new ResourcesObjectsCreator(1);

        healthUI.SetHealth(health);
    }

    public override void Move()
    {
        altMove();
    }

    public override void Demage(int dmg = 1)
    {
        base.Demage(dmg);
        healthUI.SetHealth(health);
        Camera.main.SendMessage("ShakeIt");
    }

    public override void Death()
    {
        base.Death();
        UI.UIManager.instance.DeathSequence();
    }

    public void basicMove()
    {

        if (Input.GetButtonDown("Fire1"))
        { //zmienilbym na Jump -> spacja zamiast myszki
            Action();
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            base.directionVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            dirVec = base.directionVector;
            transform.position += directionVector.normalized * speed * Time.deltaTime;
        }


    }

    public void altMove()
    {
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        if (Input.GetButton("Fire3"))
        { //left shift
            rb.drag = breakSpeed;
        }
        if (Input.GetButtonUp("Fire3"))
        {
            rb.drag = zeroDrag;
        }

        if (thrustInput != 0)
        {
            sprRenderer.sprite = shipFull;
        }
        else
        {
            if (rb.velocity.magnitude > 1.5f)
                sprRenderer.sprite = shipMed;
            else
                sprRenderer.sprite = ship;

        }


        rb.AddRelativeForce(Vector2.up * thrustInput * thrustForce);
        //rb.AddTorque(-turnInput); za duza bezwladnosc
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        transform.Rotate(0, 0, -turnInput * turnMultiply, Space.Self);

        if (Input.GetButton("Jump") || Input.GetButton("Fire1"))
        {
            base.directionVector = transform.up;

            Action();
        }
    }

    protected override void ImplementCollisions()
    {
        base.ImplementCollisions();

        collisionActions.Add(ObjType.Asteroid, new Action.ActionDemage().Set(1));
        //collisionActions.Add(ObjType.Player, new Action.ActionDemage().Set(1));
    }

    public void Action()
    {
        if (Time.time > lastShot)
        {
            GameObject newBullet = objectsCreator.Create();
            newBullet.transform.position = transform.position + (transform.up * 0.5f);
            newBullet.transform.rotation = transform.rotation;

            newBullet.GetComponent<Bullet>().SetDirectionVector(base.directionVector);

            lastShot = Time.time + fireRate;
        }

    }
}

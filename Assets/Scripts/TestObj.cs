using System.Collections;
using System.Collections.Generic;
using Action;
using UnityEngine;
using ObjectsCreator;

public class TestObj : MovableObject
{

    public Vector3 dirVec;
    ResourcesObjectsCreator objectsCreator;

    #region altMove
    public float thrust;
    public float turnThrust;
    private float thrustInput;
    private float turnInput;
    private float turnMultiply = 5;
    #endregion altMove

    public override void Initialize() {
        base.Initialize();
        base.directionVector = dirVec;

        objectsCreator = new ResourcesObjectsCreator(1);
    }

    //nadpisanie update na altMovement, na stary movement -> caly update do kosza
    public override void Update()
    {
        //base.Update();
        base.Teleportation();
        
    }

    public void FixedUpdate() {
        altMove();
    }

    public override void Move() {
        
        if(Input.GetButtonDown("Fire1")) { //zmienilbym na Jump -> spacja zamiast myszki
            Action();
        }
        
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
            base.directionVector = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
            dirVec = base.directionVector;
            transform.position += directionVector.normalized * speed * Time.deltaTime;
        } 

        
    }

    public void altMove() {
        if (Input.GetButtonDown("Jump"))
        {
            base.directionVector = transform.up;
            
            Action();
        }
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        rb.AddRelativeForce(Vector2.up * thrustInput);
        //rb.AddTorque(-turnInput); za duza bezwladnosc
        transform.Rotate(0, 0, -turnInput * turnMultiply, Space.Self);
    }

    protected override void ImplementCollisions()
    {
        base.ImplementCollisions();

        collisionActions.Add(ObjType.Asteroid, new Action.ActionDestroy());
        collisionActions.Add(ObjType.Player, new Action.ActionDemage().Set(1));
    }

    public void Action() {
        GameObject newBullet = objectsCreator.Create();
        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;

        newBullet.GetComponent<Bullet>().SetDirectionVector(base.directionVector);
    }
}

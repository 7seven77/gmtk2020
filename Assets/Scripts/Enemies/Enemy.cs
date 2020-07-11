using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected State state = State.Passive;

    [SerializeField]
    protected float movementSpeed = 1;

    [SerializeField]
    protected float rotationalSpeed = 1;
    
    [SerializeField]
    protected float viewRange = 10;

    [SerializeField]
    protected float fieldOfView = 20;

    protected float direction;


    private void Start()
    {
        // Sets direction to match where it was placed at the start of the game
        direction = transform.rotation.eulerAngles.z;
    }
    protected virtual void PassiveState()
    {
        // Do nothing
    }

    // Update is called once per frame
    void Update()
    {
        if (IsHostile())
        {
            state = State.Chasing;
        }
        else
        {
            state = State.Passive;
        }


        if (state == State.Passive)
        {
            PassiveState();
        } 
        else if(state == State.Chasing)
        {
            HostileState();
        }

        Transform cone = transform.Find("VisionCone");
        cone.GetChild(0).GetComponent<LineRenderer>().SetPosition(0,
            transform.localPosition);
        cone.GetChild(0).GetComponent<LineRenderer>().SetPosition(1,
            transform.localPosition + (AngleToVector(direction - (fieldOfView * 0.5f)) * viewRange));
        cone.GetChild(1).GetComponent<LineRenderer>().SetPosition(0,
            transform.localPosition);
        cone.GetChild(1).GetComponent<LineRenderer>().SetPosition(1,
            transform.localPosition + (AngleToVector(direction + (fieldOfView * 0.5f)) * viewRange));
    }

    protected static Vector3 AngleToVector(float direction)
    {
        float angle = direction * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
    }

    protected void HostileState()
    {
        Vector2 player = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MoveToPoint(player);
    }

    protected bool IsHostile()
    {
        Vector2 player = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(transform.position, player) > viewRange)
        {
            return false;
        }
        float angleToPlayer = AngleToTarget(player);
        if (Mathf.DeltaAngle(direction, angleToPlayer) < (fieldOfView * 0.5f)) 
        {
            return true;
        }
        return false;
    }

    protected void FaceDirection(float target)
    {
        direction = Mathf.MoveTowardsAngle(direction, target, rotationalSpeed);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, direction));
    }

    protected void MoveToPoint(Vector2 target)
    {
        float angleToTarget = AngleToTarget(target);
        if (angleToTarget == direction)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, movementSpeed);
        }
        else
        {
            FaceDirection(angleToTarget);
        }
    }

    protected float AngleToTarget(Vector2 target)
    {
        Vector2 diff = target - (Vector2)transform.position;
        return Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    }
}

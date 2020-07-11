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

    [SerializeField]
    protected float attackRange = 1;

    protected float direction;

    private Vector2 areaOfInterest;

    private float searchDuration;
    protected virtual void PassiveState()
    {
        // Do nothing
    }

    protected void Start()
    {
        // Sets direction to match where it was placed at the start of the game
        direction = transform.rotation.eulerAngles.z;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsHostile())
        {
            state = State.Chasing;
        }
        else if (state != State.Searching)
        {
            if (state == State.Chasing)
            {
                state = State.Searching;
            }
            else
            {
                state = State.Passive;
            }
        }

        if (state == State.Passive)
        {
            PassiveState();
        } 
        else if(state == State.Chasing)
        {
            HostileState();
        }
        else if (state == State.Searching)
        {
            SearchingState();
        }

        UpdateViewCone();
    }

    private void UpdateViewCone()
    {
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
        if (Vector2.Distance(transform.position, player) < attackRange)
        {
            FaceDirection(AngleToTarget(player));
            return;
        }
        MoveToPoint(player);
    }

    protected bool IsHostile()
    {
        Vector2 player = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(transform.position, player) < 1)
        {
            areaOfInterest = player;
            return true;
        }
        if (Vector2.Distance(transform.position, player) > viewRange)
        {
            return false;
        }
        float angleToPlayer = AngleToTarget(player);
        if (Mathf.Abs(Mathf.DeltaAngle(direction, angleToPlayer)) < (fieldOfView * 0.5f)) 
        {
            areaOfInterest = player;
            return true;
        }
        return false;
    }

    protected void SearchingState()
    {
        if ((Vector2) transform.position == areaOfInterest)
        {
            if (searchDuration == 0)
            {
                searchDuration = 360 / (rotationalSpeed * 0.5f);
            }
            else if (searchDuration == 1)
            {
                searchDuration = 0;
                state = State.Passive;
                return;
            }
            searchDuration--;
            FaceDirection(direction + 180, rotationalSpeed * 0.5f);
            return;
        }
        MoveToPoint(areaOfInterest);
    }

    protected void FaceDirection(float target)
    {
        FaceDirection(target, rotationalSpeed);
    }

    protected void FaceDirection(float target, float speed)
    {
        direction = Mathf.MoveTowardsAngle(direction, target, speed);
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

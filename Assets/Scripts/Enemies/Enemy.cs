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
        if (state == State.Passive)
        {
            PassiveState();
        }
    }

    protected void FaceDirection(float target)
    {
        direction = Mathf.MoveTowardsAngle(direction, target, rotationalSpeed);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, direction));
    }

    protected void MoveToPoint(Vector2 target)
    {
        Vector2 v2 = target - (Vector2) transform.position;
        float angleToTarget = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
        if (angleToTarget == direction)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, movementSpeed);
        }
        else
        {
            FaceDirection(angleToTarget);
        }
    }
}

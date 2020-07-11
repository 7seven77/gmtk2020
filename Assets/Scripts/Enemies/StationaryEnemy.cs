using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : Enemy
{
    private Vector2 startingPosition;

    protected void Start()
    {
        base.Start();
        startingPosition = transform.position;
    }

    protected virtual void PassiveState()
    {
        if ((Vector2)transform.position != startingPosition)
        {
            MoveToPoint(startingPosition);
        }
    }
}

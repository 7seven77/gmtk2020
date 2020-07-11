using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEnemy : Enemy
{
    [SerializeField]
    private List<float> directionList = null;

    [SerializeField]
    private int turnPeriod = 1;

    float turnTimer = 0;

    int currentDirection = 0;

    private Vector2 startingPosition;

    protected void Start()
    {
        base.Start();
        startingPosition = transform.position;
    }

    protected override void PassiveState()
    {
        if ((Vector2)transform.position != startingPosition)
        {
            MoveToPoint(startingPosition);
            return;
        }

        if (turnTimer == 0)
        {
            currentDirection = (currentDirection + 1) % directionList.Count;
            turnTimer = turnPeriod;
        }
        FaceDirection(directionList[currentDirection]);
        turnTimer--;
    }
}

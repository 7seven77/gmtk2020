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
    protected override void PassiveState()
    {
        if (turnTimer == 0)
        {
            currentDirection = (currentDirection + 1) % directionList.Count;
            turnTimer = turnPeriod;
        }
        FaceDirection(directionList[currentDirection]);
        turnTimer--;
    }
}

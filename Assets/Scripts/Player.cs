using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableObject
{
    private void FixedUpdate()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float targetDirection = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        direction = Mathf.MoveTowardsAngle(direction, targetDirection, rotationalSpeed);
        CalibrateRotation();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveForwards();
        }
    }
}

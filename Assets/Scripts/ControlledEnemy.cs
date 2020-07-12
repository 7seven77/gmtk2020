using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledEnemy : Enemy
{
    float duration = 1000;

    Vector2 targetPosition;

    protected override void Start()
    {
        base.Start();
        targetPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        duration--;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
        if (Input.GetMouseButtonDown(1))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        MoveToPoint(targetPosition);
    }

}

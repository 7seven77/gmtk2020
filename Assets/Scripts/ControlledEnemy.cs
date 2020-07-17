using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledEnemy : Enemy
{
    float duration = 100000;

    Vector2 targetPosition;
    private bool moving;
    protected override void Start()
    {
        base.Start();
        targetPosition = transform.position;
        moving = false;
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
            moving = true;
        }
        if ((Vector2) transform.position == targetPosition)
        {
            moving = false;
        }
        if (moving)
        {
            MoveToPoint(targetPosition);
        }
        else
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in objects)
            {
                print(go);
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.magnitude;
                if (curDistance < distance && curDistance < viewRange)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            if (closest != null)
            {
                print(closest);
                MoveToPoint(closest.transform.position);
            }
        }
    }

}

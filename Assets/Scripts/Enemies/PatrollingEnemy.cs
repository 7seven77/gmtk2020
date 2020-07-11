using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : Enemy
{
    [SerializeField]
    private List<Vector2> patrolPath = null;

    private int currentPathPoint;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        currentPathPoint = 0;
    }

    protected override void PassiveState()
    {
        if ((Vector2) transform.position == patrolPath[currentPathPoint])
        {
            currentPathPoint = (currentPathPoint + 1) % patrolPath.Count;
        }
        MoveToPoint(patrolPath[currentPathPoint]);
    }
}

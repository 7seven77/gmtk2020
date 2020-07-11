using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected State state = State.Passive;

    [SerializeField]
    protected float movementSpeed = 1;

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownDoor : DoorBehave
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Unit"))
        {
            PlayAnimation(GetRelativePosition(other.transform.position));
        }
    }
}
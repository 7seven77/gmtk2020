using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardDoor : DoorBehave
{


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Unit"))
        {
            print("hello");
            PlayAnimation(GetRelativePosition(other.transform.position));
        }
    }
}

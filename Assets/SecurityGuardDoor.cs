using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityGuardDoor : DoorBehave
{

    bool HasKey(TestPlayerMovement tpm) 
    {
        return tpm.hasKey;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Unit"))
        {
            if (HasKey(other.gameObject.GetComponent<TestPlayerMovement>())) 
            {
                PlayAnimation(GetRelativePosition(other.transform.position));
            }
        }
    }

}

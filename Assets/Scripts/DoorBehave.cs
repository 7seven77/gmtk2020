using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehave : MonoBehaviour
{
    Animator doorAnim;

    void Start()
    {
        doorAnim = this.GetComponent<Animator>();
    }
    protected bool GetRelativePosition(Vector3 playerPos)
    {
        float difference = playerPos.x - transform.position.x;

        return difference > 0;
    }

    protected void PlayAnimation(bool outside)
    {
        doorAnim.SetInteger("state", outside?2:1);
    }

    public void ResetDoor() 
    {
        doorAnim.SetInteger("state", 0);
    }
}
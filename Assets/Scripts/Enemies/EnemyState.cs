using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Passive, // The object does not know the player exists and acts naturally
    Chasing, // The object can see the player and is pursuing it
    Searching, // The object no longer sees the player and is looking for them
    Running, // The object is running from the player
}
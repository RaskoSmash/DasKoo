using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ActorStats
{
    public float walkSpeed, moveAccel, runSpeed;
    public Vector3 groundedJumpVelocity, aerialJumpVelocity;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ActorStats
{
    public float moveSpeed, moveAccel;
    public Vector3 groundedJumpVelocity, aerialJumpVelocity;
}

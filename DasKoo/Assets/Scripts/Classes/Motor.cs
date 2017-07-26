using UnityEngine;

[System.Serializable]
public class Motor
{
    public Rigidbody rb;
    public Transform[] groundCheckers;
    public Vector3 groundOffsetVector;
    public LayerMask groundLayer;

    //at the beginning of fixed update in actor we'll use isGrounded and store the return in grounded
    public bool grounded;

    #region Jump stats
    public bool isJump;
    public float jumpsquat;
    public float jumpHeight;
    public float timeToJumpApex;
    #endregion

    private float gravity;
    private float jumpVelocity;

    public Motor(Rigidbody rigid)
    { rb = rigid; }

    public void Move(Vector2 input, float speed, float acc)
    {
        Vector3 target = rb.transform.TransformDirection(new Vector3(input.x, 0, input.y) * speed);
        Vector3 velocity = rb.velocity;
        Vector3 changeInVelocity = target - velocity;

        changeInVelocity.x = Mathf.Clamp(changeInVelocity.x, -acc, acc);
        changeInVelocity.z = Mathf.Clamp(changeInVelocity.z, -acc, acc);

        rb.AddForce(changeInVelocity, ForceMode.VelocityChange);
        rb.velocity = new Vector3(rb.velocity.x, velocity.y, rb.velocity.z);

        //Vector3 vel = rb.velocity;
        //Vector3 target = new Vector3(input.x, 0, input.y) * speed;
        //rb.AddForce(target);
        //rb.velocity = new Vector3(rb.velocity.x, vel.y, rb.velocity.z);
    }

    public bool IsGrounded()
    {
        foreach (Transform t in groundCheckers)
        {
            Debug.DrawLine(t.position, t.position + groundOffsetVector, Color.magenta);
            if (Physics.Linecast(t.position, t.position + groundOffsetVector, groundLayer))
            {
                return true;
            }
        }
        return false;
    }

    public void Update()
    {
        if (!grounded)
        {
            rb.velocity += new Vector3(0, gravity * Time.deltaTime, 0);
        }
    }

    //jump stuff later

    public void DoJump()
    {
        //isJump = true;

        Vector3 vel = rb.velocity;

        //rb.AddForce(new Vector3(0, jumpVelocity, 0));
        rb.velocity = new Vector3(vel.x, jumpVelocity, vel.z);
    }

    public void SetGravity(float newGravity)
    {
        gravity = newGravity;
    }

    public float GetGravity()
    {
        return gravity;
    }

    public void SetJumpVelocity(float newJumpVelocity)
    {
        jumpVelocity = newJumpVelocity;
    }

    public float GetJumpVelocity()
    {
        return jumpVelocity;
    }
}


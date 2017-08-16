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
    public float maxJumpHeight;
    public float timeToJumpApex;
    public float minJumpHeight;
    #endregion

    private float gravity;
    private float maxJumpVelocity;
    private float minJumpVelocity;
    public bool jumpReleased;
    public Motor(Rigidbody rigid)
    { rb = rigid; }

    public void Move(Vector2 input, float speed, float acc)
    {
        Vector3 target = new Vector3(input.x, 0, input.y) * speed;
        Vector3 velocity = rb.velocity;
        Vector3 changeInVelocity = target - velocity;

        changeInVelocity.x = Mathf.Clamp(changeInVelocity.x, -acc, acc);
        changeInVelocity.z = Mathf.Clamp(changeInVelocity.z, -acc, acc);
        changeInVelocity.y = 0;

        rb.AddForce(changeInVelocity, ForceMode.Impulse);

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
        //if (!grounded)
        //{
            rb.velocity += new Vector3(0, gravity * Time.deltaTime, 0);
        //}
        if(jumpReleased)
        {
            //find a better way later
            if (rb.velocity.y > minJumpVelocity)
            {
                Vector3 vel = rb.velocity;
                rb.velocity = new Vector3(vel.x, minJumpVelocity, vel.z);
            }
            jumpReleased = false;
        }
    }

    //jump stuff later

    public void DoJump()
    {
        //isJump = true;

        Vector3 vel = rb.velocity;

        //rb.AddForce(new Vector3(0, jumpVelocity, 0));
        rb.velocity = new Vector3(vel.x, maxJumpVelocity, vel.z);
    }

    public void SetGravity(float newGravity)
    {
        gravity = newGravity;
    }

    public float GetGravity()
    {
        return gravity;
    }

    public void SetMaxJumpVelocity(float newJumpVelocity)
    {
        maxJumpVelocity = newJumpVelocity;
    }

    public float GetMaxJumpVelocity()
    {
        return maxJumpVelocity;
    }

    public void SetMinJumpVelocity(float newJumpVelocity)
    {
        minJumpVelocity = newJumpVelocity;
    }

    public float GetMinJumpVelocity()
    {
        return minJumpVelocity;
    }
}


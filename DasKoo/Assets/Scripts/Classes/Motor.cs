using UnityEngine;

[System.Serializable]
public class Motor
{
    private Rigidbody rb;
    public Transform[] groundCheckers;
    public Vector3 groundOffsetVector;
    public LayerMask groundLayer;

    //at the beginning of fixed update in actor we'll use isGrounded and store the return in grounded
    public bool grounded;

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
    }

    public bool IsGrounded()
    {
        foreach(Transform t in groundCheckers)
        {
            if (Physics.Linecast(t.position, t.position + groundOffsetVector, groundLayer))
            {
                return true;
            }
        }
        return false;
    }

    public void Update()
    {

    }

    //jump stuff later

    public void DoJump()
    {
        
    }
}


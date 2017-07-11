using UnityEngine;

public class Motor
{
    public Rigidbody rb;
    public Transform[] groundCheckers;
    public Vector3 groundOffsetVector;
    public LayerMask groundLayer;

    //at the beginning of fixed update in stats we'll use isGrounded and store the return in grounded
    private bool grounded;

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

    //jump stuff later
}


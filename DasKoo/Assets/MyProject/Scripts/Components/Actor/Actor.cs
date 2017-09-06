using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Actor : MonoBehaviour
{
    public int numberOfPreviousInputs;
    public Rigidbody rb;

    //more protection??
    [SerializeField]
    private Motor _motor;

    public Motor motor
    { get { return _motor; } }

    //same as motor
    private Controller _controller;
    public Controller controller
    { get { return _controller; } }

    public ActorStats actorStats;

    public bool isSprinting;

    public float turnSmoothTime;
    float turnSmoothVelocity;

    public bool isHuman;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //actorStats = new ActorStats();
        _motor.rb = rb;
        _controller = new Controller(this);
        //change these to getter setters later
        _motor.SetGravity(-(2 * _motor.maxJumpHeight) / Mathf.Pow(_motor.timeToJumpApex, 2));
        _motor.SetMaxJumpVelocity(Mathf.Abs(_motor.GetGravity()) * _motor.timeToJumpApex);
        _motor.SetMinJumpVelocity(Mathf.Sqrt(2 * Mathf.Abs(_motor.GetGravity()) * _motor.minJumpHeight));
        //_motor.groundCheckers = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        if (controller != null)
        {
            controller.Update();
        }
    }

    void FixedUpdate()
    {
        //↓ broken
        //for jumping
        motor.grounded = motor.IsGrounded();
        UseInputs();
       
        motor.Update();
    }

    void UseInputs()
    {
        //need to transfer the Actor commands into inputs in here
        if (controller != null && controller.GetCurrentFrameInput().Count > 0 && controller.canSetInput)
        {
            //need to change [0] if i want to use a list size > 1
            switch (controller.GetCurrentFrameInput()[0].type)
            {
                case ActorCommands.CommandType.ATTACK:
                    //do attack
                    break;
                case ActorCommands.CommandType.JUMP:
                    //do jump
                    motor.DoJump();
                    break;
                case ActorCommands.CommandType.SKILL:
                    //do skill
                    //skill to possess enemies and control them(a coop skill possibly)
                    break;
                case ActorCommands.CommandType.NONE:
                    //leave switch
                    break;
            }

            if (controller.GetCurrentFrameInput()[0].value != Vector2.zero)
            {
                //add acceleration and decceleration after sprint is pressed/released
                Turn(controller.GetCurrentFrameInput()[0].value);

                if (!isSprinting)
                    motor.Move(controller.GetCurrentFrameInput()[0].value, actorStats.walkSpeed, actorStats.moveAccel);
                else
                    motor.Move(controller.GetCurrentFrameInput()[0].value, actorStats.runSpeed, actorStats.moveAccel);
            }
        }

    }

    void Turn(Vector2 turnVec)
    {
        //find a way to do it without camera
        float targetRotation = 0;
        targetRotation = Mathf.Atan2(turnVec.x, turnVec.y) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y,
            targetRotation, ref turnSmoothVelocity, turnSmoothTime);
    }
}

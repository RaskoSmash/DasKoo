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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //actorStats = new ActorStats();
        _motor.rb = rb;
        _controller = new Controller(this);
        
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
        motor.grounded = motor.IsGrounded();
        //for jumping
        motor.Update();
        GrabInputs();
    }

    void GrabInputs()
    {
        //need to transfer the Actor commands into inputs in here
        if (controller != null && controller.GetCurrentFrameInput().Count > 0)
        {
            //need to change [0] if i want to use a list size > 1
            switch (controller.GetCurrentFrameInput()[0].type)
            {
                case ActorCommands.CommandType.ATTACK:
                    //do attack
                    break;
                case ActorCommands.CommandType.JUMP:
                    //do jump
                    Debug.Log("Me jump");
                    break;
                case ActorCommands.CommandType.SKILL:
                    //do skill
                    //skill to possess enemies and control them(a coop skill possibly)
                    break;
                case ActorCommands.CommandType.NONE:
                    //leave switch
                    break;
            }
            //motor.move is fine, the 10s will be replaced with stats
            motor.Move(controller.GetCurrentFrameInput()[0].value, actorStats.moveSpeed, actorStats.moveAccel);
        }

    }
}

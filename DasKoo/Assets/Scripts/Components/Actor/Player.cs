using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Global orientation
    private Vector3 movement;
    private bool attack;
    private ActorCommands input;
    private Controller con;
    public Transform cameraT;

    void Start()
    {
        con = GetComponent<Actor>().controller;
        if (con != null)
            con.canSetInput = true;
        if(cameraT == null)
        {
            cameraT = Camera.main.transform;
        }
    }

    void Update()
    {
        input.type = ActorCommands.CommandType.NONE;
        input.value.x = Input.GetAxis("Horizontal");
        input.value.y = Input.GetAxis("Vertical");
        movement = new Vector3(input.value.x, 0, input.value.y);

        movement = cameraT.transform.TransformDirection(movement);
        movement.y = 0;

        input.value = new Vector2(movement.x, movement.z);

        if (Input.GetMouseButtonDown(1))
        {
            input.type = ActorCommands.CommandType.SKILL;
        }

        if (Input.GetKeyDown("space"))
        {
            input.type = ActorCommands.CommandType.JUMP;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            con._actor.motor.jumpReleased = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            con._actor.isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            con._actor.isSprinting = false;
        }
        if (con != null)
        {
            con.SetInput(input);
        }
        else
        {
            con = GetComponent<Actor>().controller;
            if (con != null)
                con.canSetInput = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector2 movement;
    private bool attack;
    private ActorCommands input;
    private Controller con;
    private bool jump;

    void Start()
    {
        con = GetComponent<Actor>().controller;
    }

    void Update()
    {
        input.type = ActorCommands.CommandType.NONE;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        input.value = movement;

        if (Input.GetKeyDown("space"))
        {
            input.type = ActorCommands.CommandType.JUMP;
        }

        if (con != null)
        {
            con.SetInput(input);
        }
        else
        {
            con = GetComponent<Actor>().controller;
        }
    }
}

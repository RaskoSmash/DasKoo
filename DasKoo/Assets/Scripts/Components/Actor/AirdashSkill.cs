using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirdashSkill : MonoBehaviour
{
    private Controller con;
    public float speed;
    public Vector3 airdashDir;
    private Vector3 origAirdash;
    public float maxInputTimer;
    private float inputTimer;
    public float cooldown, maxCooldown;
    void Start()
    {
        con = GetComponent<Actor>().controller;
        origAirdash = airdashDir;
        cooldown = 0;
    }

    void Update()
    {
        //just for testing right now
        if (con != null && con.GetCurrentFrameInput().Count > 0 && con.canSetInput && cooldown <= 0 && 
            con.GetCurrentFrameInput()[0].type == ActorCommands.CommandType.SKILL && !con._actor.motor.grounded)
        {
            DoAirDash();
        }

        if (inputTimer < maxInputTimer)
        {
            inputTimer += Time.deltaTime;
        }
        else
        {
            inputTimer = maxInputTimer;
            con.canSetInput = true;
        }
        cooldown = cooldown <= 0 ? 0 : cooldown - Time.deltaTime;
    }

    private void DoAirDash()
    {
        //current velocity
        Vector3 temp = con._actor.rb.velocity;

        //get input
        airdashDir = Vector3.Normalize(new Vector3(con.GetCurrentFrameInput()[0].value.x, 0,
            con.GetCurrentFrameInput()[0].value.y));

        //no input? use a default direction
        if (airdashDir == Vector3.zero)
            airdashDir = Vector3.Normalize(origAirdash);

        Vector3 newVel = (airdashDir * speed) + temp;
        newVel.y = 0;
        con._actor.rb.AddForce(newVel, ForceMode.VelocityChange);
        cooldown = maxCooldown;
        inputTimer = 0;
        con.canSetInput = false;
    }
}
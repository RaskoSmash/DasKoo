using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    public Rigidbody rb;
    //more protection??
    private Motor _motor;
    public Motor motor
    { get { return _motor; } }

    //same as motor
    private Controller _controller;
    public Controller controller
    { get { return _controller; } }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _motor = new Motor(rb);
        _controller = new Controller();
    }

    void FixedUpdate()
    {

    }
}

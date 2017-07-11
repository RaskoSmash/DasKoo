//using UnityEngine;

//// Responsible for obtaining input from unity and sending it to a controller
//public class Player : MonoBehaviour
//{
//    Controller target;

//    void SetTarget(Actor actor)
//    { target = actor.controller; }

//    void GetInput()
//    { }

//    void SetInput()
//    { target.SetInput(); }
//}

//// Responsible for receiving input from a player or AI and sending it to the actor
//public class Controller
//{

//    public void SetInput()
//    { }

//    public void Update()
//    { }
//}
//// Does things!
//public class Actor : MonoBehaviour
//{

//    private Controller _controller;
//    public  Controller controller
//    { get { return _controller; } }

//    private Motor _motor;
//    public  Motor motor
//    { get { return _motor; } }

//    void Update()
//    { controller.Update(); }

//    void FixedUpdate()
//    { motor.Update(); }

//}

//// Responsible for physics of an actor
//public class Motor
//{ 
//    public void Move()
//    {

//    }

//    public void Update()
//    {

//    }
//}

/*
 public class Player : MonoBehavior
 {
    List<ActorCommands> currentInput;
    List<ActorCommands> previousFrameInput;
    
    ActorStats stats;

    update()
    {
        //check for input??
        //based on input, send a actor command to stats
           
    }
 }
 */

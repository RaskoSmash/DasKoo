using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    public List<ActorCommands> queueInput;
    public List<ActorCommands> currentFrameInput;

    public void SetInput(List<ActorCommands> commands)
        { queueInput = commands; }

    public void Update()
    {
        currentFrameInput = queueInput;
    }
}

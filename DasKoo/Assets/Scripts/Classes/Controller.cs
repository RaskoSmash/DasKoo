using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    public Actor _actor;
    private List<ActorCommands> queueInput;
    private List<ActorCommands> currentFrameInput;
    public bool canSetInput = true;

    public Controller(Actor actor)
    {
        _actor = actor;
        queueInput = new List<ActorCommands>();
        currentFrameInput = new List<ActorCommands>();
    }

    public void SetInput(ActorCommands commands)
    {
        if (queueInput.Count >= _actor.numberOfPreviousInputs)
        {
            queueInput.RemoveAt(0);
            queueInput.Add(commands);
        }
        else
            queueInput.Add(commands);
    }

    public void Update()
    {
        currentFrameInput = queueInput;
    }

    public List<ActorCommands> GetCurrentFrameInput()
    {
        return currentFrameInput;
    }

    //debug purposes
    public List<ActorCommands> GetQueueInput()
    {
        return queueInput;
    }
}

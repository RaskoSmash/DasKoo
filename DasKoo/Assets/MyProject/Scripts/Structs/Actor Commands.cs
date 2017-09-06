using UnityEngine;
public struct ActorCommands
{
    public Vector2 value; //-1 to 1
    public enum CommandType
    {
        NONE = 0,
        //HORIZONTAL_MOVEMENT = 1,
        //VERTICAL_MOVEMENT = 2,
        JUMP = 3,
        ATTACK = 4,
        SKILL = 5 
    }
    public CommandType type;
}

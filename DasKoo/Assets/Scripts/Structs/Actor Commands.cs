public struct ActorCommands
{
    float value; //-1 to 1
    enum CommandType
    {
        VERTICAL_MOVEMENT = 1,
        HORIZONTAL_MOVEMENT = 2,
        JUMP = 3,
        ATTACK = 4,
        SKILL = 5
    }
    CommandType type;
}

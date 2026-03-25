using UnityEngine;

public class TimeDecorator : CommandDecorator
{
    public float Time;

    public TimeDecorator(Command command, float time) : base(command)
    {
        Time = time;
    }

    public override KeyCode Key { get; set; }

    public override string Description { get; }




}

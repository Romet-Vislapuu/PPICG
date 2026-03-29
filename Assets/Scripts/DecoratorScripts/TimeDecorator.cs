using System;
using UnityEngine;

public class TimeDecorator : CommandDecorator
{
    public float Time;
    public Type type;//need for debugging rn

    public TimeDecorator(Command command, float time) : base(command)
    {
        Time = time;
        type = command.GetType();

    }

    public override KeyCode Key { get; set; }

    public override string Description { get; }




}

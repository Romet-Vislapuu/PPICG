//Command.cs
using UnityEngine;

public abstract class Command
{
    public abstract KeyCode Key { get; set; }
    public abstract string Description { get; }//just mettainfo


    public abstract void Execute(MonoBehaviour receiver);




}
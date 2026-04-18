using UnityEngine;

public abstract class Command
{

    public abstract KeyCode Key { get; set; }
    public abstract string Description { get; }
    public abstract bool Execute(GridMovement receiver);
}

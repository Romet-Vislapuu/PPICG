using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private KeyCode key;
    private Vector3 direction;

    public override KeyCode Key
    {
        get { return key; }
        set { key = value; }
    }

    public override string Description => "Moves the object in a specified direction.";

    // Constructor to set the direction and key at creation time
    public MoveCommand(KeyCode key, Vector3 direction)
    {
        this.key = key;
        this.direction = direction;
    }
    
    // Execute method calls the Walk method on the GridMovement component
    public override bool Execute(GridMovement receiver)
    {
        return receiver.Walk(direction);
    }
}
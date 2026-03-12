using UnityEngine;

// Implements the Command class
// Is the ConcreteCommand class
public class MoveCommand : Command
{
    public override KeyCode Key { get; set ; }

    public override string Description { get; }
    private Vector3 direction;
    private MonoBehaviour receiver;//character who moved

    // dont change signature so dont pass direction using execute, make direction a field of MoveCommand class
    public override bool Execute(MonoBehaviour receiver)
    {
        this.receiver = receiver;
        if (receiver is not GridMovement) return false;
        if((receiver as GridMovement).Walk(direction))
            return true;
        return false;
    }

    public override bool Undo()
    {
        Debug.Log("Undo triggered");
        Debug.Log("Original direction" + direction);
        Debug.Log("New Direction"+-direction);
        if (receiver is not GridMovement) return false;
        if((receiver as GridMovement).Walk(-direction))
            return true;
        return false;

    }

    //Constructor for the class
    public MoveCommand(KeyCode key, string description, Vector3 direction)
    {
        Key = key;
        Description = description;
        this.direction = direction;
    }
}

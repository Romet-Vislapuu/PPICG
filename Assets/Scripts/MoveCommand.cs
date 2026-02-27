using UnityEngine;

// Implements the Command class
// Is the ConcreteCommand class
public class MoveCommand : Command
{
    public override KeyCode Key { get; set ; }

    public override string Description { get; }
    private Vector3 direction;

    // dont change signature so dont pass direction using execute, make direction a field of MoveCommand class
    public override void Execute(MonoBehaviour receiver)
    {
        if (receiver is GridMovement)
        {
            (receiver as GridMovement).Walk(direction);
            return;
        }
        if (receiver is SnakeObject)
        {
            (receiver as SnakeObject).SnakeWalk4(direction);
            return;
        }
        return;
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }

    //Constructor for the class
    public MoveCommand(KeyCode key, string description, Vector3 direction)
    {
        Key = key;
        Description = description;
        this.direction = direction;
    }
}

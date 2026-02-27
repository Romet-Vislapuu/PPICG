//Command.cs
using UnityEngine;

public abstract class Command
{
    public abstract KeyCode Key { get; set; }
    public abstract string Description { get; }//just mettainfo

    /*
    Todo:
        1. Add an abstract Execute method with an argument for receiver.
            For your consideration:
                What would make for a good Execute receiver parameter?
                Should we try to limit the receiver types?
                How precisely can we limit the receiver's type?
                Could we move the receiver into command data instead?
                What are the benefits of either approach? Which works best here?
    */

    /*
    2. Create a MoveCommand class, which executes Walk method in TileBasedMovement component.
       Execute method of this command should call the Walk(Vector3 direction) method of GridMovement.
*/
    // Option 1: Gridmomvement is reciever: Execute(Gridmovement receiver). But this wouldnt work with other reciever.
    // Option 2: MonoBehaviour or gameobject.
    public abstract void Execute(MonoBehaviour receiver);
    public abstract void Undo();




}
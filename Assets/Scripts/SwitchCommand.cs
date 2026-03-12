using System.Collections.Generic;
using UnityEngine;

public class SwitchCommand : Command
{
    public override KeyCode Key { get; set; }

    public override string Description { get; }
    private CameraMovement Camera;
    private InputHandler InputHandler;
    private MonoBehaviour receiver;

    public override bool Execute(MonoBehaviour receiver)
    {
        //Debug.Log("SwitchCommand entered");
        this.receiver = receiver;
        //Debug.Log(Camera!=null); 
        if(Camera!=null && InputHandler != null)
        {
            //Debug.Log("SwitchCommand triggered");

            Camera.SetTarget(InputHandler.NextActor().transform);
            return true;
        }
        return false;
    
    }

    public override bool Undo()
    {
        if (Camera != null && InputHandler != null)
        {
            Camera.SetTarget(InputHandler.PreviousActor().transform);
            return true;
        }
        return false;
    }

    public SwitchCommand(KeyCode Key, string Description, CameraMovement Camera, InputHandler inputHandler) { 
        this.Key = Key;
        this.Description = Description;
        this.Camera = Camera;
        this.InputHandler = inputHandler;

    }
}

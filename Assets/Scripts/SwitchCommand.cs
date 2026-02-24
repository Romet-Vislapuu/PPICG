using System.Collections.Generic;
using UnityEngine;

public class SwitchCommand : Command
{
    public override KeyCode Key { get; set; }

    public override string Description { get; }
    private CameraMovement Camera;
    private InputHandler InputHandler;


    public override void Execute(MonoBehaviour receiver)
    {
        if(Camera!=null && InputHandler != null)
        {
            Camera.SetTarget(InputHandler.NextActor().transform);
        }
    
    }
    public SwitchCommand(KeyCode Key, string Description, CameraMovement Camera, InputHandler inputHandler) { 
        this.Key = Key;
        this.Description = Description;
        this.Camera = Camera;
        this.InputHandler = inputHandler;
    }
}

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
        if(Camera!=null && InputHandler != null )
        {
            MonoBehaviour a = InputHandler.NextActor();
            if (a is GridMovement)
            {
                Camera.SetTarget(a.transform);
                return;
            }
            // Following the Snakeobject itself breaks the camera. It stops following the snake. Have to do this ugly workaround.
            else if(a is SnakeObject) { 
                Camera.SetTarget((a as SnakeObject).getHead().transform);
            }

                ;
            //Camera.JumpToTarget();
        }
    
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }

    public SwitchCommand(KeyCode Key, string Description, CameraMovement Camera, InputHandler inputHandler) { 
        this.Key = Key;
        this.Description = Description;
        this.Camera = Camera;
        this.InputHandler = inputHandler;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCommand : Command
{
    private KeyCode key;
    private CameraMovement cameraMovement;
    private InputHandler inputHandler;

    public override KeyCode Key
    {
        get { return key; }
        set { key = value; }
    }

    public override string Description => "Switches the active character.";

    public SwitchCommand(KeyCode key, CameraMovement cameraMovement, InputHandler inputHandler)
    {
        this.key = key;
        this.cameraMovement = cameraMovement;
        this.inputHandler = inputHandler;
    }

    public override bool Execute(GridMovement receiver)
    {
        //We can ignore the receiver in this context
        inputHandler.SwitchCharacter();
        cameraMovement.SetTarget(inputHandler.getCurrentActor().transform);

        return true;
    }
}
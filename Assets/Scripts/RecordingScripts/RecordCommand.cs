using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecordCommand : RecorderInputCommand
{
    public override KeyCode Key { get; set; }

    public override string Description { get; }

    public InputHandler Handler;

    public override void Execute(MonoBehaviour receiver)
    {
        return;//now handled by states
    }
    public RecordCommand(KeyCode key, string Description, InputHandler handler) { 
        this.Key = key;
        this.Description = Description; 
        this.Handler = handler;
    
    
    }
}

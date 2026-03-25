using UnityEngine;

public class PlayCommand : RecorderInputCommand
{

    public override KeyCode Key { get; set; }

    public override string Description { get; }

    public InputHandler Handler;
    public override void Execute(MonoBehaviour receiver)
    {
        if(Handler != null)
            Handler.PlayMacro();
    }

    public PlayCommand(KeyCode key, string description, InputHandler handler)
    {
        Key = key;
        Description = description;
        Handler = handler;
    }
}

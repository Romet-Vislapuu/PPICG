using UnityEngine;

public abstract class CommandDecorator : Command
{
    protected Command wrappedCommand;

    public CommandDecorator(Command command) { 
        wrappedCommand = command;
    }

    public override void Execute(MonoBehaviour receiver)
    {
        wrappedCommand.Execute(receiver);
    
    }
}

using UnityEngine;

public abstract class CommandDecorator : Command
{
    protected Command wrappedCommand;

    public CommandDecorator(Command command) { 
        wrappedCommand = command;
    }

    public override bool Execute(GridMovement receiver)
    {
        wrappedCommand.Execute(receiver);
        return false;
    
    }
}

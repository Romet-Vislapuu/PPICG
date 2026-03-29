using System.Collections.Generic;
using UnityEngine;

public class RecorderRecordState : RecorderState
{
    private float TimePassed = 0;
    private Command wrappedCommand = null;


    public override RecorderState Play()
    {
        this.inputRecorder.SavedMacro = this.inputRecorder.NewMacro;
        this.inputRecorder.NewMacro = new List<Command>();

        RecorderState newstate = new RecorderPlayState();
        newstate.Enter(this.inputRecorder);
        return newstate;
    }
    public override RecorderState Record()
    {
        this.inputRecorder.SavedMacro = this.inputRecorder.NewMacro;
        this.inputRecorder.NewMacro = new List<Command>();

        RecorderState newstate = new RecorderIdleState();
        newstate.Enter(this.inputRecorder);
        return newstate;
    }
    public override RecorderState Add(Command command)
    {
        if (command is not RecorderInputCommand)
        {
            this.TimePassed += Time.deltaTime;
            wrappedCommand = new TimeDecorator(command, TimePassed);
            this.inputRecorder.NewMacro.Add(command);
            TimePassed = 0;

            return this;
        }
        else {
            return base.Add(command);
        }


    }


}

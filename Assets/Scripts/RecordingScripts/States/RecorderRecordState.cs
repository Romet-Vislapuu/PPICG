using System.Collections.Generic;
using UnityEngine;

public class RecorderRecordState : RecorderState
{
    private float lastCommandTime = 0;// not deltatime. unitys internal clock that runs the entire time, because I can only update each time add is called, not each frame.
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
            float delta = Time.time - lastCommandTime;
            lastCommandTime = Time.time;
            wrappedCommand = new TimeDecorator(command, delta);
            this.inputRecorder.NewMacro.Add(wrappedCommand);
            lastCommandTime = Time.time;

            return this;
        }
        else {
            return base.Add(command);
        }


    }
    public override void Enter(InputRecorder inputRecorder)
    {
        lastCommandTime = Time.time;
        base.Enter(inputRecorder);
    }


}

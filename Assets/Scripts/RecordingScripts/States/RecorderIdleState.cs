using UnityEngine;

public class RecorderIdleState : RecorderState
{
    public override RecorderState Play()
    {
        RecorderState newstate = new RecorderPlayState();
        newstate.Enter(this.inputRecorder);
        return newstate;

    }
    public override RecorderState Record()
    {
        RecorderState newstate = new RecorderRecordState();
        newstate.Enter(this.inputRecorder);
        return newstate ;
    }

}

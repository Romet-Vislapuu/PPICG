using System.Collections;
using UnityEngine;

public class RecorderPlayState: RecorderState
{
    public override RecorderState Play()
    {
        this.inputRecorder.StopCoroutine(MacroCoroutine());
        RecorderState newstate = new RecorderIdleState();
        newstate.Enter(this.inputRecorder);
        return newstate;
    }
    public override RecorderState Record()
    {
        this.inputRecorder.StopCoroutine(MacroCoroutine());
        RecorderState newstate = new RecorderRecordState();
        newstate.Enter(this.inputRecorder);
        return newstate;
    }
    public override void Enter(InputRecorder inputRecorder)
    {
        base.Enter(inputRecorder);
        inputRecorder.StartCoroutine(MacroCoroutine());

    }


    private IEnumerator MacroCoroutine()
    {
        //Debug.Log("Starting Macro");
        foreach (Command com in this.inputRecorder.SavedMacro)
        {
            yield return new WaitForSeconds((com as TimeDecorator).Time);
            com.Execute(this.inputRecorder.InputHandler.currentActor);


        }
        //Debug.Log("Ending Macro");


    }

}

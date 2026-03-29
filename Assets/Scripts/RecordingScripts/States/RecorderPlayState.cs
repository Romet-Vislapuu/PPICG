using System.Collections;
using UnityEngine;

public class RecorderPlayState: RecorderState
{
    public bool finished=false;
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
        //Debug.Log("l1");
        inputRecorder.StartCoroutine(MacroCoroutine());
        //Debug.Log("l2");

    }


    private IEnumerator MacroCoroutine()
    {
        //Debug.Log("Starting Macro");
        foreach (Command com in this.inputRecorder.SavedMacro)
        {
            //Debug.Log(this.inputRecorder.SavedMacro.Count);
            yield return new WaitForSeconds((com as TimeDecorator).Time);

            //yield return new WaitForSecondsRealtime(5);

            com.Execute(this.inputRecorder.InputHandler.currentActor);


        }
        // PlayState needs to switch to idleState according to the diagram, but the way I set everything up, each state change is tied to a button press.
        finished = true;
;




    }

}

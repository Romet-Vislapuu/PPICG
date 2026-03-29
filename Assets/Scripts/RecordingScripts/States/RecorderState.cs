using UnityEditor;
using UnityEngine;

public class RecorderState
{
    protected InputRecorder inputRecorder;
    public virtual void Enter(InputRecorder inputRecorder) {
        this.inputRecorder = inputRecorder;
    }
    public virtual RecorderState Play() { return null; }
    public virtual RecorderState Record() { return null; }
    public virtual RecorderState Add(Command command)
    {

        if (command is RecorderInputCommand)
        {
            if (command is PlayCommand)
            {
                return this.Play();
            }
            else
            {
                return this.Record();
            }
        }
        return this;//only RecorderRecordState cares about other commands. All others ignore them.




    }
}

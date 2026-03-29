using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    public RecorderState State;
    public List<Command> SavedMacro = new List<Command>();
    public List<Command> NewMacro = new List<Command>();
    public InputHandler InputHandler;
    

    void Start()
    {
        RecorderState newstate = new RecorderIdleState();
        State = newstate;
        State.Enter(this);

    }

    void Update()
    {
        
    }
    public void Add(Command command) {
        RecorderState newstate = State.Add(command);
        State = newstate;
        // The code was so pretty but then at the last minute I realized PlayState needs to automatically transition into IdleState, which I did not account for...
        // Now that i think about it, this only fixes the problem half the time lol. But I dont want to check every update.
        if (State is RecorderPlayState) {
            if ((State as RecorderPlayState).finished) {
                newstate = new RecorderIdleState();
                State = newstate;
                State.Enter(this);
            }
        }
        Debug.Log(State);
    }

}

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    private RecorderState State;
    public List<Command> SavedMacro = new List<Command>();
    public List<Command> NewMacro = new List<Command>();
    public InputHandler InputHandler;
    void Start()
    {
        RecorderState State = new RecorderIdleState();
        State.Enter(this);
    }

    void Update()
    {
        
    }
    public void Add(Command command, InputHandler inputHandler) {
        InputHandler = inputHandler;//
        RecorderState newstate = State.Add(command);
        State = newstate;
    }

}

//InputHandler.cs
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//Invoke handler and client
public class InputHandler : MonoBehaviour
{

    [SerializeField]
    // The character currently being commanded
    private GridMovement currentActor;

    // A list of all characters in the scene
    private List<GridMovement> allActors;

    // Variables for binding commands to input and executing commands
    public List<Command> Keymap = new List<Command>();  // keycode to command mapping

    public List<Command> SavedMacro = new List<Command>();
    public List <Command> NewMacro = new List<Command>();
    private Command wrappedCommand = null;

    private bool Recording = false;
    private float TimePassed = 0;
    private bool MacroActive = false;




    [SerializeField]
    private CameraMovement currentCamera;

    void Awake()
    {
        allActors = FindObjectsOfType<GridMovement>().ToList();




        currentCamera = Camera.main.GetComponentInParent<CameraMovement>();
   
        MoveCommand moveUpCommand = new MoveCommand(KeyCode.W, "This moves up", Vector3.up);
        MoveCommand moveDownCommand = new MoveCommand(KeyCode.S, "This moves down", Vector3.down);
        MoveCommand moveLeftCommand = new MoveCommand(KeyCode.A, "This moves left", Vector3.left);
        MoveCommand moveRightCommand = new MoveCommand(KeyCode.D, "This moves right", Vector3.right);
        SwitchCommand switchCommand = new SwitchCommand(KeyCode.Tab, "This switches characters", currentCamera, this);
        RecordCommand recordCommand = new RecordCommand(KeyCode.Q, "This records the macro",this);
        PlayCommand playCommand = new PlayCommand(KeyCode.E, "This plays the command", this);



        Keymap.Add(moveUpCommand);
        Keymap.Add(moveDownCommand);
        Keymap.Add(moveLeftCommand);
        Keymap.Add(moveRightCommand);
        Keymap.Add(switchCommand);
        Keymap.Add(recordCommand);
        Keymap.Add(playCommand);
    }

    public GridMovement NextActor() {
        int index = allActors.IndexOf(currentActor);


        Debug.Log("CurrentActor:" + currentActor);
        Debug.Log(index);


        if ((index+1) == allActors.Count)
        {
            currentActor = allActors[0];
            Debug.Log("New currentactor: " + currentActor);

            return currentActor;

        }
        else {
            currentActor = allActors[index+1];
            Debug.Log("New currentactor: "+currentActor);
            Debug.Log(index+1);
            return currentActor;
        }
    
    
    }


    void Update()
    {
        if (Recording)
        {
            this.TimePassed += Time.deltaTime;
            foreach (Command command in Keymap)
            {
                if (Input.GetKeyDown(command.Key))
                {
                    if (command is not RecorderInputCommand)
                    {
                        wrappedCommand = new TimeDecorator(command,TimePassed);
                        command.Execute(currentActor);
                        NewMacro.Add(wrappedCommand);
                        TimePassed = 0;

                    }
                    else
                    {
                        command.Execute(currentActor);

                    }
                }
            }
        }
        else
        {

            foreach (Command command in Keymap)
            {
                if (Input.GetKeyDown(command.Key))
                {
                    command.Execute(currentActor);
                }
            }
        }
    }


    public void PlayMacro()
    {
        if (Recording)
            RecordMacro();// turn it off


        if (!MacroActive)
        {
            StartCoroutine(MacroCoroutine());
            MacroActive = true;
        }
        else {
            StopCoroutine(MacroCoroutine());
            MacroActive = false;
        }




    }
    public void RecordMacro() {

        //if recording, turn off
        if (Recording) {
            Debug.Log("Ending Recording");
            Recording = false;
            TimePassed = 0;
            SavedMacro = NewMacro;
        }
        //else turn on
        else
        {
            Debug.Log("Starting Recording");
            NewMacro = new List<Command>();
            Recording = true;

        }


    }//RecordMacro

    private IEnumerator MacroCoroutine()
    {
        Debug.Log("Starting Macro");
        foreach (Command com in SavedMacro)
        {
            yield return new WaitForSeconds((com as TimeDecorator).Time);
            com.Execute(currentActor);


        }
        Debug.Log("Ending Macro");


    }
}
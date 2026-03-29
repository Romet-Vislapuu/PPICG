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
    public GridMovement currentActor;

    // A list of all characters in the scene
    private List<GridMovement> allActors;

    // Variables for binding commands to input and executing commands
    public List<Command> Keymap = new List<Command>();  // keycode to command mapping

    public List<Command> SavedMacro = new List<Command>();
    public List <Command> NewMacro = new List<Command>();
    //private Command wrappedCommand = null;// do i nee this now
    public InputRecorder inputRecorder;




    [SerializeField]
    private CameraMovement currentCamera;

    void Awake()
    {
        allActors = FindObjectsOfType<GridMovement>().ToList();
        inputRecorder = FindObjectOfType<InputRecorder>();
        inputRecorder.InputHandler = this;




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
            foreach (Command command in Keymap)
            {
                if (Input.GetKeyDown(command.Key))
                {
                    command.Execute(currentActor);
                    inputRecorder.Add(command);
                }
            }
        }
    }




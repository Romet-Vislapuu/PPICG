//InputHandler.cs
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
//Invoke handler and client
public class InputHandler : MonoBehaviour
{

    // SerializeField let's us assign a value in the Unity editor for private variables.
    [SerializeField]
    // The character currently being commanded
    private GridMovement currentActor;

    // A list of all characters in the scene
    private List<GridMovement> allActors;

    // Variables for binding commands to input and executing commands
    //public List<Command> Keymap = new List<Command>();  // keycode to command mapping

    public List<KeyMapObject> KeyMap = new List<KeyMapObject>();
    private Stack<Command> commandHistory = new Stack<Command>();



    [SerializeField]
    private CameraMovement currentCamera;

    // Use this for initialization
    void Awake()
    {
        allActors = FindObjectsOfType<GridMovement>().ToList();
        KeyMap.Add(new KeyMapObject(KeyCode.W, typeof(MoveCommand),Vector3.up));
        KeyMap.Add(new KeyMapObject(KeyCode.S, typeof(MoveCommand),Vector3.down));
        KeyMap.Add(new KeyMapObject(KeyCode.A, typeof(MoveCommand),Vector3.left));
        KeyMap.Add(new KeyMapObject(KeyCode.D, typeof(MoveCommand), Vector3.right));
        KeyMap.Add(new KeyMapObject(KeyCode.Q, null, null));








        currentCamera = Camera.main.GetComponentInParent<CameraMovement>();
        KeyMap.Add(new KeyMapObject(KeyCode.Tab, typeof(SwitchCommand), currentCamera));


        //MoveCommand moveUpCommand = new MoveCommand(KeyCode.W, "This moves up", Vector3.up);
        //MoveCommand moveDownCommand = new MoveCommand(KeyCode.S, "This moves down", Vector3.down);
        //MoveCommand moveLeftCommand = new MoveCommand(KeyCode.A, "This moves left", Vector3.left);
        //MoveCommand moveRightCommand = new MoveCommand(KeyCode.D, "This moves right", Vector3.right);
        //SwitchCommand switchCommand = new SwitchCommand(KeyCode.Tab, "This switches characters", currentCamera, this);



        //Keymap.Add(moveUpCommand);
        //Keymap.Add(moveDownCommand);
        //Keymap.Add(moveLeftCommand);
        //Keymap.Add(moveRightCommand);
        //Keymap.Add(switchCommand);
    }

    public GridMovement NextActor() {
        int index = allActors.IndexOf(currentActor);
        //Debug.Log("[0]" + allActors[0]);

        //Debug.Log("[1]:" + allActors[1]);

        Debug.Log("CurrentActor:" + currentActor);
        Debug.Log(index);


        if ((index + 1) == allActors.Count)
        {
            currentActor = allActors[0];
            Debug.Log("New currentactor: " + currentActor);

            return currentActor;

        }
        else {
            currentActor = allActors[index + 1];// What is up with index++ breaking every??? ANSWERED
            Debug.Log("New currentactor: " + currentActor);
            Debug.Log(index + 1);
            return currentActor;
        }
    }
    public GridMovement PreviousActor()
    {
        int index = allActors.IndexOf(currentActor);
        //Debug.Log("[0]" + allActors[0]);

        //Debug.Log("[1]:" + allActors[1]);

        Debug.Log("CurrentActor:" + currentActor);
        Debug.Log(index);


        if ((index - 1) == -1)
        {
            currentActor = allActors[allActors.Count-1];
            Debug.Log("New currentactor: " + currentActor);

            return currentActor;

        }
        else
        {
            currentActor = allActors[index - 1];
            Debug.Log("New currentactor: " + currentActor);
            Debug.Log(index - 1);
            return currentActor;
        }
    }



    void Update()
    {
            foreach (KeyMapObject kmo in KeyMap)
            {
            if (Input.GetKeyDown(kmo.keyCode))
            {
                if (kmo.keyCode == KeyCode.Q)
                {
                    if (commandHistory.Count != 0) {
                        if (commandHistory.Peek().Undo())
                        {
                            commandHistory.Pop().Undo();
                        }
                    } 
                }
                else
                {
                    Command command = CreateCommandObject(kmo);
                    if(command.Execute(currentActor))
                        commandHistory.Push(command);
                }
            }
            }

        
    }


    // Messy but I am lazy
    private Command CreateCommandObject(KeyMapObject kmo) {
        Command command;
        if (kmo.command == typeof(MoveCommand)) {
             command = (Command)Activator.CreateInstance(kmo.command,kmo.keyCode, "",kmo.additional);
        }
        else{
             command = (Command)Activator.CreateInstance(kmo.command,kmo.keyCode, "", kmo.additional, this);
        }
        return command;
    }

}
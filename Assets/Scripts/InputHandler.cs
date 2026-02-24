//InputHandler.cs
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
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
    public List<Command> Keymap = new List<Command>();  // keycode to command mapping

    [SerializeField]
    private CameraMovement currentCamera;

    // Use this for initialization
    void Awake()
    {
        allActors = FindObjectsOfType<GridMovement>().ToList();




        currentCamera = Camera.main.GetComponentInParent<CameraMovement>();
        // TODO: Add movement commands to the list
        //TODOING: Get al the movement commands from gridmovement to here
        MoveCommand moveUpCommand = new MoveCommand(KeyCode.W, "This moves up", Vector3.up);
        MoveCommand moveDownCommand = new MoveCommand(KeyCode.S, "This moves down", Vector3.down);
        MoveCommand moveLeftCommand = new MoveCommand(KeyCode.A, "This moves left", Vector3.left);
        MoveCommand moveRightCommand = new MoveCommand(KeyCode.D, "This moves right", Vector3.right);
        SwitchCommand switchCommand = new SwitchCommand(KeyCode.Tab, "This switches characters", currentCamera, this);

        Keymap.Add(moveUpCommand);
        Keymap.Add(moveDownCommand);
        Keymap.Add(moveLeftCommand);
        Keymap.Add(moveRightCommand);
        Keymap.Add(switchCommand);
    }

    public GridMovement NextActor() {
        int index = allActors.IndexOf(currentActor);
        //Debug.Log("[0]" + allActors[0]);

        //Debug.Log("[1]:" + allActors[1]);

        Debug.Log("CurrentActor:" + currentActor);
        Debug.Log(index);


        if ((index+1) == allActors.Count)
        {
            currentActor = allActors[0];
            Debug.Log("New currentactor: " + currentActor);

            return currentActor;

        }
        else {
            currentActor = allActors[index+1];// What is up with index++ breaking every??? ANSWERED
            Debug.Log("New currentactor: "+currentActor);
            Debug.Log(index+1);
            return currentActor;
        }
    
    
    }


    void Update()
    {
        // TODO: Loop through all commands and execute them on correct actor via correct key press.
        foreach (Command command in Keymap)
        {
            if (Input.GetKeyDown(command.Key))
            {
                command.Execute(currentActor);
            }
        }
    }
}
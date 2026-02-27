//InputHandler.cs
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//Invoke handler and client
public class InputHandler : MonoBehaviour
{

    // SerializeField let's us assign a value in the Unity editor for private variables.
    [SerializeField]
    // The character currently being commanded
    private MonoBehaviour currentActor;

    [SerializeField]
    //private SnakeObject currentSnake;


    // A list of all characters in the scene
    private List<GridMovement> allActors;

    private List<SnakeObject> allSnakes;

    // Variables for binding commands to input and executing commands
    public List<Command> Keymap = new List<Command>();  // keycode to command mapping

    [SerializeField]
    private CameraMovement currentCamera;

    // Use this for initialization
    void Awake()
    {
        allActors = FindObjectsOfType<GridMovement>().ToList();

        allSnakes = FindObjectsOfType<SnakeObject>().ToList();




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

    public MonoBehaviour NextActor() {
        int index;

        if (currentActor is GridMovement)
        {
            index = allActors.IndexOf(currentActor as GridMovement);
            if ((index + 1) == allActors.Count)
            {
                currentActor = allActors[0];
                Debug.Log("New currentactor: " + currentActor);

                return currentActor;
            }
            else
            {
                currentActor = allActors[index + 1];
                Debug.Log("New currentactor: " + currentActor);
                Debug.Log(index + 1);
                return currentActor;
            }
        }
        if (currentActor is SnakeObject)
        {
            index = allSnakes.IndexOf(currentActor as SnakeObject);
            if ((index + 1) == allSnakes.Count)
            {
                currentActor = allSnakes[0];
                Debug.Log("New currentactor: " + currentActor);

                return currentActor;

            }
            else
            {
                currentActor = allSnakes[index + 1];
                Debug.Log("New currentactor: " + currentActor);
                //Debug.Log(index + 1);
                return currentActor;
            }
        }
        else
            return null;
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
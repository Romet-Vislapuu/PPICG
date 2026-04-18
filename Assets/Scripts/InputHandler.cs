using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private GridMovement currentActor;
    private List<GridMovement> allActors;
    private Stack<Command> commandHistory = new Stack<Command>();
    public List<Command> Keymap = new List<Command>();
    
    // Use this for initialization
    void Awake()
    {
        allActors = FindObjectsOfType<GridMovement>().ToList();
        
        Keymap.Add(new MoveCommand(KeyCode.W, Vector3.up));
        Keymap.Add(new MoveCommand(KeyCode.S, Vector3.down));
        Keymap.Add(new MoveCommand(KeyCode.A, Vector3.left));
        Keymap.Add(new MoveCommand(KeyCode.D, Vector3.right));
        
        //Initialize and add the SwitchCharacterCommand
        CameraMovement cameraMovement = Camera.main.GetComponentInParent<CameraMovement>();
        Keymap.Add(new SwitchCommand(KeyCode.Tab, cameraMovement, this));
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var command in Keymap)
        {
            if (Input.GetKeyDown(command.Key))
            {
                bool success = command.Execute(currentActor);
                if (success)
                {
                    commandHistory.Push(command);
                }
            }
        }
    }
    
    public void SwitchCharacter(bool reverse = false)
    {
        if (allActors.Count > 1)
        {
            int currentIndex = allActors.IndexOf(currentActor);
            currentIndex = (currentIndex + (reverse ? -1 : 1)) % allActors.Count;
            if (currentIndex < 0) currentIndex = allActors.Count-1;
            currentActor = allActors[currentIndex];
        }
    }

    public GridMovement getCurrentActor() 
    { 
        return currentActor;
    }
}


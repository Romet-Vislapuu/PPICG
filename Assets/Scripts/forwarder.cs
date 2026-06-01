using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class forwarder : MonoBehaviour
{
    private  Player currentPlayer;
    public  GameObject player1 = null;
    public GameObject player2 = null;
    private bool character = true;

    void Start()
    {
        currentPlayer = player1.GetComponent<Player>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSwitchChar()
    {
        if (character)
        {
            currentPlayer.SetMoveInput(Vector2.zero);
            currentPlayer = player2.GetComponent<Player>();
            character = false;
        }
        else {
            currentPlayer.SetMoveInput(Vector2.zero);
            currentPlayer = player1.GetComponentInParent<Player>();
            character = true;
        
        
        }

    }
    public void OnMove(InputValue value)
    {
        currentPlayer.SetMoveInput(value.Get<Vector2>());


    }

}

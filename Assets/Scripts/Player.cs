using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// https://learn.unity.com/course/using-the-input-system-in-unity/tutorial/scripting-player-movement-1
/// </summary>
public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;
    public float speed = 1;
 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        Debug.Log(gameObject.name);
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0.0f, moveInput.y);
        rb.linearVelocity=movement*speed;

    }
    public void SetMoveInput(Vector2 input) { 
        moveInput = input;
    
    }
}

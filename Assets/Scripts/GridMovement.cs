//GridMovement.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is reciever
public class GridMovement : MonoBehaviour
{
    [SerializeField] private float moveTime = 0.3f;
    [SerializeField] private AnimationCurve spacing;
    
    private bool isMoving;
    private Animator animator;
    private MapInfo map;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("y", -1);
        map = FindObjectOfType<MapInfo>();
    }

    private void Update()
        
    {
        /*
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            Walk(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Walk(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Walk(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Walk(Vector3.right);
        }
        */
    }
    // This is action
    public bool Walk(Vector3 direction)
    {
        if (isMoving) 
            return false;
    
        if (!IsPositionWalkable(transform.position + direction))
            return false;
        
        StartCoroutine(WalkCoroutine(direction, moveTime));
        return true;
    }

    private bool IsPositionWalkable(Vector3 pos)
    {
        if (Physics2D.OverlapPoint(pos) != null)
            return false;

        if (map != null)
        {
            return map.IsPositionInBounds(pos);
        }

        return true;
    }

    private IEnumerator WalkCoroutine(Vector3 direction, float duration)
    {
        Vector3 from = transform.position;
        Vector3 to = from + direction;

        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
        animator.SetFloat("speed", 1f);
        if (duration < float.Epsilon)
        {
            transform.position = to;
            yield break;
        }

        isMoving = true;
        float aggregate = 0;
        while (aggregate < 1f)
        {
            aggregate += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(from, to, spacing.Evaluate(aggregate));
            yield return null;
        }
        isMoving = false;
        animator.SetFloat("speed", 0f);
    }
}

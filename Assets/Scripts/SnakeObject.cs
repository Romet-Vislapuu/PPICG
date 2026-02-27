using System.Linq;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;

public class SnakeObject : MonoBehaviour
{
    private GridMovement snakeHead;
    private GridMovement[] snakeArray;
//(currentmove, repetitions) for each snake. Okay tuples suck, dont use
    private List<List<Vector3>> moveHistories = new List<List<Vector3>>();
    private List<int> pointers = new List<int>();

    public MonoBehaviour getHead() {
        return snakeHead;
    }

    //private int headPointer = 0;


    private void Awake()
    {
        snakeArray = GetComponentsInChildren<GridMovement>();
        System.Array.Sort(snakeArray, (a, b) => b.transform.position.x.CompareTo(a.transform.position.x));//higher x value, lower position in array
        snakeHead = snakeArray[0];
        Debug.Log("Head: "+snakeHead);
        for (int i = 0; i < snakeArray.Length; i++)
        {

            moveHistories.Add(new List<Vector3>());
            pointers.Add(0);

            //FML
            for (int j = 0; j < i; j++) {
                moveHistories[i].Add(Vector3.right);
            
            
            }

            //Debug.Log(movePerPart.Count);

        }


    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log(snakeHead.gameObject.name);


    }

    // Update is called once per frame
    void Update()
    {

    }
    /**
    public void SnakeWalk(Vector3 direction)
    {
        if (!snakeHead.Walk(direction))
            return;
        Debug.Log(direction);



        headPointer = headPointer + 1;
        movePerPart[0][0] = headPointer;
        movePerPart[0][1] = 0;
        if (moveHistories[0].Count > 1 && moveHistory[-1] != direction)
        {

        }



        for (int i = 1; i < movePerPart.Count; i++)
        {
            snakeArray[i].Walk(moveHistory[movePerPart[i][0]]);// Bruh
            movePerPart[i][1] = movePerPart[i][1] - 1;
            //Debug.Log(i);
            //Debug.Log(movePerPart[i][1]);
            //Debug.Assert(movePerPart[i][1] == -1);
            if (movePerPart[i][1] == -1)
            {
                //Debug.Log("asserted");
                movePerPart[i][0] = movePerPart[i][0] + 1;//move on to next move
                movePerPart[i][1] = i; // reset move counter
            }


        }
        moveHistory.Add(direction);







    }
    **/
    public void SnakeWalk2(Vector3 direction)
    {
        if (!snakeHead.Walk(direction))
            return;
        //Debug.Log(direction);
        pointers[0] = pointers[0] + 1;
        moveHistories[0].Add(direction);

        //Debug.Log(direction);
        
        if (false && moveHistories[0].Count >= 2 && moveHistories[0][moveHistories[0].Count-2] != direction)
        {
            Debug.Log("test");
            //Debug.Log(moveHistories[0][moveHistories.Count - 2]);
            //Debug.Log(moveHistories[0].Count);
            //Debug.Log(direction);
            //Debug.Log("went in loop");

            for (int i = 1; i < moveHistories.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    //Debug.Log(snakeArray[i] + "added " + 1);

                    //Debug.Log(moveHistories.Count);
                    moveHistories[i].Add(moveHistories[0][moveHistories[0].Count - 2]);
                }
            }
            //hasturned = true;
        }
        else
        {
            for (int i = 1; i < moveHistories.Count; i++)
            {
                moveHistories[i].Add(direction);
            }

            
 
        }
        for (int i = 1; i < moveHistories.Count; i++)
        {
            //Debug.Log(snakeArray[i]);
            snakeArray[i].Walk(moveHistories[i][pointers[i]]);
            pointers[i] = pointers[i] + 1;

        }
        //DebugArray();


    }

    public void SnakeWalk3(Vector3 direction) {
        if (!snakeHead.Walk(direction))
            return;
        //Debug.Log(direction);
        pointers[0] = pointers[0] + 1;
        moveHistories[0].Add(direction);
        // Eelmise viimane
        // pointers stored is empty value untill value added to history. because of that -1 to check last value walked.
        for (int i = 1; i < moveHistories.Count; i++) {

            //moveHistories[i].Add(moveHistories[i - 1][pointers[i - 1]]);
            // if the character ahead just executed a move that was a turn/axis change, . 
            if (moveHistories[i - 1].Count >= 2 && moveHistories[i - 1][pointers[i - 1]-1] != moveHistories[i - 1][pointers[i - 1]-2]) {
                moveHistories[i].Add(moveHistories[i - 1][pointers[i - 1]-2]);
            }
         
            moveHistories[i].Add(moveHistories[i - 1][pointers[i - 1]-1]);
            snakeArray[i].Walk(moveHistories[i][pointers[i]]);
            pointers[i]=pointers[i] + 1;
        }
        DebugArray();
    }

    public void SnakeWalk4(Vector3 direction)
    {
        if (!snakeHead.Walk(direction))
            return;
        //Debug.Log(direction);
        pointers[0] = pointers[0] + 1;
        moveHistories[0].Add(direction);

        for (int i = 1; i < moveHistories.Count; i++)
        {
            moveHistories[i].Add(direction);
        }
        for (int i = 1; i<moveHistories.Count; i++)
        {
            snakeArray[i].Walk(moveHistories[i][pointers[i]]);
            pointers[i] = pointers[i] + 1;

        }





    }
    private void DebugArray() {
        List<string >directions;

        //For each character
        for (int i = 0; i < moveHistories.Count; i++) { 
            Debug.Log(snakeArray[i]);
            Debug.Log("Pointer: " + pointers[i]+" ," + moveHistories[i][pointers[i]-1]);// Technically the pointer is +1 from last move.
            directions = new List<string>();
            for (int j = 0; j < moveHistories[i].Count; j++) {
                if (moveHistories[i][j] == Vector3.up)
                    directions.Add("UP");
                else if (moveHistories[i][j] == Vector3.down)
                    directions.Add("DOWN");
                else if (moveHistories[i][j] == Vector3.left)
                    directions.Add("LEFT");
                else if (moveHistories[i][j] == Vector3.right)
                    directions.Add("RIGHT");
            }
            Debug.Log("Contents: "+string.Join(", ",directions));
        }
        Debug.Log("----------------------------------------------------------------");
    }
}

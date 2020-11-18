using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector3 startPos = new Vector3(-6.5f,0.5f,0);         // where the player will spawn , need this for better game design later 
    public Vector2 dir;

    public Stack<Vector3> moves;

   

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
        dir = Vector2.zero;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        var before = new ObjectState(this.gameObject);

        // moving code 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        { 
            if (!BlockMove(transform.position , Vector3.right))
            {
                this.transform.position += new Vector3(1, 0, 0);                    //changes the transform

                var after = new ObjectState(this.gameObject);                       // creates an object state instance

                UndoIt.AddAction(new UndoableChangePlayer(before, after));          // add the the undoable change Player instance to a stack 
            }  
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) )
        {   
            if (!BlockMove(transform.position, Vector3.left))
            {
                this.transform.position += new Vector3(-1, 0, 0);

                var after = new ObjectState(this.gameObject);

                UndoIt.AddAction(new UndoableChangePlayer(before, after));
            }        
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) )
        {  
            if (!BlockMove(transform.position, Vector3.down))
            {
                this.transform.position += new Vector3(0, -1, 0);

                var after = new ObjectState(this.gameObject);

                UndoIt.AddAction(new UndoableChangePlayer(before, after));
            }         
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)  )
        {   
            if (!BlockMove(transform.position, Vector3.up))
            {
                this.transform.position += new Vector3(0, 1, 0);

                var after = new ObjectState(this.gameObject);

                UndoIt.AddAction(new UndoableChangePlayer(before, after));
            }             
        }
        
        

    }


   private bool BlockMove(Vector3 position,Vector3 direction)
   {
        Vector3 newPos = new Vector3(position.x, position.y,0) + direction;     // the new position 

        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");         // the walls of the level 

        foreach (var wall in walls)                                             // check if player hit walls    
        {
            
            if (wall.transform.position == newPos)
            {
                return true;
            }
            
        }

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("box");           // same functionalities but with boxes 
        foreach (var box in boxes)
        {
            if (box.transform.position == newPos)
            {
                Box bx = box.GetComponent<Box>();
                if (bx && bx.MoveBox(direction))
                {
                    
                    return false;
                }
                else 
                {
                    
                    return true;
                }
            }
            
        }
        
        return false;
   }

}

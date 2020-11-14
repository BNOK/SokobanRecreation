using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 startPos = new Vector3(-6.5f,0.5f,0);         // where the player will spawn , need this for better game design later 
    public Vector2 dir;

   

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
        // moving code 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        { 
            if (!BlockMove(transform.position , Vector3.right))
            {
                this.transform.position += new Vector3(1, 0, 0);
            }  
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) )
        {   
            if (!BlockMove(transform.position, Vector3.left))
            {
                this.transform.position += new Vector3(-1, 0, 0);
            }        
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) )
        {  
            if (!BlockMove(transform.position, Vector3.down))
            {
                this.transform.position += new Vector3(0, -1, 0);
            }         
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)  )
        {   
            if (!BlockMove(transform.position, Vector3.up))
            {
                this.transform.position += new Vector3(0, 1, 0);
                
            }             
        }
    }


   private bool BlockMove(Vector3 position,Vector3 direction)
   {
        Vector3 newPos = new Vector3(position.x, position.y,0) + direction;

        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall"); 

        foreach (var wall in walls)
        {
            
            if (wall.transform.position == newPos)
            {
                return true;
            }
            
        }

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("box");
        foreach (var box in boxes)
        {
            if (box.transform.position == newPos)
            {
                Box bx = box.GetComponent<Box>();
                if (bx && bx.MoveBox(direction))
                {
                    Debug.Log("false");
                    return false;
                }
                else 
                {
                    Debug.Log("true");
                    return true;
                }
            }
            
        }
        Debug.Log("false 02");
        return false;
   }

}

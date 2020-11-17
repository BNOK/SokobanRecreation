using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Stack<Vector3> boxmoves;

    private void Start()
    {
        boxmoves = new Stack<Vector3>();
    }

    public bool MoveBox(Vector3 directions)
    {
        if (BoxBlocked(directions))                                                                 //check if box is blocked or not to be able to move or not 
        {
            return false;
        }
        else
        {
            this.transform.position += directions;
            boxmoves.Push(this.transform.position);
            return true;
        }
       
    }

    public bool BoxBlocked(Vector2 directions)
    {
        Vector2 newPos = new Vector2(transform.position.x, transform.position.y) + directions;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");                             // check existing nearby walls

        foreach(var wall in walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
            
        }

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("box");                              // check if there is any nearby boxes
        foreach (var box in boxes)
        {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
            {
                return true;
            }
        }
            return false;
    }
   
}

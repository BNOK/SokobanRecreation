using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Box : MonoBehaviour
{
    private GameObject[] allBoxes;

    private void Start()
    {
        allBoxes = GameObject.FindGameObjectsWithTag("box");
    }

    public bool MoveBox(Vector3 directions)
    {
        var before = allBoxes.Select(obj => new ObjectState(obj)).ToList();
        if (BoxBlocked(directions))                                                                 //check if box is blocked or not to be able to move or not 
        {
            return false;
        }
        else
        {
            this.transform.position += directions;
            var after = allBoxes.Select(obj => new ObjectState(obj)).ToList();
            UndoIt.AddBoxAction(new UndoableChange(before, after));
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

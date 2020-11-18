using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour
{
    private GameObject[] boxes;
    public int score=0;


    private void Start()
    {
        boxes = GameObject.FindGameObjectsWithTag("box");
    }

    private void Update()
    {
        Check();
    }


    private void Check()
    {
        foreach(var box in boxes)
        {
            if (this.transform.position == box.transform.position)
            {
                score++;
                box.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                box.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

}

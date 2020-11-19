using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cross : MonoBehaviour
{
    // parametres
    private GameObject[] boxes;
    public int score=0;
    // colliders to check if boxes are touching 
    public Collider2D corss;
    public Collider2D box;



    private void Start()
    {
        boxes = GameObject.FindGameObjectsWithTag("box");
    }

    private void Update()
    {

    }


    

}

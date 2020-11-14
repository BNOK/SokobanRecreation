using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    private RaycastHit2D hits;

    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = Vector3.down;
            hits = Physics2D.Raycast(this.transform.position, dir, 1);
           
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = Vector3.right;
            hits = Physics2D.Raycast(this.transform.position, dir, 1);

        }
        Debug.DrawRay(this.transform.position, dir, Color.red);
        Debug.Log(hits.distance);
    }
}

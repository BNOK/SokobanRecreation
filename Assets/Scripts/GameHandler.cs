using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    private Player player;
    
    private List<GameObject> boxes;
    private List<GameObject> crosses;
    // UI PARAMETRES
    private int length;
    public Text scoreText;
    public Text playerMovement;
    private int score=0;
   


    // Start is called before the first frame update
    void Start()
    {
        boxes = GameObject.FindGameObjectsWithTag("box").ToList() ;
        crosses = GameObject.FindGameObjectsWithTag("cross").ToList();
        player = FindObjectOfType<Player>();
        length = boxes.Count;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckCross();
        playerMovement.text = player.GetComponent<Player>().mov.ToString();
    }

   

    private void CheckCross()
    {
        foreach(var cross in crosses)
        {
            foreach(var box in boxes)
            {
                if (cross.transform.position == box.transform.position)
                {
                    score++;
                    box.GetComponent<SpriteRenderer>().color = Color.red;
                    boxes.Remove(box);
                    crosses.Remove(cross);  
                }
                else
                {
                    box.GetComponent<SpriteRenderer>().color = Color.white;
                }
                scoreText.text = score + "/" + length;
            }
        }
    }
}

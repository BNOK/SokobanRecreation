using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;




public class LevelHandler : MonoBehaviour
{
    public LevelBuilder[] mappingData;
    public TextAsset mapText;

    private Vector2 currentPos = new Vector2(0,0);

    private void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        string[] maps = Regex.Split(mapText.text, ";");
    }

    private void BuildMap(string[] level)
    {
        string[] rows = Regex.Split(mapText.text, "\r\n|\r|\n|");

        foreach (string row in rows)
        {
            foreach(char c in row)
            {
                foreach(LevelBuilder lb in mappingData)
                {
                    if (c== lb.character)
                    {
                        Instantiate(lb.prefab, currentPos, Quaternion.identity);
       
                    }
                }
                currentPos = new Vector2(++currentPos.x, currentPos.y);
            }
            currentPos = new Vector2(0, --currentPos.y);
        }
    }

}

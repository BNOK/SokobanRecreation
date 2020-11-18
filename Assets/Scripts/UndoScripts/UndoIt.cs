using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoIt : MonoBehaviour
{
    private static Stack<UndoableChangePlayer> undoPlayer = new Stack<UndoableChangePlayer>();
    private static Stack<UndoableChange> undoBoxes = new Stack<UndoableChange>();


    public static void Undo()
    {
        if (undoPlayer.Count == 0 && undoBoxes.Count ==0) return;
        else if (undoPlayer.Count !=0 && undoBoxes.Count == 0)
        {
            var lastPlayerAction = undoPlayer.Pop();
            lastPlayerAction.Undo();
        }
        else
        {
            var lastAction = undoPlayer.Pop();
            var lastBoxAction = undoBoxes.Pop();

            lastAction.Undo();
            lastBoxAction.Undo();
        }
       
    }

    public static void AddAction( UndoableChangePlayer playerAction )
    {  
        
        undoPlayer.Push(playerAction);
    }

    public static void AddBoxAction(UndoableChange action)
    {
        undoBoxes.Push(action);
    }

    private void Update()
    {
        Debug.Log(undoBoxes.Count);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoIt : MonoBehaviour
{
    private static Stack<UndoableChange> undoStack = new Stack<UndoableChange>();


    public static void Undo()
    {
        if (undoStack.Count == 0) return;

        var lastAction = undoStack.Pop();

        lastAction.Undo();


    }

    public static void AddAction(UndoableChange action)
    {
        undoStack.Push(action);
    }

}

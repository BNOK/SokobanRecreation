using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UndoableChangePlayer
{
    private ObjectState _before;
    private ObjectState _after;



    public UndoableChangePlayer(ObjectState before, ObjectState after)
    {
        _before = before;
        _after = after;
    }

    public void Undo()
    {
        _before.Apply();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UndoableChange
{
    private List<ObjectState> _before;
    private List<ObjectState> _after;

   

    public UndoableChange(List<ObjectState> before, List<ObjectState> after)
    {
        _before = before;
        _after = after;
    }

    public void Undo()
    {
        foreach (var state in _before)
        {
            state.Apply();
        }
    } 
}
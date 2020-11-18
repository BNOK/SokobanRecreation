using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ObjectState
{ 

    // The transform this data belongs to
    private Transform transform;

    private Vector3 localPosition;
    
    

    public ObjectState(GameObject obj)
    {
        transform = obj.transform;
        localPosition = obj.transform.localPosition;
       
    }

    public void Apply()
    {
        transform.localPosition = localPosition;
       
    }
}

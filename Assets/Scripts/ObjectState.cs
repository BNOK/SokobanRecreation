using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ObjectState
{ 

        // The transform this data belongs to
        private Transform transform;

    private Vector3 localPosition;
    private Quaternion localRotation;
    private Vector3 localScale;

    private bool active;

    public ObjectState(GameObject obj)
    {
        transform = obj.transform;
        localPosition = transform.localPosition;
        localRotation = transform.localRotation;
        localScale = transform.localScale;

        active = obj.activeSelf;
    }

    public void Apply()
    {
        transform.localPosition = localPosition;
        transform.localRotation = localRotation;
        transform.localScale = localScale;

        transform.gameObject.SetActive(active);
    }
}

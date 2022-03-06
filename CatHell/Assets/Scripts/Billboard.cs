using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera _cameraToLookAt;

    private void Start()
    {
        _cameraToLookAt = Camera.main;
    }

    void Update()
    {
        if (_cameraToLookAt == null)
            return;
        
        Vector3 v = _cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(_cameraToLookAt.transform.position - v);
    }
}

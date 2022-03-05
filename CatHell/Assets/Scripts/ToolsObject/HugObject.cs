using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugObject : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    public Animator Animator;

    private void Update()
    {
        transform.GetChild(0).position = _camera.transform.position;
        transform.GetChild(0).rotation = _camera.transform.rotation;
    }
}

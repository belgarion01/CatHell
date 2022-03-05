using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicGunObject : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _muzzle;

    public Transform Muzzle => _muzzle;
    public Camera Camera => _camera;
    private void Update()
    {
        transform.GetChild(0).position = _camera.transform.position;
        transform.GetChild(0).rotation = _camera.transform.rotation;
    }
}

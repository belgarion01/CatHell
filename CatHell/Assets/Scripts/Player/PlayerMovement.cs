using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    
    private float _hAxis;
    private float _vAxis;
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _hAxis = Input.GetAxisRaw("Horizontal");
        _vAxis = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 translation = new Vector3(_hAxis, 0, _vAxis) * _movementSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + translation);
    }
}

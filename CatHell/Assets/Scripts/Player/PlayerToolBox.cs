using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerToolBox : MonoBehaviour
{
    [SerializeField] private Tool _startingTool;
    [SerializeField] private InputAction _useAction;
    private Tool _currentTool;

    private void Start()
    {
        _currentTool = _startingTool;

        _useAction.performed += context => _currentTool.OnUseDown(gameObject);
        _useAction.canceled += context => _currentTool.OnUseUp(gameObject);
        _useAction.Enable();
    }

    private void Update()
    {
        if (_currentTool != null)
        {
            _currentTool.OnTick(gameObject);
        }
    }
}

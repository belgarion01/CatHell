using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] [FoldoutGroup("Setup")]
    private CharacterController _controller;
    
    private Inputs_Mapping _inputs;
    
    private Vector2 _inputMovement;
    void Start()
    {
        _inputs = new Inputs_Mapping();
        _inputs.Enable();
    }

    void Update()
    {
        if (GameManager.Instance.IsGamePaused)
            return;
        
        _inputMovement = _inputs.Main.Move.ReadValue<Vector2>();
        Vector3 translationDirection = transform.forward*_inputMovement.y + transform.right*_inputMovement.x;
        translationDirection.y = -_gravity;
        Vector3 translation = translationDirection * _movementSpeed;
        _controller.SimpleMove(translation);
    }
}

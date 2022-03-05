using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLooker : MonoBehaviour
{
    [SerializeField] private float _mouseSensibility = 0.01f;
    
    [SerializeField] [FoldoutGroup("Setup")]
    private InputAction _lookBinding;
    [SerializeField] [FoldoutGroup("Setup")]
    private Transform _playerTransform;
    [SerializeField] [FoldoutGroup("Setup")]
    private Transform _cameraTransform;

    
    
    private float x;

    void Start()
    {
        _lookBinding.Enable();

        DisableCursor();
        
        GameManager.Instance.OnGameOver.AddListener(EnableCursor);
    }
    void Update()
    {
        if (GameManager.Instance.IsGamePaused)
            return;
        
        Vector2 mouseDelta = _lookBinding.ReadValue<Vector2>() * _mouseSensibility;
        _playerTransform.Rotate(Vector3.up, mouseDelta.x);

        x -= mouseDelta.y;
        float cameraAngle = Mathf.Clamp(x, -85, 85);
        _cameraTransform.localRotation = Quaternion.Euler(new Vector3(cameraAngle, 0, 0));
    }

    private void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

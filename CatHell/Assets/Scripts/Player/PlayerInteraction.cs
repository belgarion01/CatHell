using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private InputAction _interactAction;
    [SerializeField] private InteractableWidget _interactableWidget;

    public IInteractable TargetInteractable { get; private set; }

    private void Start()
    {
        _interactAction.performed += ctx => TargetInteractable?.Interact(gameObject);
        _interactAction.Enable();
    }

    void Update()
    {
        TargetInteractable = null;
        
        RaycastHit hit;
        if (Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out hit))
        {
            if (hit.transform.TryGetComponent(out IInteractable interactable))
            {
                TargetInteractable = interactable;
                _interactableWidget.UpdateUI(TargetInteractable);
            }
        }
        
        _interactableWidget.SetEnable(TargetInteractable != null);
    }
}

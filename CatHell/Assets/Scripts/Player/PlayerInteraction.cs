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
    [SerializeField] private Transform _bottomPlayer;
    public bool IsHoldingObject => _currentHoldableObject != null;
    private IHoldable _currentHoldableObject;
    public IInteractable TargetInteractable { get; private set; }

    private void Start()
    {
        _interactAction.performed += ctx => CheckInteractionPlayer();
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

    void CheckInteractionPlayer()
    {
        if (IsHoldingObject)
        {
            DropHoldableObject(_currentHoldableObject);
        }
        else
        {
            TargetInteractable?.Interact(gameObject);
        }
    }
    
   public void TakeHoldableObject(IHoldable holdable)
   {
       _currentHoldableObject = holdable;
       _currentHoldableObject.OnTake(gameObject);
       transform.SetParent(Camera.main.transform);
       transform.localPosition = holdable.offset;
   }

   public void DropHoldableObject(IHoldable holdable)
   {
       _currentHoldableObject.OnDrop(gameObject);
      MonoBehaviour holdableMono = holdable as MonoBehaviour;
      holdableMono.transform.SetParent(null);
      holdableMono.transform.position = _bottomPlayer.position;
      _currentHoldableObject = null;
   }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerToolBox : MonoBehaviour
{
    [SerializeField] private Tool _startingTool;
    public List<Tool> Tools = new List<Tool>();
    [SerializeField] private InputAction _useAction;
    [SerializeField] private InputAction _scrollAction;
    public Tool CurrentTool => CurrentToolIndex >= Tools.Count ? null : Tools[CurrentToolIndex];
    public int CurrentToolIndex { get; private set; }
    public UnityEvent<int> OnToolSelected;

    private void Start()
    {
        SelectTool(_startingTool);

        _useAction.performed += context => CurrentTool.OnUseDown(gameObject);
        _useAction.canceled += context => CurrentTool.OnUseUp(gameObject);
        _useAction.Enable();

        _scrollAction.performed += ScrollPerformed;
        _scrollAction.Enable();
    }

    private void Update()
    {
        if (CurrentTool != null)
        {
            CurrentTool.OnTick(gameObject);
        }
    }

    public void ScrollPerformed(InputAction.CallbackContext ctx)
    {
        float scrollValue = ctx.ReadValue<float>();
        if (scrollValue < 0)
        {
            SelectNextTool();
        }
        else if (scrollValue > 0)
        {
            SelectPreviousTool();
        }
    }

    public void SelectNextTool()
    {
        int newIndex = CurrentToolIndex + 1;
        if (newIndex >= Tools.Count)
        {
            newIndex = 0;
        }
        
        SelectTool(newIndex);
    }

    public void SelectPreviousTool()
    {
        int newIndex = CurrentToolIndex - 1;
        if (newIndex < 0)
        {
            newIndex = Tools.Count - 1;
        }
        
        SelectTool(newIndex);
    }

    public void SelectTool(Tool tool)
    {
        for (int i = 0; i < Tools.Count; i++)
        {
            if (Tools[i] == tool)
            {
                CurrentToolIndex = i;
                break;
            }
        }
        
        CurrentTool.OnEquip(gameObject);
        OnToolSelected?.Invoke(CurrentToolIndex);
    }

    public void SelectTool(int toolIndex)
    {
        CurrentToolIndex = toolIndex;
        
        CurrentTool.OnEquip(gameObject);
        OnToolSelected?.Invoke(CurrentToolIndex);
    }
}

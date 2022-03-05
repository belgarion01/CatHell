using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Toolbar : MonoBehaviour
{
    [SerializeField] private ToolbarBox _toolbarBoxPrefab;
    [SerializeField] private PlayerToolBox _playerToolBox;
    private List<ToolbarBox> _toolbarBoxes = new List<ToolbarBox>();

    

    private void Start()
    {
        _playerToolBox.OnToolSelected.AddListener(OnToolSelected);

        for (int i = 0; i < _playerToolBox.Tools.Count; i++)
        {
            Tool tool = _playerToolBox.Tools[i];
            ToolbarBox tbb = Instantiate(_toolbarBoxPrefab, transform);
            tbb.Init(tool, i);
            _toolbarBoxes.Add(tbb);
        }
    }
    
    private void OnToolSelected(int toolIndex)
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < _toolbarBoxes.Count; i++)
        {
            _toolbarBoxes[i].SetSelected(i == _playerToolBox.CurrentToolIndex);
        }
    }
}

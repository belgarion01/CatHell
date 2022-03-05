using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsAnimation : MonoBehaviour
{
    [SerializeField] private PlayerToolBox _playerToolBox;
    
    [SerializeField] private Animator _cleanerAnimator;
    [SerializeField] private Animator _medicGunAnimator;

    public Animator CleanerAnimator => _cleanerAnimator;
    public Animator MedicGunAnimator => _medicGunAnimator;

    private void Awake()
    {
        _playerToolBox.OnToolSelected.AddListener(OnToolSelected);
    }

    private void OnToolSelected(int toolIndex)
    {
        List<Animator> toolList = new List<Animator>()
        {
            _cleanerAnimator,
            _medicGunAnimator
        };

        for (int i = 0; i < toolList.Count; i++)
        {
            toolList[i].gameObject.SetActive(i == toolIndex);
        }
    }
}

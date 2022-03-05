using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsAnimation : MonoBehaviour
{
    [SerializeField] private PlayerToolBox _playerToolBox;
    
    [SerializeField] private Animator _cleanerAnimator;
    [SerializeField] private Animator _medicGunAnimator;
    [SerializeField] private Animator _hugAnimator;

    public Animator CleanerAnimator => _cleanerAnimator;
    public Animator MedicGunAnimator => _medicGunAnimator;

    public Animator HugAnimator => _hugAnimator;

    private void Awake()
    {
        _playerToolBox.OnToolSelected.AddListener(OnToolSelected);
    }

    private void OnToolSelected(int toolIndex)
    {
        List<Animator> toolList = new List<Animator>()
        {
            _cleanerAnimator,
            _medicGunAnimator,
            _hugAnimator
        };

        for (int i = 0; i < toolList.Count; i++)
        {
            toolList[i].gameObject.SetActive(i == toolIndex);
        }
    }
}

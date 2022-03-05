using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaosGauge : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.maxValue = GameManager.Instance.MaxChaosGauge;
        _slider.value = GameManager.Instance.MaxChaosGauge;
        GameManager.Instance.OnChaosChanged.AddListener(OnChaosChanged);
    }

    private void OnChaosChanged(float newChaos)
    {
        _slider.value = newChaos;
    }
}

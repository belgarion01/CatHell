using System;
using System.Collections;
using System.Collections.Generic;
using Shapes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChaosGauge : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Line _lineFill;
    [SerializeField] private TextMeshProUGUI _numberOfMutatedTextMesh;

    private float _maxChaos;

    private void Start()
    {
        _slider.maxValue = GameManager.Instance.MaxChaosGauge;
        _slider.value = GameManager.Instance.MaxChaosGauge;
        _maxChaos = GameManager.Instance.MaxChaosGauge;
        GameManager.Instance.OnChaosChanged.AddListener(OnChaosChanged);
    }

    private void Update()
    {
        _numberOfMutatedTextMesh.text = GameManager.Instance.MutatedCatsInHouse.ToString() + "x";
    }

    private void OnChaosChanged(float newChaos)
    {
        _slider.value = newChaos;
        float x = Mathf.Lerp(_lineFill.Start.x, -_lineFill.Start.x, Mathf.InverseLerp(0, _maxChaos, newChaos));
        _lineFill.End = new Vector3(x, _lineFill.End.y, _lineFill.End.z);
    }
}

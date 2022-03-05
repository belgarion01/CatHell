using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationGauge : MonoBehaviour
{
    [SerializeField] private MutationCat _mutationCat;
    [SerializeField] private Shapes.Disc _fillDisc;

    [SerializeField] private float _maxAngle;
    [SerializeField] private Color _startColor = Color.green;
    [SerializeField] private Color _endColor = Color.magenta;

    [Range(0f, 1f)]
    [SerializeField] private float percent = 0f;
    private void Awake()
    {
        _mutationCat.OnMutationChanged.AddListener(OnMutationChanged);
    }

    private void Start()
    {
        OnMutationChanged(_mutationCat.MutationPercentage);
    }

    private void OnMutationChanged(float mutationPercent)
    {
        float angle = Mathf.Lerp(0f, _maxAngle, mutationPercent);
        _fillDisc.AngRadiansEnd = Mathf.Deg2Rad * angle;
        _fillDisc.Color = Color.Lerp(_startColor, _endColor, mutationPercent);
    }
}

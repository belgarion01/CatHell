using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurChaos : MonoBehaviour
{
    [SerializeField] private Cat _cat;
    [SerializeField] private LayerMask _furLayerMask;
    [SerializeField] private float _chaosPerFur;
    [SerializeField] private float _overlapRadius;
    private void Update()
    {
        var furCount = Physics.OverlapSphereNonAlloc(transform.position, _overlapRadius, new Collider[20], _furLayerMask);
        if (_cat != null)
        {
            //GenerateChaos per cat
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _overlapRadius);
    }
}

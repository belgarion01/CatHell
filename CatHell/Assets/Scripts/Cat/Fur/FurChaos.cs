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
        var furCount = Physics.OverlapSphereNonAlloc(transform.position, _overlapRadius, new Collider[20], _furLayerMask) - 1;
        furCount = Mathf.Max(0, furCount);
        if (_cat != null)
        {
            _cat.Mutation.AddMutation(_chaosPerFur*furCount*Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _overlapRadius);
    }
}

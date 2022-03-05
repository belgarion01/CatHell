using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy = 2f;
    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}

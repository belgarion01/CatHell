using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerObject : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _vacuumOrigin;

    public Transform VacuumOrigin => _vacuumOrigin;
}

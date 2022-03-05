using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fur : MonoBehaviour, IVacuumable
{
    public void OnVacuumed()
    {
        Destroy(gameObject);
    }
}

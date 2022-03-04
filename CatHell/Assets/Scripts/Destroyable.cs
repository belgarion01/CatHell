using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour, IDestroyable, IInteractable
{
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void Interact(GameObject user)
    {
        Destroy(gameObject);
    }
}

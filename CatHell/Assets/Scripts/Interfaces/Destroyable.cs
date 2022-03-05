
using UnityEngine;

public class Destroyable : MonoBehaviour, IDestroyable, IInteractable, IVacuumable
{
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void Interact(GameObject user)
    {
        DestroyObject();
    }

    public string ActionName => "Destroy Sphere";
    public void OnVacuumed()
    {
        DestroyObject();
    }
}

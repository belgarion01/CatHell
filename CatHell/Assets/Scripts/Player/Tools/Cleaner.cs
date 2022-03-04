using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MENU_PATH + "Cleaner")]
public class Cleaner : Tool
{
    private bool _active = false;
    
    public override void OnUseDown(GameObject player)
    {
        _active = true;
    }

    public override void OnTick(GameObject player)
    {
        if (!_active) return;

        Vector3 cameraPosition = Camera.main.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(cameraPosition, Camera.main.transform.forward, out hit))
        {
            if (hit.transform.TryGetComponent(out IDestroyable destroyable))
            {
                destroyable.DestroyObject();
            }
        } 
    }

    public override void OnUseUp(GameObject player)
    {
        _active = false;
    }
}

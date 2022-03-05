using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MENU_PATH + "Cleaner")]
public class Cleaner : Tool
{
    private CleanerObject _cleaner;
    private bool _active = false;
    
    public override void OnUseDown(GameObject player)
    {
        _active = true;
        var toolsAnimation = player.GetComponentInChildren<ToolsAnimation>();
        if (toolsAnimation != null)
        {
            toolsAnimation.CleanerAnimator.SetBool("On", true);
        }
    }

    public override void OnTick(GameObject player)
    {
        if (!_active) return;
        
        var colliders = Physics.OverlapSphere(_cleaner.VacuumOrigin.position, 1);
        foreach (Collider collider in colliders)
        {
            if (collider.transform.TryGetComponent(out IVacuumable vacuumable))
            {
                vacuumable.OnVacuumed();
            }
        }
    }

    public override void OnUseUp(GameObject player)
    {
        _active = false;
        
        var toolsAnimation = player.GetComponentInChildren<ToolsAnimation>();
        if (toolsAnimation != null)
        {
            toolsAnimation.CleanerAnimator.SetBool("On", false);
        }
    }

    public override void OnEquip(GameObject player)
    {
        if (_cleaner == null)
        {
            _cleaner = player.GetComponentInChildren<CleanerObject>();
        }
    }
}

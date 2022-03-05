using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MENU_PATH + "Hug")]
public class Hug : Tool
{
    [SerializeField] private float _hugMaxDistance = 15f;
    
    private HugObject _hugObject;
    private Camera _camera;
    private IHugable _targetHugable;
    
    public override void OnUseDown(GameObject player)
    {
        if (_targetHugable != null)
        {
            _targetHugable.Hug(player);
        }
    }

    public override void OnTick(GameObject player)
    {
        _targetHugable = null;
        
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _hugMaxDistance))
        {
            if (hit.collider.TryGetComponent(out IHugable hugable))
            {
                _targetHugable = hugable;
            }
        }
        
        _hugObject.Animator.SetBool("On", _targetHugable != null);
    }

    public override void OnUseUp(GameObject player)
    {
        
    }

    public override void OnEquip(GameObject player)
    {
        if (_hugObject == null)
        {
            _hugObject = player.GetComponentInChildren<HugObject>(true);
        }

        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }
}

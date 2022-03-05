using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Shapes;
using UnityEngine;

[CreateAssetMenu(menuName = MENU_PATH + "MedicGun")]
public class MedicGun : Tool
{
    private MedicGunObject _medicGunObject;
    [SerializeField] private Line _rayFeedback;
    public override void OnUseDown(GameObject player)
    {
        RaycastHit hit;
        if (Physics.Raycast(_medicGunObject.Camera.transform.position, _medicGunObject.Camera.transform.forward,
            out hit))
        {
            if (hit.transform.TryGetComponent<IShootable>(out IShootable shootable))
            {
                shootable.OnShoot(player);
            }
            
            Line lr = Instantiate(_rayFeedback);
            lr.Start = _medicGunObject.Muzzle.position;
            lr.End = hit.point;
        }
    }

    public override void OnTick(GameObject player)
    {
        
    }

    public override void OnUseUp(GameObject player)
    {
        
    }

    public override void OnEquip(GameObject player)
    {
        if (_medicGunObject == null)
        {
            _medicGunObject = player.GetComponentInChildren<MedicGunObject>(true);
        }
    }
}

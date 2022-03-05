using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MENU_PATH + "MedicGun")]
public class MedicGun : Tool
{
    private MedicGunObject _medicGunObject;
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
            Debug.DrawLine(_medicGunObject.Muzzle.position, hit.point, Color.red, 1.5f);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHoldable
{
    public void OnTake(GameObject user);
    public void OnDrop(GameObject user);
}

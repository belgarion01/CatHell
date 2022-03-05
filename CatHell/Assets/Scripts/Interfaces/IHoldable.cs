using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHoldable
{ 
   public Vector3 offset { get; }
   
   public bool isHoldable { get; }
    public void OnTake(GameObject user);
    public void OnDrop(GameObject user);
}

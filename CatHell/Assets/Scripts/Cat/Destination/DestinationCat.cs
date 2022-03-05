using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class DestinationCat : SerializedMonoBehaviour
{
 public static DestinationCat instance;
 private void Awake()
 {
  if (instance == null)
   instance = this; 
 }
 public Dictionary<DestinationCatEnum, Transform> destinationCatClassDic;

}

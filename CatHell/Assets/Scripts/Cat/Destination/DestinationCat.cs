using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class DestinationCat : SerializedMonoBehaviour
{
 public static DestinationCat instance;
 public Transform[] spawnerCatList;
 private void Awake()
 {
  if (instance == null)
   instance = this;
 }
 public Dictionary<DestinationCatEnum, Transform> destinationCatClassDic;

}

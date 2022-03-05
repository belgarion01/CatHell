using System;
using Sirenix.OdinInspector;
using UnityEngine;
[Serializable]
public class StateCatDestination : StateCatProbability
{ 
    public  DestinationCatEnum destinationCatEnum; 
    [FoldoutGroup("Debug")]
    public Transform destination; 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FurMutation", menuName = "Mutation/FurMutation")]
public class FurMutationScriptable : MutationScriptable
{
    public float TimeBetweenGeneration;
    public override void Mutate(Cat cat)
    {
        base.Mutate(cat);
        FurGenerator furGenerator = cat.GetComponent<FurGenerator>();
        furGenerator.TimeBetweenGeneration = TimeBetweenGeneration;
    }
}

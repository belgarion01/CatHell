using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TPMutation", menuName = "Mutation/TPCat")]
public class TPMutationScriptable : MutationScriptable
{
    public override void Mutate(Cat cat)
    {
        base.Mutate(cat);
        cat.gameObject.AddComponent<TPCat>();
    }
}

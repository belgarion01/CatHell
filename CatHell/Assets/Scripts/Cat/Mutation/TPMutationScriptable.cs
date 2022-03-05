using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMutationScriptable : MutationScriptable
{
    public override void Mutate(Cat cat)
    {
        base.Mutate(cat);
        cat.gameObject.AddComponent<TPCat>();
    }
}

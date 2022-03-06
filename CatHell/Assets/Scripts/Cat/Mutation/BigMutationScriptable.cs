using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BigMutation", menuName = "Mutation/BigMutation")]
public class BigMutationScriptable : MutationScriptable
{
    public float Speed;
    public float AngularSpeed;
    public Vector3 Offset;

    public override void Mutate(Cat cat)
    {
        base.Mutate(cat);
        cat.IsHoldableCat = false;
        cat.Speed = Speed;
        cat.AngularSpeed = AngularSpeed;
        cat.OffsetCat = Offset;
        cat.SkinnedMeshRenderer.transform.parent.localScale *= 3f;
    }
}

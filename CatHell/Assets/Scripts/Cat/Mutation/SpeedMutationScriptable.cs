using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SpeedMutation", menuName = "Mutation/SpeedMutation")]
public class SpeedMutationScriptable : MutationScriptable
{
    public float Speed;
    public float AngularSpeed;
    public override void Mutate(Cat cat)
    {
        base.Mutate(cat);
        cat.Speed = Speed;
        cat.gameObject.AddComponent<TPCat>();
        cat.AngularSpeed = AngularSpeed;
    }
}

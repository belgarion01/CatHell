using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class MutationScriptable : ScriptableObject
{
    public Mesh mutateMesh;
    public RuntimeAnimatorController MutateAnimatorController;

    public virtual void Mutate(Cat cat)
    {
    
        cat.SkinnedMeshRenderer.sharedMesh = mutateMesh;
        if(MutateAnimatorController != null)
        cat.Animator.runtimeAnimatorController = MutateAnimatorController;
        cat.Machine.SetState(StateCatEnum.Idle);
    }
}

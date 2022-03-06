using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class MutationScriptable : ScriptableObject
{
    public Mesh mutateMesh;
    public RuntimeAnimatorController MutateAnimatorController;
    public Material Material;

    public virtual void Mutate(Cat cat)
    {
    
        cat.SkinnedMeshRenderer.sharedMesh = mutateMesh;
        cat.SkinnedMeshRenderer.material = Material;
        if(MutateAnimatorController != null)
        cat.Animator.runtimeAnimatorController = MutateAnimatorController;
        cat.Machine.SetState(StateCatEnum.Idle);
    }
}

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
        cat.Animator.runtimeAnimatorController = MutateAnimatorController;
    }
}

using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour, IHoldable, IInteractable, IShootable 
{
    public MachineCat Machine;
    public MutationCat Mutation;
    public Animator Animator;
    public MeshFilter MeshFilter;
    public NavMeshAgent Agent;
    // Start is called before the first frame update

    [Button]
    public void SetCat()
    {
        Machine = GetComponent<MachineCat>();
        Mutation = GetComponent<MutationCat>();
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        MeshFilter = GetComponent<MeshFilter>();
    }
    public void OnTake(GameObject user)
    {
      
    }

    public void OnDrop(GameObject user)
    {
       
    }

    public void Interact(GameObject user)
    {
       
    }

    public string ActionName { get; }


    public void OnShoot(GameObject shooter)
    {
        
    }
}

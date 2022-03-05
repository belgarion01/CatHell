
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


    public void OnValidate()
    {
        if(Machine == null)
        Machine = GetComponent<MachineCat>();
        if(Mutation == null)
        Mutation = GetComponent<MutationCat>();
        if(Animator == null)
        Animator = GetComponent<Animator>();
        if(Agent == null)
        Agent = GetComponent<NavMeshAgent>();
        if(MeshFilter == null)
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

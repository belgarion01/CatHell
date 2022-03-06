
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Cat : MonoBehaviour, IHoldable, IInteractable, IShootable, IHugable
{
    [SerializeField] private float _hugMaxMutationDecrease = 5f;
    
    public float Speed;
    public float AngularSpeed;
    public MachineCat Machine;
    public MutationCat Mutation;
    public Animator Animator;
    public SkinnedMeshRenderer SkinnedMeshRenderer;
    public NavMeshAgent Agent;
    public float mutationShootFailure;
    public UnityEvent ShootSuccessEvent;
    public UnityEvent ShootFailureEvent;
    public UnityEvent OnHug;

    private float _lastHugTime = -10f;
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
        if(SkinnedMeshRenderer == null)
        SkinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }
    public Vector3 OffsetCat;
    public bool IsHoldableCat = true;
    public Vector3 offset { get => OffsetCat; }
    public bool isHoldable { get => IsHoldableCat; }

    private void Start()
    {
        GameManager.Instance.SubscribeCat(this);
    }

    public void OnTake(GameObject user)
    {
        if(!Agent.isStopped)
        Agent.isStopped = true;
        Agent.enabled = false;
        Machine.enabled = false; 
    }

    public void OnDrop(GameObject user)
    {
       
        Machine.enabled = true;
        Agent.enabled = true;
        if(Agent.isStopped)
        Agent.isStopped = false;
        Machine.SetState(StateCatEnum.Idle);
    }

    public void Interact(GameObject user)
    {
       user.GetComponent<PlayerInteraction>().TakeHoldableObject(this);
    }

    public string ActionName { get; }


    public void OnShoot(GameObject shooter)
    {
        if (Machine.CurrentStateCat.StateCatEnum == StateCatEnum.Sick)
        {
            Machine.SetState(StateCatEnum.Idle);
            ShootSuccessEvent?.Invoke();
        }
        else
        {
            Mutation.CurrentMutation += mutationShootFailure;
            ShootFailureEvent?.Invoke();
        }
    }

    public void Hug(GameObject huger)
    {
        _lastHugTime = Time.time;
        float decreaseMutation = Mathf.Lerp(_hugMaxMutationDecrease, 0,
            Mathf.InverseLerp(_lastHugTime, _lastHugTime + 5f, Time.time - _lastHugTime));
        Mutation.AddMutation(-decreaseMutation);
        OnHug?.Invoke();
    }
}

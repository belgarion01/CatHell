
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Cat : MonoBehaviour, IHoldable, IInteractable, IShootable, IHugable
{
    [SerializeField] private float _hugMaxMutationDecrease = 5f;
 public GameObject SickBubbleEffect;
 public  GameObject ScratchEffect;
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

    public bool IsHeld
    {
        get => isHeld;
        set { isHeld = value; }
    }

    [FormerlySerializedAs("_isHolded")] public bool isHeld;

    private void Start()
    {
        Agent.updateRotation = true;
        GameManager.Instance.SubscribeCat(this);
    }

    public void OnTake(GameObject user)
    {
        if(!Agent.isStopped)
        Agent.isStopped = true;
        Agent.enabled = false;
        transform.LookAt(user.transform, Vector3.up);
        Machine.enabled = false; 
        AnimSetHeld(true);
    }

    public void OnDrop(GameObject user)
    {
       
        Machine.enabled = true;
        Agent.enabled = true;
        if(Agent.isStopped)
        Agent.isStopped = false;
        Machine.SetState(StateCatEnum.Idle);
        AnimSetHeld(false);
    }

    public void Interact(GameObject user)
    {
        if(IsHoldableCat)
       user.GetComponent<PlayerInteraction>().TakeHoldableObject(this);
    }

    public string ActionName { get; }


    public void OnShoot(GameObject shooter)
    {
        if (Machine.CurrentStateCat.StateCatEnum == StateCatEnum.Sick)
        {
            Machine.SetState(StateCatEnum.Idle);
            SickBubbleEffect.SetActive(false);
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

    public void AnimSetIdle()
    {
        Animator.SetBool("Walking", false);
    }

    public void AnimSetWalking()
    {
        Animator.SetBool("Walking", true);
    }

    public void AnimSetHeld(bool held)
    {
        Animator.SetBool("Held", held);
    }

    public void AnimSetDisco(bool enable)
    {
        Animator.SetBool("Disco", enable);
    }
}


using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class MutationCat : MonoBehaviour
{
    private Cat _cat;
    public bool IsMutated => MutateCat != null;
    [SerializeField] float _maxMutation;
    private float _currentMutation;
    public List<StateCat> MutateStateAddList;
    public Cat MutateCat;
    public float MutationPercentage => Mathf.InverseLerp(0f, _maxMutation, _currentMutation);
    public float CurrentMutation
    {
        get
        {
            return _currentMutation;
        }
        set
        {
            float oldMutation = _currentMutation;
            _currentMutation = value;
            if (_currentMutation == _maxMutation)
            {
                _cat.Animator.runtimeAnimatorController = MutateCat.Animator.runtimeAnimatorController;
                _cat.MeshFilter.mesh = MutateCat.MeshFilter.mesh;
                _cat.OffsetCat = MutateCat.OffsetCat;
                _cat.mutationShootFailure = MutateCat.mutationShootFailure;
                _cat.ShootSuccessEvent = MutateCat.ShootSuccessEvent;
                _cat.ShootFailureEvent = MutateCat.ShootFailureEvent;

                foreach (var stateCat in _cat.Machine.StateCatList) { stateCat.ToMutation(); }
                
                for (int i = 0; i < MutateStateAddList.Count; i++)
                {
                    StateCat stateCat = (StateCat) gameObject.AddComponent(MutateStateAddList[i].GetType());
                    stateCat.MutationState = MutateStateAddList[i];
                    stateCat.ToMutation();
                    stateCat.MutationState = MutateStateAddList[i].MutationState;
                }
                _cat.Machine.StateCatList.AddRange(MutateStateAddList);
            }

            if (!oldMutation.Equals(_currentMutation))
            {
                OnMutationChanged?.Invoke(MutationPercentage);
            }
        }
    }

    public UnityEvent<float> OnMutationChanged;

    private void OnValidate()
    {
        if(_cat == null)
        _cat = GetComponent<Cat>();
    }
    

}

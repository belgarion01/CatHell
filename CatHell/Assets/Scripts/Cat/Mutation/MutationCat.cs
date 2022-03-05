
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class MutationCat : MonoBehaviour
{
    private Cat _cat;
    public MutationScriptable MutationScriptable;
    public bool IsMutated;
    [SerializeField] float _maxMutation;
    private float _currentMutation;
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
            _currentMutation = Mathf.Clamp(value,0, _maxMutation);
            if (IsMutated)
                return;
            if (_currentMutation == _maxMutation)
            {
              MutationScriptable.Mutate(_cat);
              IsMutated = true;
            }

            if (!oldMutation.Equals(_currentMutation))
            {
                OnMutationChanged?.Invoke(MutationPercentage);
            }
        }
    }

    public void AddMutation(float amount) => CurrentMutation += amount;

    public UnityEvent<float> OnMutationChanged;

    private void OnValidate()
    {
        if(_cat == null)
        _cat = GetComponent<Cat>();
    }
    

}

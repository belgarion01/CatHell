
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class MutationCat : MonoBehaviour
{
    private Cat _cat;
    public MutationScriptable[] MutationScriptableList;
    public bool IsMutated;
    [SerializeField] float _maxMutation;
    private float _currentMutation;
    public float MutationPercentage => Mathf.InverseLerp(0f, _maxMutation, _currentMutation);

    [SerializeField] private float _mutatationChaosFactor;
    public float CurrentMutation
    {
        get
        {
            return _currentMutation;
        }
        set
        {
            float oldMutation = _currentMutation;
            
            if (IsMutated)
            {
                _currentMutation = value;
               GameManager.Instance.SubstractChaos(_mutatationChaosFactor*(oldMutation-_currentMutation));
               return;
            }
               _currentMutation = Mathf.Clamp(value,0, _maxMutation);
            if (_currentMutation == _maxMutation)
            {
                int rand = Random.Range(0, MutationScriptableList.Length);
              MutationScriptableList[rand].Mutate(_cat);
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

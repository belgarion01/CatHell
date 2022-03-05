using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class MutationCat : MonoBehaviour
{
   [ReadOnly] [SerializeField] private Cat _cat;
    
    [SerializeField] int _maxMutation;
    private int _currentMutation;
    public List<StateCat> MutateStateAddList;
    public Cat MutateCat;
    public int CurrentMutation
    {
        get
        {
            return _currentMutation;
        }

        set
        {
            _currentMutation = value;
            if (_currentMutation == _maxMutation)
            {
                _cat.Animator.runtimeAnimatorController = MutateCat.Animator.runtimeAnimatorController;
                _cat.MeshFilter.mesh = MutateCat.MeshFilter.mesh;
                
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
        }
    }
    [Button]
    public void SetCat()
    {
        _cat = GetComponent<Cat>();
    }

}

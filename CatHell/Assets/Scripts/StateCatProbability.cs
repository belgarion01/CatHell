using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class StateCatProbability 
{
    public float minProbability;
        public float maxProbability;
        public StateCat stateCat;
        

        public bool CheckFloatInProbability(float rand)
        {
            if (rand > minProbability &&
                rand < maxProbability)
                return true;
            return false;
        }
}

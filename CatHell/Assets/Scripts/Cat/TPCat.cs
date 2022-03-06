using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TPCat : MonoBehaviour
{
    private float _timerCooldown;
    public float TimeCooldown = 5;
    private Cat _cat ;
    private bool isReadyToTP;
   public float MaxDistance = 6;
   public Transform TransformPlayer;

    private void Start()
    {
        TransformPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        _cat = GetComponent<Cat>();
    }

    private void Update()
    {
        if (_timerCooldown < TimeCooldown)
        {
            _timerCooldown += Time.deltaTime;
        }
        else
        {
            isReadyToTP = true;
        }           
        

 if (Vector3.Distance(transform.position, TransformPlayer.position)<MaxDistance
     && !_cat.IsHeld && _cat.Machine.CurrentStateCat.StateCatEnum != StateCatEnum.Sick && isReadyToTP)
        {
            int rand = Random.Range(0, DestinationCat.instance.spawnerCatList.Length );
            Debug.Log("tp");
            transform.position = DestinationCat.instance.spawnerCatList[rand].position;
            _cat.Machine.SetState(StateCatEnum.Idle);
            _timerCooldown = 0; 
            isReadyToTP = false;
        }
    }

   
       

        
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TPCat : MonoBehaviour
{
    private float timer;
    private float time = 5;
    private Cat cat ;
    private bool isReadyToTP;
 
    private void Update()
    {
        if (timer < time)
        {
            timer += Time.deltaTime;
        }
        else
        {
            isReadyToTP = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!cat.isHoldable && cat.Machine.CurrentStateCat.StateCatEnum != StateCatEnum.Sick && isReadyToTP)
            {
                Debug.Log("je me tp");
                int rand = Random.Range(0, DestinationCat.instance.spawnerCatList.Length );
                transform.position = DestinationCat.instance.spawnerCatList[rand].position;
                cat.Machine.SetState(StateCatEnum.Idle);
                timer = 0; 
                isReadyToTP = false;
            }
        }
    }
}

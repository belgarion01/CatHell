using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
[CreateAssetMenu(fileName = "", menuName = "Mutation/TPCat")]
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!cat.isHoldable && cat.Machine.CurrentStateCat.StateCatEnum != StateCatEnum.Sick && isReadyToTP)
            {
                int rand = Random.Range(0, DestinationCat.instance.TPPositionList.Count - 1);
                transform.position = DestinationCat.instance.TPPositionList[rand].position;
                cat.Machine.SetState(StateCatEnum.Idle);
                timer = 0; 
                isReadyToTP = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRelocationsSystem : MonoBehaviour
{
    public Vector3[] checkpointspositions;
    public bool inBossPlace = false;
    public RestoreItems restoreItems;
    PlayerVariables playerVariables;
    Attack attack;

    void Start()
    {
        playerVariables = GetComponent<PlayerVariables>();
        attack = GetComponent<Attack>();
    }
    public void AddPosition(int Cp , Vector3 position, bool locationBoss)
    {
        checkpointspositions[Cp] = position;
        inBossPlace = locationBoss;
    }


    public void RecolocationsPlayer() 
    {
        if (!inBossPlace)
        {
            if (playerVariables.health >= 26f)
            {
                transform.position = checkpointspositions[1];
                attack.Damage(25f);
            }
            else
            {
                transform.position = checkpointspositions[0];
                attack.Damage(25f);
                restoreItems.ResetPlayerHeatlh();
            } 
        }
        else
        {
            transform.position = checkpointspositions[2];
            attack.Damage(25f);
            restoreItems.ResetPlayerHeatlh();
        }
    }

}


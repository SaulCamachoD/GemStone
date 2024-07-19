using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocationsTutorialScene : MonoBehaviour
{
    private float Xinicial;
    private float Yinicial;
    private float Zinicial;
    public bool ZonaBoss = false;
    public PlayerVariables playerVariables;
    public RestoreItems restoreItems;
    Attack attack;
    void Start()
    {
        Xinicial = transform.position.x;
        Yinicial = transform.position.y;
        Zinicial = transform.position.z;
        attack = GetComponent<Attack>();
        playerVariables = GetComponent<PlayerVariables>();

    }

    public void Relocation()
    {
        transform.position = new Vector3(Xinicial, Yinicial, Zinicial);
        if (playerVariables.health <= 25f)
        {
            attack.Damage(25f);
            restoreItems.ResetPlayerHeatlh();
        }
        else 
        {
            attack.Damage(25f);
        }
    }
}

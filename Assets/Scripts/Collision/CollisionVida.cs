using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionVida : MonoBehaviour
{
    public int hp;
    public int dañoArma;
    public int dañoPuño;
    public Animator anim;
    public GameObject Gema;
    public BossDoor bossDoor;
    public bool isBoss;//Line nueva Saul

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("armaImpacto"))
        {
            if (anim !=null)
            {
                anim.Play("AnimacionDamage");
            }
            hp -= dañoArma;
        }
        if (hp < 0)
        {
            Destroy(gameObject);
            if (isBoss)//Condicional nuevo Saul
            {
                Gema.SetActive(true);
                bossDoor.ActiveDoorEvent(); 
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
using Debug = UnityEngine.Debug;


#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class EnemyCharacter : ScriptableObject
{
    
    public Estados estado;
    public float distanciaSeguir;
    public float distanciaAtacar;
    public float distanciaEscapar;
    public Transform target;
    public float distancia;
   

    public bool vivo = true;
    
    public void Position(Transform transformTarget)
    {
        target = transformTarget;
    }
    public void CheckEstado(Transform enemy)
    {
        switch (estado)
        {
            case Estados.idle:
                EstadoIdle();
                break;
            case Estados.seguir:
                enemy.transform.LookAt(target,Vector3.up);
                EstadoSeguir();
                break;
            case Estados.attack:
                EstadoAtacar();
                break;
            case Estados.dead:
                EstadoMuerto();
                break;
        }
    }
    public void CambairEstado(Estados e)
    {
        switch (e)
        {
            case Estados.idle:
                break;
            case Estados.seguir:
                break;
            case Estados.attack:
                break;
            case Estados.dead:
                vivo = false;
                break;
        }
        estado = e;
    }
    public virtual void EstadoIdle()
    {
        if (distancia < distanciaSeguir)
        {
            CambairEstado(Estados.seguir);
        }
    }
    
    public virtual void EstadoSeguir()
    {
        if (distancia < distanciaAtacar)
        {
            CambairEstado(Estados.attack);
        }
        else if (distancia > distanciaEscapar)
        {
            CambairEstado(Estados.idle);
        }
    }
    
    public virtual void EstadoAtacar()
    {
        if (distancia > distanciaAtacar + 0.05f)
        {
            CambairEstado(Estados.seguir);
        }
    }
    
    public virtual void EstadoMuerto()
    {
        
    }
   public IEnumerator CalculateDistance(Transform posicionenemigo)
    {
        //Debug.Log("entro al enumerator");
        while (vivo)
        {
            //Debug.Log("si esta vivo");
            if (target)
            {
                //Debug.Log("reconoce el target");
                distancia = Vector3.Distance(posicionenemigo.position ,target.transform.position);
                yield return new WaitForSeconds(0.3f);
            }
            
        }
    }
   
#if UNITY_EDITOR
    public void OnDrawGuizmosSelected(Transform enemy)
    {
            Handles.color = Color.yellow;
            Handles.DrawWireDisc(enemy.position, Vector3.up, distanciaSeguir);
            Handles.color = Color.red;
            Handles.DrawWireDisc(enemy.position, Vector3.up, distanciaAtacar);
            Handles.color = Color.green;
            Handles.DrawWireDisc(enemy.position, Vector3.up, distanciaEscapar);
    }
#endif
    public void OnDrawGuizmos(Transform enemy)
    {
        int icono = (int)estado;
        icono++;
        Gizmos.DrawIcon(enemy.position + Vector3.up * 1.2f, "01.png", false);
    }
}

[Serializable]
public enum Estados
{
    idle    = 0,
    seguir  = 1,
    attack  = 2,
    dead    = 3,
}















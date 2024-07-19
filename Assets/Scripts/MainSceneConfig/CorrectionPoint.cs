using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectionPoint : MonoBehaviour
{
    public PlayerLoctions locations;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            locations.InicialLocation();
        }
    }
}

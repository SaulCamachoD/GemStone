using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{   
    public FallRelocationsSystem fallRelocationsSystem;
    [SerializeField] private int _positionArray;
    [SerializeField] private bool _locationBoss;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            fallRelocationsSystem.AddPosition(_positionArray,transform.position, _locationBoss);

        }
    }
}
  
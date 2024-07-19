using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateMovementPointB : MonoBehaviour
{
    public Movements movements;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            movements.MoveDirections = false;
        }
    }
}

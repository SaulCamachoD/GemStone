using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetectionsTutorialScene : MonoBehaviour
{
    public PlayerLocationsTutorialScene locations;
    public PointRotateCam rotateCam;
    public Movements movements;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            locations.Relocation();
            rotateCam.StartRotationOrigin();
            movements.MoveDirections = false;
        }
    }
}

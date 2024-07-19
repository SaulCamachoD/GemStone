using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectedFallPlayer : MonoBehaviour
{
    public FallRelocationsSystem repositions;
    public PointRotateCam rotateCam;

    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.name == "Player")
        {
            repositions.RecolocationsPlayer();
            rotateCam.StartRotationOrigin();
        }
    }
}

using Cinemachine;
using UnityEngine;

public class StatueCamp : MonoBehaviour
{
    public CinemachineVirtualCamera targetVirtualCamera;
    public float orthoSizeInTrigger = 30f; 
    public float orthoSizeOutTrigger = 12f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")         {
            if (targetVirtualCamera != null)
            {
                targetVirtualCamera.m_Lens.OrthographicSize = orthoSizeInTrigger;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (targetVirtualCamera != null)
            {
                targetVirtualCamera.m_Lens.OrthographicSize = orthoSizeOutTrigger;
            }
        }
    }
}

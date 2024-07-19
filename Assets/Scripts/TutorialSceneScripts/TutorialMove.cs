using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMove : MonoBehaviour
{   
    public GameObject moveText;
    private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.name == "Player")
        {
            moveText.SetActive(true);
        }
    } 
    
    private void OnTriggerExit(Collider other)
    {
       if (other.gameObject.name == "Player")
        {
            moveText.SetActive(false);
        }
    }
}

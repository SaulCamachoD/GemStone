using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreItems : MonoBehaviour
{
    public Attack attack;
    

    public void ResetPlayerHeatlh()
    {
        attack.ResetHealth();
    }
}

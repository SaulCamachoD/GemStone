using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLightStatue : MonoBehaviour
{
    // Referencia a la primera luz spot
    public Light spotLight1;

    // Referencia a la segunda luz spot
    public Light spotLight2;
    
    // Referencia a luz Stone
    public Light spotLight3;

    public GameObject Message;

    // Intensidad inicial y final
    public float initialIntensity = 5f;
    public float finalIntensity = 20f;

    // Número de veces que titilarán las luces
    public int blinkCount = 5;

    // Duración del titileo
    public float blinkDuration = 0.5f;

    public GemaMovements GemeMovements;

    void Start()
    {
        // Asegúrate de que las luces tengan la intensidad inicial al comenzar
        if (spotLight1 != null)
            spotLight1.intensity = initialIntensity;
        if (spotLight2 != null)
            spotLight2.intensity = initialIntensity;

        spotLight3.intensity = 0;
        Message.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Cuando el collider se activa, comienza la Coroutine
        StartCoroutine(BlinkAndIncreaseIntensity());
        GemeMovements.StatueAdvice();
        spotLight3.intensity = 120;

    }

    private void OnTriggerExit(Collider other)
    {
        Message.SetActive(false);
    }

    IEnumerator BlinkAndIncreaseIntensity()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            // Apagar las luces
            if (spotLight1 != null)
                spotLight1.intensity = 0;
            if (spotLight2 != null)
                spotLight2.intensity = 0;
            yield return new WaitForSeconds(blinkDuration / 2);

            // Encender las luces
            if (spotLight1 != null)
                spotLight1.intensity = initialIntensity;
            if (spotLight2 != null)
                spotLight2.intensity = initialIntensity;
            yield return new WaitForSeconds(blinkDuration / 2);

            
        }

        // Aumentar la intensidad a la final
        if (spotLight1 != null)
            spotLight1.intensity = finalIntensity;
        if (spotLight2 != null)
            spotLight2.intensity = finalIntensity;
        Message.SetActive(true);

    }
}

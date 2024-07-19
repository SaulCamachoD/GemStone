using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    public float pushForce = 2.0f;

    void OnCollisionStay(Collision collision)
    {
        // Verifica si el objeto con el que colisiona es empujable
        if (collision.gameObject.CompareTag("Gema"))
        {
            Rigidbody pushableRb = collision.gameObject.GetComponent<Rigidbody>();

            // Calcula la dirección de la fuerza
            Vector3 forceDirection = collision.contacts[0].point - transform.position;
            forceDirection = -forceDirection.normalized;

            // Aplica la fuerza al objeto empujable
            pushableRb.AddForce(forceDirection * pushForce);

        }
    }
}

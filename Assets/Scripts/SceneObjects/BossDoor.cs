using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    public float openAngle = -90f;
    public float openSpeed = 2f;

    public bool isOpen = false;
    private float initialYRotation;
    private float targetYRotation;
    public bool isMoving = false;

    void Start()
    {
        initialYRotation = transform.rotation.eulerAngles.y;
        targetYRotation = initialYRotation;
    }

    void Update()
    {
        if (isMoving)
        {
            float currentYRotation = Mathf.LerpAngle(transform.rotation.eulerAngles.y, targetYRotation, Time.deltaTime * openSpeed);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, currentYRotation, transform.rotation.eulerAngles.z);


            if (Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.y, targetYRotation)) < 0.1f)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, targetYRotation, transform.rotation.eulerAngles.z);
                isMoving = false;
            }
        }
    }

    public void ActiveDoorEvent()
    {
        isOpen = !isOpen;
        targetYRotation = isOpen ? initialYRotation + openAngle : initialYRotation;
        isMoving = true;
    }
}

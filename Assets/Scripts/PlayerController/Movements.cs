using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movements : MonoBehaviour
{
    PlayerVariables playerVariables;
    Animations animations;
    Rigidbody rb;
    public float mX;
    public float mZ;
    public float Vr;
    public bool unlockDash = false;
    private float dashForce;
    private float dashCooldown;
    private float dashTime;
    private bool isDashing;
    private float dashTimer;
    [SerializeField] private bool canMove;
    private float originalSpeed;
    public bool MoveDirections = false;

    public GemaMovements gemaMovements;


    void Start()
    {
        playerVariables = GetComponent<PlayerVariables>();
        animations = GetComponent<Animations>();
        rb = GetComponent<Rigidbody>();
        Vr = playerVariables.rotationSpeed;
        dashForce = playerVariables.dashForce;
        dashCooldown = playerVariables.dashCooldown;
        dashTime = playerVariables.dashTime;
        isDashing = playerVariables.isDashing;
        dashTimer = playerVariables.dashTimer;
        canMove = true;
        originalSpeed = playerVariables.speed;
        //gemaMovements.OnPushStateChanged += HandlePushStateChanged;
    }

    void Update()
    {
        mX = Input.GetAxis("Horizontal");
        mZ = Input.GetAxis("Vertical");

        
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && dashTimer <= 0 && unlockDash)
        {
            animations.DashAnimation();
            StartCoroutine(StartDash());
        }
    }

    private void FixedUpdate()
    {
        if (!MoveDirections)
        {
            if (canMove)
            {
                Displacement();
            } 
        }

        else 
        {
            if (canMove)
            {
                DisplacementB();
            }
        }


        dashTimer -= Time.deltaTime; 
    }

    public void Displacement()
    {
        if (isDashing)
        {
            return; 
        }

        Vector3 movement = new Vector3(mX, 0, mZ).normalized;

        if (movement.magnitude >= 0.5f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref Vr, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(transform.position + moveDirection * playerVariables.speed * Time.deltaTime);
        }
    }public void DisplacementB()
    {
        if (isDashing)
        {
            return; 
        }

        Vector3 movement = new Vector3(-mZ, 0, mX).normalized;

        if (movement.magnitude >= 0.5f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref Vr, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(transform.position + moveDirection * playerVariables.speed * Time.deltaTime);
        }
    }

    IEnumerator StartDash()
    {
        isDashing = true;
        rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        dashTimer = dashCooldown;
    }

    public void UnlockDash()
    {
        unlockDash = true;
    }

    public void DontCanMove()
    {
        canMove = false;
    }

    public void CanMovePlayer()
    {
        canMove = true;
    }

    private void HandlePushStateChanged(bool isPushing)
    {
        if (isPushing)
        {
            playerVariables.speed /= 2;  
        }
        else
        {
            playerVariables.speed = originalSpeed;  
        }
    }

    //void OnDestroy()
    //{
       
        //gemaMovements.OnPushStateChanged -= HandlePushStateChanged;
    //}
}

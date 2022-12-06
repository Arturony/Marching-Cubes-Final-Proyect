using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float moveSpeed = 6f;

    [SerializeField]
    private float moveMult = 6f;

    [SerializeField]
    private float groundDrag = 6f;

    [SerializeField]
    private float airDrag = 2f;

    [SerializeField]
    private float jumpForce = 6f;

    [SerializeField]
    private LayerMask layerMask;

    private bool isGrounded;

    [SerializeField]
    private float maxYVel;

    [SerializeField]
    private float damageCeiling;

    public event Action<int> takeDmg;

    [SerializeField]
    private int fallMult;

    [SerializeField]
    private GameObject ground;

    [SerializeField]
    private float airMult;

    [SerializeField]
    private Transform orientation;


    float x;
    float z;

    // Update is called once per frame
    void Update()
    {
        maxYVel = rb.velocity.y;
        
        x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        z = Input.GetAxisRaw("Vertical") * moveSpeed;

        isGrounded = Physics.CheckSphere(ground.transform.position, 0.4f, layerMask);

        if(isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            maxYVel = -2f;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded == false)
        {
            Vector3 movePos = orientation.right * x + orientation.forward * z;
            Vector3 newMovePos = movePos.normalized * moveSpeed * moveMult * airMult;

            rb.AddForce(newMovePos, ForceMode.Acceleration);
        }
        else
        {
            Vector3 movePos = orientation.right * x + orientation.forward * z;
            Vector3 newMovePos = movePos.normalized * moveSpeed * moveMult;

            rb.AddForce(newMovePos, ForceMode.Acceleration);
        }
    }
}

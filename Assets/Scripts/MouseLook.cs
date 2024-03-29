using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Flags]
    public enum RotationDirection
    {
        None,
        Horizontal = (1 << 0),
        Vertical = (1 << 1)
    }

    [SerializeField]
    private Vector2 acceleration;

    [SerializeField]
    private Vector2 sensitivity;

    [SerializeField]
    private RotationDirection rotationDirections;

    private Vector2 velocity;
    private Vector2 rotation;

    [SerializeField]
    private float maxVerticalAngle;

    [SerializeField]
    private float inputLagPeriod;

    private Vector2 lastInputEvent;
    private float inputLagTimer;

    private void OnEnable()
    {
        velocity = Vector2.zero;
        inputLagTimer = 0;
        lastInputEvent = Vector2.zero;

        Vector3 euler = transform.localEulerAngles;

        if(euler.x >= 180)
        {
            euler.x -= 360;
        }

        euler.x = ClampVerticalAngle(euler.x);

        transform.localEulerAngles = euler;

        rotation = new Vector2(euler.y, euler.x);
    }

    private float ClampVerticalAngle(float angle)
    {
        return Mathf.Clamp(angle, -maxVerticalAngle, maxVerticalAngle);
    }

    private Vector2 GetInput()
    {
        inputLagTimer += Time.deltaTime;

        Vector2 input = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        return input;

        if(Mathf.Approximately(0, input.x) && Mathf.Approximately(0, input.y) == false || inputLagTimer >= inputLagPeriod)
        {
            lastInputEvent = input;
            inputLagTimer = 0;
        }

        return lastInputEvent;
    }

    private void Update()
    {
        Vector2 wantedVelocity = GetInput() * sensitivity;

        if((rotationDirections & RotationDirection.Horizontal) == 0)
        {
            wantedVelocity.x = 0;
        }
        if ((rotationDirections & RotationDirection.Vertical) == 0)
        {
            wantedVelocity.y = 0;
        }

        //velocity = new Vector2(Mathf.MoveTowards(velocity.x, wantedVelocity.x, Time.deltaTime),
        //                       Mathf.MoveTowards(velocity.y, wantedVelocity.y, Time.deltaTime));

        velocity = new Vector2(wantedVelocity.x, wantedVelocity.y);

        rotation += velocity * Time.deltaTime;
        rotation.y = ClampVerticalAngle(rotation.y);

        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
    }
}

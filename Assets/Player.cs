using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using GameMessage;

public class Player : Character
{
    [GetComponent] Controller controller;

    public Vector3 inputDirection = new Vector3();

    [Min(0f)] public float speedAirMultiple;
    [Min(0f)] public float speed;
    [Min(0f)] public float accelerationGround;
    [Min(0f)] public float accelerationAir;

    [Min(0f)] public float jumpHeight;

    private void Awake()
    {
        GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
    }


    private void Update()
    {
        controller.IsGround();
        float _acceleration = controller.isGround ? accelerationGround : accelerationAir;
        float _speed = controller.isGround ? speed : speed * speedAirMultiple;

        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.z = Input.GetAxisRaw("Vertical");
        inputDirection.Normalize();

        controller.Move(inputDirection, _speed, _acceleration);
        controller.Forwarding(inputDirection, _acceleration);

        if (Input.GetKeyDown(KeyCode.Space))
            controller.Jump(jumpHeight);
    }


    public override void GetDamage(DamageMessage msg)
    {

    }

    public override void GetSlow(SlowMessage msg)
    {

    }
}

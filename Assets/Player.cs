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
            controller.Jump(3f);
    }


    public override void GetDamage(DamageMessage msg)
    {
        Debug.Log("Damaged!");
        
        if (msg.receiveCreator)
            Debug.Log("Receive Creator : " + msg.receiveCreator.name);

        Debug.Log("Receiver : " + msg.receiver.name);
        Debug.Log("Sender : " + msg.sender.name);

        Debug.Log("Damage : " + msg.damage);
        Debug.Log("==============");
    }

    public override void GetSlow(SlowMessage msg)
    {
        Debug.Log("Slow! =====");
        if (msg.receiveCreator)
            Debug.Log("Receive Creator : " + msg.receiveCreator.name);

        Debug.Log("Receiver : " + msg.receiver.name);
        Debug.Log("Sender : " + msg.sender.name);

        Debug.Log("Slow : " + msg.slow);
        Debug.Log("==============");
    }
}

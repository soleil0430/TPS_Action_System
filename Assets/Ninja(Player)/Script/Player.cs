using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using GameMessage;
using Movement;
using Bound;

public class Player : Character
{
    static string movementState = "Movement";
    static string attack1State = "Attack1";
    static string attack2State = "Attack2";
    static string attack3State = "Attack3";

    bool IsState(string tag) => animator.GetCurrentAnimatorStateInfo(0).IsTag(tag);


    [GetComponent, DisableField] public Controller controller;
    [GetComponent, DisableField] public Animator animator;
    [GetComponent, DisableField] public AudioSource audioSource;

    [SerializeField] public Transform shurikenMuzzle;
    [SerializeField] public MotionTrail motionTrail;

    [SerializeField] public GameObject shurikenPrefab;

    [Min(0f)] public float speedAirMultiple;
    [Min(0f)] public float accelerationGround;
    [Min(0f)] public float accelerationAir;
    [Min(0f)] public float runSpeed;
    [Min(0f)] public float dodgeSpeed;
    [Min(0f)] public float jumpHeight;
    [Min(1f)] public float attackSpeed;


    [DisableField] public float speed;
    [DisableField] public float accelerationMovement;
    [DisableField] public float accelerationForward;

    [DisableField] public Vector3 inputDirection = new Vector3();

    private void Awake()
    {
        GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);

        Utility.SetBehaviour<Player>(animator, this);

        //animator.GetCurrentAnimatorStateInfo(0).IsTag(movementState);
    }


    private void Update()
    {
        controller.IsGround();

        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.z = Input.GetAxisRaw("Vertical");
        inputDirection.Normalize();

        animator.SetBool("bIsGround", controller.isGround);
    }


    private void LateUpdate()
    {
        animator.SetFloat("fMoveAmount", controller.velocity.magnitude / speed);
        animator.SetFloat("AttackMultipiler", attackSpeed);

        Vector2 velocityXZ = new Vector2(controller.velocityX, controller.velocityZ);
        motionTrail.onTrail = (velocityXZ.magnitude > runSpeed * 1.2f);
    }


    public void ThrowShuriken()
    {
        GameObject shuriken = Instantiate(shurikenPrefab, shurikenMuzzle.position, shurikenMuzzle.rotation);
        SendBound sBound = shuriken.GetComponent<SendBound>();
        sBound.creator = gameObject;

        StraightMovement movement = shuriken.GetComponent<StraightMovement>();
        movement.direction = shurikenMuzzle.forward;
    }

    public override void GetDamage(DamageMessage msg)
    {

    }

    public override void GetSlow(SlowMessage msg)
    {

    }


    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}

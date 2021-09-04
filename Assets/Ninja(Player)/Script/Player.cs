using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;
using Bound;

public class Player : Character
{
    [GetComponent, DisableField] public Controller controller;
    [GetComponent, DisableField] public Animator animator;
    [GetComponent, DisableField] public AudioSource audioSource;

    [SerializeField] public Transform shurikenMuzzle;
    [SerializeField] public MotionTrail motionTrail;
    [SerializeField] public Transform pCamera;

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

        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update()
    {
        controller.IsGround();

        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.z = Input.GetAxisRaw("Vertical");
        inputDirection.Normalize();

        inputDirection = pCamera.TransformVector(inputDirection);
        inputDirection.y = 0f;
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

    public float throwDistance = 10f;
    public LayerMask throwMask;
    public void ThrowShuriken()
    {
        Vector3 targetPoint = GetThrowAim();
        GameObject shuriken = Instantiate(shurikenPrefab, shurikenMuzzle.position, shurikenMuzzle.rotation);


        Bezier3Movement movement = shuriken.GetComponent<Bezier3Movement>();
        SetBezierThrow(movement);
        movement.bezierPoints.Add(targetPoint);

        SendBound[] sBounds = shuriken.GetComponents<SendBound>();
        foreach (var item in sBounds)
            item.sender = transform;
    }

    Vector3 GetThrowAim()
    {
        Ray ray = new Ray();
        ray.origin = pCamera.position;
        ray.direction = pCamera.forward;


        Vector3 point = ray.origin + ray.direction * (10f + throwDistance);

        if (Physics.Raycast(ray, out RaycastHit hit, 10f + throwDistance, throwMask, QueryTriggerInteraction.Ignore))
        {
            point = hit.point;
        }

        Debug.DrawLine(ray.origin, point, Color.white, 1f);

        return point;
    }

    void SetBezierThrow(Bezier3Movement movement)
    {
        movement.bezierPoints.Add(shurikenMuzzle.position);
        {
            for (int i = 0; i < 2; i++)
            {
                Vector3 rand = new Vector3(Random.Range(0.2f, 1f),
                                           Random.Range(0.2f, 1f),
                                           1f);
                rand = shurikenMuzzle.TransformVector(rand);
                rand.Normalize();


                Ray ray = new Ray();
                ray.origin = shurikenMuzzle.position;
                ray.direction = rand;


                Vector3 point = ray.origin + ray.direction * (10f);
                if (Physics.Raycast(ray, out RaycastHit hit, 5f, throwMask, QueryTriggerInteraction.Ignore))
                {
                    point = hit.point;
                }

                movement.bezierPoints.Add(point);
            }
        }
    }

    public override bool GetDamage(DamageMessage msg)
    {
        if (msg.isIncludeMe)
        {
            Debug.Log("¾Æ¾æ");
        }

        return false;
    }

    public override bool GetDirection(DirectionMessage msg)
    {
        return false;
    }

    //public override void GetSlow(SlowMessage msg)
    //{

    //}


    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}

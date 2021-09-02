using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    

    [Header("Editor")]
    [GetComponent, DisableField] public CharacterController cController;
    public float groundCheckerY;
    public LayerMask groundMask;
    public bool useGravity;
    public float extraGravityY;

    [Header("Runtime")]
    [DisableField] public bool isGround;
    [DisableField] public Vector3 velocity;
    [DisableField] public float velocityX;
    [DisableField] public float velocityY;
    [DisableField] public float velocityZ;
    [DisableField] public Vector3 forward;
    

    private void Awake()
    {
        GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
    }

    public bool IsGround()
    {
        if (cController.isGrounded)
        {
            isGround = true;
            return isGround;
        }

        Vector3 groundCheckPoint = transform.position + new Vector3(0f, groundCheckerY, 0f);
        Collider[] others = Physics.OverlapSphere(groundCheckPoint, cController.radius, groundMask, QueryTriggerInteraction.Ignore);

        isGround = (others.Length > 0);
        return isGround;
    }

    public void Move(Vector3 _direction, float _speed, float _acceleration)
    {
        _direction.Normalize();

        Vector3 desiredVelocity = _direction * _speed;

        Vector3 _velocity = Vector3.Lerp(velocity, desiredVelocity, Time.deltaTime / _acceleration);

        velocityX = Mathf.Lerp(velocity.x, desiredVelocity.x, Time.deltaTime / _acceleration);
        velocityZ = Mathf.Lerp(velocity.z, desiredVelocity.z, Time.deltaTime / _acceleration);
        velocityY = Gravity();

        velocity = new Vector3(velocityX, velocityY, velocityZ);


        cController.Move(velocity * Time.deltaTime);
    }

    public float Gravity()
    {
        float _velocityY = velocityY;
        if (useGravity)
        {
            if (!isGround)
            {
                float gravity = Physics.gravity.y + extraGravityY;
                gravity = Mathf.Clamp(gravity, -float.MaxValue, -0.001f);
                _velocityY += gravity * Time.deltaTime;
            }
            else
            {
                if (_velocityY < 0f)
                    _velocityY = 0f;
            }
        }

        return _velocityY;
    }

    public void Forwarding(Vector3 _direction, float _acceleration)
    {
        _direction.y = 0f;
        _direction.Normalize();

        forward = Vector3.Slerp(forward, _direction, Time.deltaTime / _acceleration);
        forward.Normalize();

        if (forward.magnitude > 0f)
            transform.forward = forward;
    }

    public void Jump(float _height)
    {
        if (isGround)
        {
            velocityY = 0f;
            velocityY += Mathf.Sqrt(2f * Mathf.Abs(Physics.gravity.y + extraGravityY) * _height);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 groundCheck = transform.position + new Vector3(0, groundCheckerY, 0);
        Gizmos.DrawWireSphere(groundCheck, cController.radius);
    }
#endif

}

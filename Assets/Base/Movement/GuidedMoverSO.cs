using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Move
{
    [CreateAssetMenu(fileName = "Guided MoverSO", menuName = "SO/Mover/Guided")]
    public class GuidedMoverSO : MoverSO, ISerializationCallbackReceiver
    {
        [Header("Init Field")]
        [SerializeField, Min(0f)] private float speed;
        [SerializeField, Range(0.001f, 1f)] private float guided;

        [Header("Runtime Field")]
        [DisableField] public Transform rTarget;
        [DisableField] public Vector3 rDirection;
        [DisableField] public float rSpeed;
        [DisableField] public float rGuided;

        [DisableField] Vector3 toTarget;
        [DisableField] Vector3 velocity;



        public override void Move(Rigidbody _body)
        {
            if (rTarget)
            {
                toTarget = rTarget.position - _body.position;

                rDirection = velocity.normalized + (toTarget * Time.deltaTime / guided);
                rDirection.Normalize();
            }

            velocity = rDirection * speed;

            _body.MovePosition(_body.position + velocity * Time.deltaTime);

            nowPos = _body.position;
        }


        Vector3 nowPos;
        public override void DrawGizmos()
        {
            if (rTarget)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(nowPos, rTarget.position);
                Gizmos.DrawWireSphere(rTarget.position, 0.2f);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(nowPos, nowPos + velocity);
            }
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {

        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            rSpeed = speed;
            rGuided = guided;
        }
    }
}
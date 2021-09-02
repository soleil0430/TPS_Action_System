using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Move
{
    [CreateAssetMenu(fileName = "Straight MoverSO", menuName = "SO/Mover/Straight")]
    public class StraightMoverSO : MoverSO, ISerializationCallbackReceiver
    {
        [Header("Init Field")]
        [SerializeField, Min(0f)] private float speed;
        [SerializeField] private Vector3 direction;

        [Header("Runtime Field")]
        [DisableField] public float rSpeed;
        [DisableField] public Vector3 rDirection;



        public override void Move(Rigidbody _body)
        {
            _body.MovePosition(_body.position + rDirection * rSpeed * Time.deltaTime); 
            nowPos = _body.position;
        }

        Vector3 nowPos;
        public override void DrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(nowPos, nowPos + rDirection * rSpeed);
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {

        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            rSpeed = speed;
            rDirection = direction;
        }
    }
}
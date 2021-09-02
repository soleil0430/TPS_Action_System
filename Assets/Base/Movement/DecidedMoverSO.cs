using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Move
{
    [CreateAssetMenu(fileName = "Decided MoverSO", menuName = "SO/Mover/Bezier3")]
    public class DecidedMoverSO : MoverSO, ISerializationCallbackReceiver
    {
        [Header("Init Field")]
        [SerializeField] private AnimationCurve curve;
        [SerializeField] private Vector3 start;
        [SerializeField, Min(0.01f)] private float duration = 0.01f;
        [SerializeField] private Vector3 end;

        [Header("Runtime Field")]
        [DisableField] public AnimationCurve rCurve;
        [DisableField] public Vector3 rStart;
        [DisableField] public float rDuration;
        [DisableField] public Vector3 rEnd;

        [DisableField] public float rDelta;

        public override void Move(Rigidbody _body)
        {
            if (rDelta <= rDuration)
            {
                Vector3 toEnd = rEnd - rStart;
                
                _body.MovePosition(rStart + toEnd * (rCurve.Evaluate(rDelta / rDuration)));
                rDelta += Time.deltaTime;
            }
        }

        public override void DrawGizmos()
        {
            Vector3 toEnd = rEnd - rStart;

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(rEnd, 0.2f);
            Gizmos.DrawLine(rStart, rEnd);

            Gizmos.color = Color.red;
            Vector3 nowPos = rStart + toEnd * (rCurve.Evaluate(rDelta / rDuration));
            Gizmos.DrawWireSphere(nowPos, 0.2f);
            Gizmos.DrawLine(rStart, nowPos);
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {

        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            rCurve = curve;
            rStart = start;
            rDuration = duration;
            rEnd = end;
        }
    }
}
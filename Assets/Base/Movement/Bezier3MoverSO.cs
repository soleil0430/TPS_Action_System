using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Move
{
    [CreateAssetMenu(fileName = "Bezier3 MoverSO", menuName = "SO/Mover/Bezier3")]
    public class Bezier3MoverSO : MoverSO, ISerializationCallbackReceiver
    {
        [Header("Init Field")]
        [SerializeField] private Vector3 start;
        [SerializeField] private Vector3 p1;
        [SerializeField] private Vector3 p2;
        [SerializeField] private Vector3 end;
        [SerializeField] private float duration;

        [Header("Runtime Field")]
        [DisableField] public Vector3 rStart;
        [DisableField] public Vector3 rPoint1;
        [DisableField] public Vector3 rPoint2;
        [DisableField] public Vector3 rEnd;
        [DisableField] public float rDuration;

        [DisableField] public float rDelta;


        public override void Move(Rigidbody _body)
        {
            float _delta = rDelta / rDuration;

            Vector3 _s = Vector3.Lerp(rStart, rPoint1, _delta);
            Vector3 _p1 = Vector3.Lerp(rPoint1, rPoint2, _delta);
            Vector3 _e = Vector3.Lerp(rPoint2, rEnd, _delta);

            Vector3 __s = Vector3.Lerp(_s, _p1, _delta);
            Vector3 __e = Vector3.Lerp(_p1, _e, _delta);

            Vector3 ___e = Vector3.Lerp(__s, __e, _delta);

            _body.position = ___e;

            rDelta += Time.deltaTime;
        }

        public override void DrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(rStart, 0.2f);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(rStart, rPoint1);
            Gizmos.DrawWireSphere(rPoint1, 0.2f);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(rPoint1, rPoint2);
            Gizmos.DrawWireSphere(rPoint2, 0.2f);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(rPoint2, rEnd);
            Gizmos.DrawWireSphere(rEnd, 0.2f);

        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {

        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            rStart = start;
            rPoint1 = p1;
            rPoint2 = p2;
            rEnd = end;

            rDuration = duration;
        }
    }
}
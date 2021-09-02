using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Move
{

    [CreateAssetMenu(fileName = "Way Point MoverSO", menuName = "SO/Mover/Way Point")]
    public class WayPointMoverSO : MoverSO, ISerializationCallbackReceiver
    {
        [Header("Init Field")]
        [SerializeField] private List<Vector3> wayPoints;
        [SerializeField] private float speed;

        [Header("Runtime Field")]
        [DisableField] public List<Vector3> rWayPoints;
        [DisableField] public float rSpeed;

        [DisableField] private int rNowPointIndex = 0;
        [DisableField] private Vector3 rDirection;

        public override void Move(Rigidbody _body)
        {
            Vector3 nowPoint = rWayPoints[rNowPointIndex];
            Vector3 toPoint = nowPoint - _body.position;

            if (toPoint.magnitude < 0.1f)
            {
                if (rNowPointIndex + 1 < rWayPoints.Count)
                    rNowPointIndex++;
            }

            rDirection = toPoint.normalized;

            _body.MovePosition(_body.position + rDirection * rSpeed * Time.deltaTime);
            nowPos = _body.position;
        }

        Vector3 nowPos;
        public override void DrawGizmos()
        {
            if (rWayPoints.Count > 0)
            {
                Gizmos.color = Color.green;

                foreach (var item in rWayPoints)
                    Gizmos.DrawWireSphere(item, 0.2f);

                for (int i = 0; i < rWayPoints.Count - 1; ++i)
                    Gizmos.DrawLine(rWayPoints[i], rWayPoints[i + 1]);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(nowPos, rWayPoints[rNowPointIndex]);
            }
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {

        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            rWayPoints = wayPoints.ConvertAll(s => s);
            rSpeed = speed;
            rNowPointIndex = 0;
        }

    }
}
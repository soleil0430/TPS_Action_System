using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class WaypointMovement : BaseMovement
    {
        public List<Vector3> wayPoints;
        public int nowWayPointIndex;

        public Vector3 nowPoint => (wayPoints[nowWayPointIndex]);
        public Vector3 toTargetPoint => (nowPoint - rigidbody.position);


        void Update()
        {
            if (toTargetPoint.magnitude < 0.1f)
            {
                if (nowWayPointIndex + 1 < wayPoints.Count)
                    nowWayPointIndex++;
            }

            direction = toTargetPoint.normalized;

            rigidbody.MovePosition(rigidbody.position + direction * speed * Time.deltaTime);
        }

        private void OnDrawGizmos()
        {
            if (rigidbody)
            {
                if (wayPoints.Count > 0)
                {
                    Gizmos.color = Color.green;

                    foreach (Vector3 point in wayPoints)
                        Gizmos.DrawWireSphere(point, 0.2f);

                    for (int i = 0; i < wayPoints.Count - 1; ++i)
                        Gizmos.DrawLine(wayPoints[i], wayPoints[i + 1]);

                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(rigidbody.position, nowPoint);
                }
            }
        }

    }
}
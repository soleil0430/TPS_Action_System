using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Move
{

    [System.Serializable]
    public class WayPointMover : IMover
        {
            public List<Vector3> wayPoints;
            public float speed;

            public int nowPointIndex = 0;
        public Vector3 direction;
        

        public void Move(Rigidbody _body)
        {
            Vector3 nowPoint = wayPoints[nowPointIndex];
            Vector3 toPoint = nowPoint - _body.position;

            if (toPoint.magnitude < 0.1f)
            {
                if (nowPointIndex + 1 < wayPoints.Count)
                    nowPointIndex++;
            }

            direction = toPoint.normalized;

            _body.position = _body.position + direction * speed * Time.deltaTime;

#if UNITY_EDITOR
            nowPos = _body.position;
#endif
        }

#if UNITY_EDITOR
        Vector3 nowPos;
        public void DrawGizmos()
        {
            if (wayPoints.Count > 0)
            {
                Gizmos.color = Color.green;

                foreach (var item in wayPoints)
                    Gizmos.DrawWireSphere(item, 0.2f);
                
                for (int i = 0; i < wayPoints.Count - 1; ++i)
                    Gizmos.DrawLine(wayPoints[i], wayPoints[i + 1]);
            
                Gizmos.color = Color.red;
                Gizmos.DrawLine(nowPos, wayPoints[nowPointIndex]);
            }
        }
#endif

    }
}
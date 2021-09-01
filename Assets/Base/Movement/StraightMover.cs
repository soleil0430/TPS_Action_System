using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Move
{
    [System.Serializable]
    public class StraightMover : IMover
    {
        public float speed;
        public Vector3 forward;

        public void Move(Rigidbody _body)
        {
            nowPos = _body.position = _body.position + forward * speed * Time.deltaTime;
        }

#if UNITY_EDITOR
        Vector3 nowPos;
        public void DrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(nowPos, nowPos + forward * speed);
        }
#endif
    }
}
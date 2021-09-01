using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Move
{
    [System.Serializable]
    public class StraightMover : IMover
    {
        [Min(0f)] public float speed;
        public Vector3 direction;

        public void Move(Rigidbody _body)
        {
            _body.position = _body.position + direction * speed * Time.deltaTime;

#if UNITY_EDITOR
            nowPos = _body.position;
#endif
        }

#if UNITY_EDITOR
        Vector3 nowPos;
        public void DrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(nowPos, nowPos + direction * speed);
        }
#endif
    }
}
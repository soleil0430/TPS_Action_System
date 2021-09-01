using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Move
{
    [System.Serializable]
    public class GuidedMover : IMover
    {
        public Transform target;
        public Vector3 direction;
        [Min(0f)] public float speed;
        [Range(0f, 1f)] public float guided;



        Vector3 toTarget;
        Vector3 velocity;
        public void Move(Rigidbody _body)
        {
            if (target)
            {
                toTarget = target.position - _body.position;

                direction = direction + (toTarget * guided * Time.deltaTime);
                direction.Normalize();
            }

            velocity = direction * speed;
            _body.position = _body.position + velocity * Time.deltaTime;

#if UNITY_EDITOR
            nowPos = _body.position;
#endif
        }


#if UNITY_EDITOR
        Vector3 nowPos;
        public void DrawGizmos()
        {
            if (target)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(nowPos, target.position);
                Gizmos.DrawWireSphere(target.position, 0.2f);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(nowPos, nowPos + velocity);
            }
        }
#endif
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Move
{
    [System.Serializable]
    public class DecidedMover : IMover
    {
        public AnimationCurve curve;
        public Vector3 start;
        [Min(0.01f)] public float duration = 0.01f;
        public Vector3 end;
        public float delta;

        public void Move(Rigidbody _body)
        {
            if (delta <= duration)
            {
                Vector3 toEnd = end - start;
                _body.position = start + toEnd * (curve.Evaluate(delta / duration));

                delta += Time.deltaTime;
            }
        }

#if UNITY_EDITOR
        public void DrawGizmos()
        {
            Vector3 toEnd = end - start;

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(end, 0.2f);
            Gizmos.DrawLine(start, end);

            Gizmos.color = Color.red;
            Vector3 nowPos = start + toEnd * (curve.Evaluate(delta / duration));
            Gizmos.DrawWireSphere(nowPos, 0.2f);
            Gizmos.DrawLine(start, nowPos);
        }
#endif
    }
}
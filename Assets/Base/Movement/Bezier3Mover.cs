using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Move
{
    [System.Serializable]
    public class Bezier3Mover : IMover
    {
        public Vector3 start;
        public Vector3 p1;
        public Vector3 p2;
        public Vector3 end;

        public float duration;
        public float delta;
        

        public void Move(Rigidbody _body)
        {
            float _delta = delta / duration;

            Vector3 _s = Vector3.Lerp(start, p1, _delta);
            Vector3 _p1 = Vector3.Lerp(p1, p2, _delta);
            Vector3 _e = Vector3.Lerp(p2, end, _delta);

            Vector3 __s = Vector3.Lerp(_s, _p1, _delta);
            Vector3 __e = Vector3.Lerp(_p1, _e, _delta);

            Vector3 ___e = Vector3.Lerp(__s, __e, _delta);

            _body.position = ___e;

            this.delta += Time.deltaTime;
        }

#if UNITY_EDITOR
        public void DrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(start, 0.2f);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(start, p1);
            Gizmos.DrawWireSphere(p1, 0.2f);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(p1, p2);
            Gizmos.DrawWireSphere(p2, 0.2f);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(p2, end);
            Gizmos.DrawWireSphere(end, 0.2f);

        }
#endif
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Move
{
    public enum EMover
    {
        None = -1,
        Straight = 0,
        Decided,
        Bezier3,
        Guided,
        WayPoint,
    }

    public interface IMover
    {
        public void Move(Rigidbody _body);
#if UNITY_EDITOR
        public void DrawGizmos();
#endif
    }
}

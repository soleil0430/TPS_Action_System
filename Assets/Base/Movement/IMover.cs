using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Move
{
    public enum EMover
    {
        None,
        Straight,
        Decided,
        Bezier3,
    }

    public interface IMover
    {
        public void Move(Rigidbody _body);
#if UNITY_EDITOR
        public void DrawGizmos();
#endif
    }
}

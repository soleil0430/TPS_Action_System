using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Move
{
    public abstract class MoverSO : ScriptableObject
    {
        public abstract void Move(Rigidbody _body);

        public virtual void DrawGizmos() { }
    }
}